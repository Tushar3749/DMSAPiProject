// Author: Rahat
// Discount & Bonus Policy implemented by : Mehedi Hasan
// PLEASE UPDATE MODULE VERSION IF YOU CHANGE ANY CODE OF INVOICE PROCESS 
// ==================================================================================================================================

using DMS.Core;
using DMS.Core.Dto.User;
using DMS.Core.DTO;
using DMS.Core.DTO.BonusAndDiscount;
using DMS.Core.DTO.DepotInventory;
using DMS.Core.DTO.Discount;
using DMS.Core.DTO.Orders;
using DMS.Core.DTO.SalesInvoice;
using DMS.Core.Models.CreditNote;
using DMS.Core.Models.Inventory;
using DMS.Core.Models.SalesInvoice;
using DMS.Data.Repository;
using DMS.Services.CreditNote;
using DMS.Services.Formulas;
using DMS.Services.Interfaces;
using DMS.Services.Map;
using DMS.Services.Map.SalesInvoice;
using DMS.Services.User;
using DMS.Services.Validation;
using DMS.Services.Validation.Inventory;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Services.SalesInvoice
{
    public class InvoiceService : SessionService, IInvoiceService
    {

        private BugReportingService bugReportingService;
        private readonly InvoiceRepository repo = null;
        private readonly InvoiceDetailRepository invDetailRepo = null;
        private readonly InventoryRepository inventoryRepo = null;
        private readonly InvoiceProductBatchWiseRepository invProductRepo = null;
        private readonly CodeGenerateRepository codeRepo = null;

        private readonly DiscountRepository dRepo = null;

        private SalesOrderRepository sORepo;

        private readonly DbContext context;
        private readonly DbContext invContext;
        public DepoDayStatementRepository dayRepo;
        private DbContext dayContext;
        private DbContext creditNoteContext;

        private CreditNoteService creditNoteService = null;

        public InvoiceService(IConfiguration Config)
        {
            this.context = new InvoiceContext(Config);
            this.invContext = new InventoryContext(Config);

            this.repo = new InvoiceRepository(this.context);
            this.invDetailRepo = new InvoiceDetailRepository(this.context);
            this.inventoryRepo = new InventoryRepository(this.invContext);
            this.invProductRepo = new InvoiceProductBatchWiseRepository(this.context);
            this.codeRepo = new CodeGenerateRepository(this.context);

            this.sORepo = new SalesOrderRepository(this.context);
            this.dRepo = new DiscountRepository(this.context);

            this.bugReportingService = new BugReportingService(Config);
            dayRepo = new DepoDayStatementRepository(context);


            creditNoteContext = new CreditNoteContext(Config);
            this.creditNoteService = new CreditNoteService(Config);
        }

        // SAVE New Invoice
        // NEED TO VALIDATE
        // 0. Check if day already closed
        // 1. Duplicate Invoice Check
        // 2. Prevent invoice & order product miss match
        // 3. Invoice object validation
        // 4. Invoice value miss match
        // 5. Credit Availability

        public async Task<Invoice> saveInvoice(InvoiceDto Invoice, UserBasicInfo _SESSION_USER)
        {
            
            // VALIDATION ====================================
            // 0. Check if day already closed
            if (await validateDepotDayOperation(Invoice) == false) throw new Exception($"Operation day already closed.");

            // 1:: Duplicate Invoice Check
            //if (await checkIfDuplicateInvoice(Invoice)) throw new Exception($"Duplicate order found for chemist [{Invoice.Invoice.ChemistCode}]");

            
            // 2:: Validate invoice product with order product
            if (await validateOrderProductWithInvoiceProduct(Invoice)) throw new Exception("Invoice Product dosen't match with order product.");

            
            //3:Prevent multiple invoice on same day
            List<ValidateCurrentDateInvoiceDto> validateResultForMultipleInvoice = await repo.validateCurrentDateInvoice(Invoice.Invoice.ChemistCode,Invoice.Invoice.InvoiceDate.ToString("yyyy-MM-dd"),Invoice.Invoice.PaymentMode);
            if (validateResultForMultipleInvoice.Count>0)
            {
                if(validateResultForMultipleInvoice[0].ISVALID == false)
                {
                    throw new Exception($"Failed to save Invoice -> {validateResultForMultipleInvoice[0].ValidationMessage}.");
                }

            }

            
            // Get batch wise Product
            List<InvoiceProductBatchWise> InvoiceProductBatch = await getInvoiceProductBatchWise(Invoice.Invoice.OrderCode, Invoice.Detail);
            if (InvoiceProductBatch == null || InvoiceProductBatch.Count == 0) throw new Exception("Failed to map invoice detail.");

            // MAP Invoice
            Invoice newInvoice = new InvoiceMap().map(Invoice.Invoice);
            if (newInvoice == null) throw new Exception("Failed to map.Please try again");

            // Getting Invoice Code
            newInvoice.InvoiceCode = await this.codeRepo.getGeneratedCode("INVOICE"); // Invoice Code
            if (string.IsNullOrEmpty(newInvoice.InvoiceCode) || string.IsNullOrWhiteSpace(newInvoice.InvoiceCode)) throw new Exception("Failed to generate invoice code.");

            newInvoice.CreatedById = _SESSION_USER.EmployeeID;
            newInvoice.DepotCode = _SESSION_USER.DepotCode;
            newInvoice.MachineId = _SESSION_USER.EmployeeID;
            newInvoice.CreatedOn = DateTime.Now;
            newInvoice.ModuleVersion = _MODULE_VERSION.INVOICE;

            // 3 :: Invoice object validation
            ValidationResult result = new InvoiceValidator().Validate(newInvoice);
            if (!result.IsValid) throw new Exception(result.ToString(" ~"));




            // Updating Invoice Code to invoice detail and invoice product batch wise
            InvoiceProductBatch.AsEnumerable().All(c => { c.InvoiceCode = newInvoice.InvoiceCode; c.CreatedOn = System.DateTime.Now; return true; });

            // map Invoice detail
            List<InvoiceDetail> InvoiceDetails = getMappedInvoiceDetail(Invoice.Detail, newInvoice.InvoiceCode, _SESSION_USER);
            if (!InvoiceDetails.Any()) throw new Exception("Failed to map invoice detail.");


            
            // 4. Invoice value miss match
            if (!updateAndValidateInvoiceSummaryTotal(newInvoice, Invoice.Detail)) throw new Exception("Failed to calculate summary value of invoice from invoice detail.");


            // 5. Credit Availability
            if (newInvoice.PaymentMode.ToUpper() == "CREDIT")
            {
                CreditAvailableforInvoice creditInfo = await checkIfCreditAvailableforInvoice(newInvoice);
                if (creditInfo == null) throw new Exception($"Failed to load chemist credit information for chemist {newInvoice.ChemistCode}. Please try again");

                // Invoice credit limit
                if (!creditInfo.IsCreditAvailableForNewInvoice) throw new Exception($"Invoice amount {newInvoice.NetAmount} exceeds credit limit {creditInfo.CreditLimit} for chemist [{newInvoice.ChemistCode}].");

                // Invoice credit days
                if (!creditInfo.IsInvoiceCreditDaysAvailable) throw new Exception($"Credit days limit passed for Invoice {creditInfo.CreditInvoice} and days {creditInfo.PreviuosDueInvoiceCreditDays}");
            }

            // 5. CASH Availability
            else if (newInvoice.PaymentMode.ToUpper() == "CASH")
            {
                CreditAvailableforInvoice creditInfo = await checkIfCreditAvailableforInvoice(newInvoice);
                if (creditInfo == null) throw new Exception($"Failed to load chemist credit information for chemist {newInvoice.ChemistCode}. Please try again");

                // Invoice credit limit
                if (creditInfo.CreditLimit>0 && creditInfo.DueAmount>=creditInfo.CreditLimit) throw new Exception($" Credit limit is {creditInfo.CreditLimit} and Total Credit Due is {creditInfo.DueAmount} for chemist [{newInvoice.ChemistCode}].");

                // Invoice credit days
                if (!creditInfo.IsInvoiceCreditDaysAvailable) throw new Exception($"Credit days limit passed for Invoice {creditInfo.CreditInvoice} and days {creditInfo.PreviuosDueInvoiceCreditDays}");
            }


            // Saving Invoice   ---------------------------------------------------------------------------
            Invoice inv = await insertInvoice(newInvoice, InvoiceDetails, InvoiceProductBatch);


            //// UPDATE STOCK AFTER INVOICE 
            //try
            //{
            //    await repo.updateDepotInvoiceAvailableStock();
            //}
            //catch { }


             //DAMAGED / EXPIRED ADJUSTMENT -- CREDIT NOTE
            if(newInvoice.CreditNoteAdjustedAmount > 0) await creditNoteService.saveAdjustment(newInvoice.ChemistCode, newInvoice.InvoiceCode, newInvoice.CreditNoteAdjustedAmount, _SESSION_USER);


            // ======================================================================
            return inv;
        }


        private async Task<bool> validateDepotDayOperation(InvoiceDto Invoice)
        {
            var data = await dayRepo.getDepotDayOperationStatus();
            if (data == null) throw new Exception("Failed to load depot day operational data. Please check getDepotDayOperationStatus() ");
            var dayStatus = data.FirstOrDefault();

            // check day is not opened
            if (dayStatus.IsDayOpened == null || dayStatus.IsDayOpened.Value == false) throw new Exception("Day is not open. Please open the day from Administration -> Day Operation");

            // check day closed
            if (dayStatus.IsDayClosed!=null && dayStatus.IsDayClosed.Value == true) return false;
            else
            {
                // check invoice date and day open date is same
                DateTime reportDate = Convert.ToDateTime(dayStatus.ReportDate);
                var dayDiff = reportDate.Subtract(Invoice.Invoice.InvoiceDate).Days;
                if (dayDiff != 0)
                {
                    throw new Exception($"Invoice date [{Invoice.Invoice.InvoiceDate.ToString("dd MMM yyyy")}] is not same depot opening date [{reportDate.ToString("dd MMM yyyy")}]");
                }
                return true;
            }
        }

        private async Task<CreditAvailableforInvoice> checkIfCreditAvailableforInvoice(Invoice invoice)
        {
            return await repo.checkIfCreditAvailableforInvoice(invoice);
        }

        private async Task<bool> checkIfDuplicateInvoice(InvoiceDto InvoiceDto)
        {
            try
            {
                
                // Check if invoice exists in same date for chemist
                Invoice invoice = await repo.getInvoiceByChemistCodeAndInvoiceDate(InvoiceDto.Invoice.ChemistCode, DateTime.Now.Date);
                if (invoice == null) return false;

                // check if product exists in invoice detail
                List<InvoiceDetail> invoiceDetails = await repo.getInvoiceDetail(invoice.InvoiceCode);
                if (!invoiceDetails.Any()) throw new Exception("Some error occured. Please try again.");

                // filter invoice product
                List<InvoiceDetail> filteredInvoiceDetails = invoiceDetails.Where(x => InvoiceDto.Detail.Select(i => i.ProductCode + "-" + i.InvoiceQty).ToList().Contains(x.ProductCode + "-" + x.InvoiceQty)).ToList();
                if (filteredInvoiceDetails.Any() && InvoiceDto.Detail.Count == filteredInvoiceDetails.Count) return true;

                return false;
            }
            catch (Exception ex)
            {
                //this.error = ex;
                await this.bugReportingService.sendBugReport(ex, "checkIfDuplicateInvoice");
                return false;
            }
            
        }

        private async Task<bool> validateOrderProductWithInvoiceProduct(InvoiceDto Invoice)
        {
            if (string.IsNullOrEmpty(Invoice.Invoice.OrderCode))
                throw new Exception("Order code not found.");

            // Get order product 
            var orderProduct = await repo.GetOrderDetailsByOrderCode(Invoice.Invoice.OrderCode);
            if(!orderProduct.Any()) throw new Exception("No Order Product found. Order Code: " + Invoice.Invoice.OrderCode);

            var orderList = Invoice.Detail.Where(c => !orderProduct.Select(x => x.ProductCode).Contains(c.ProductCode)).ToList();

            return orderList.Any();
        }

        private Boolean updateAndValidateInvoiceSummaryTotal(Invoice newInvoice, List<InvoiceDetailNewDto> detail)
        {
            try
            {
                SalesInvoiceFormula formula = new SalesInvoiceFormula();

                newInvoice.NetTp = detail.Sum(p => p.TotalTP).Value;
                newInvoice.NetVat = detail.Sum(p => p.TotalVat).Value;
                newInvoice.NetAmountDiscount = detail.Sum(p => p.AmountDiscount).Value;
                newInvoice.NetProductDiscount = detail.Sum(p => p.ProductDiscount).Value;


                var NetAmountWithoutAdjustment = Math.Round(formula.getNetAmountWithoutAdjustment(newInvoice.NetTp, newInvoice.NetVat, newInvoice.NetProductDiscount, newInvoice.NetAmountDiscount), 0);

                // Validating Adjustment Amount with NetTP
                if (newInvoice.CreditNoteAdjustedAmount > NetAmountWithoutAdjustment) newInvoice.CreditNoteAdjustedAmount = 0;

                newInvoice.NetAmount = Math.Round( formula.getNetAmount(newInvoice.NetTp, newInvoice.NetVat, newInvoice.NetProductDiscount, newInvoice.NetAmountDiscount, newInvoice.CreditNoteAdjustedAmount), 0);

                return true;
            }
            catch { return false; }
        }

        // mapping invoice details
        private List<InvoiceDetail> getMappedInvoiceDetail(List<InvoiceDetailNewDto> detailDto, string invoiceCode, UserBasicInfo _User)
        {
            List<InvoiceDetail> invoiceDetails = new List<InvoiceDetail>();

            foreach(InvoiceDetailNewDto invProduct in detailDto)
            {
                // mapping invoice detail
                InvoiceDetail invDetail = new InvoiceMap().mapDetail(invProduct);
                if (invDetail == null) throw new Exception("Failed to map invoice detail. Please try again");

                invDetail.IsActive = true;
                invDetail.InvoiceCode = invoiceCode;
                invDetail.CreatedOn = System.DateTime.Now;
                invDetail.CreatedById = _User.EmployeeID;
                invDetail.MachineId = _User.EmployeeID;

                // Invoice VALIDATION
                ValidationResult result = new InvoiceDetailValidator().Validate(invDetail);
                if (!result.IsValid) throw new Exception( "Failed to validate invoice detail. Something wrong with invoice detail data. " +  result.ToString(" ~"));

                invoiceDetails.Add(invDetail);
            }

            return invoiceDetails;
        }

        // Distribute Product Batch Wise
        private async Task<List<InvoiceProductBatchWise>> getInvoiceProductBatchWise(string OrderCode,List<InvoiceDetailNewDto> detailDto)
        {
            List<InvoiceProductBatchWise> proBatch = new List<InvoiceProductBatchWise>();

            await inventoryRepo.updateDepotAvailableStock_OrderSpecific(OrderCode);
            // Getting Current stock
            List<ProductBatchStockForInvoice> batchStock = await inventoryRepo.getCurrentStock();
            if (!batchStock.Any()) throw new Exception($"Stock Not Found. Conatact (IT) Administrator");

            foreach (InvoiceDetailNewDto invDetail in detailDto)
            {
                // Getting Total Stock of the product
                int totalBatchStock = batchStock.Where(i => i.ProductCode == invDetail.ProductCode).Sum(i => i.StockQty);

                // Getting Invoice Total quantity
                int invoiceTotalQuantity = invDetail.InvoiceQty.GetValueOrDefault() + invDetail.BonusQty.GetValueOrDefault();
                int RemainingQty = invoiceTotalQuantity;

                // Checking if stock is out of order
                if (invoiceTotalQuantity > totalBatchStock)
                    throw new Exception($"Out Of Stock {invDetail.ProductName} Invoice Quantity : {invoiceTotalQuantity} Stock Quantity {totalBatchStock}");

                while (RemainingQty > 0)
                {
                    InvoiceProductBatchWise invProductbatch = new InvoiceProductBatchWise();


                


                    //Getting Individual batch
                    ProductBatchStockForInvoice batch = batchStock.Where(i => i.ProductCode == invDetail.ProductCode && i.StockQty > 0).OrderBy(i => Convert.ToInt32(i.BatchNo)).ToList().FirstOrDefault();
                    if (batch == null) throw new Exception($"Product Code: {invDetail.ProductCode}, Product Stock Not Found. Contact (IT) Administrator");

                    // Checking if Batch Quantity is greater than or equal remaining quantity
                    if (batch.StockQty >= RemainingQty)
                    {
                        invProductbatch.Quantity = RemainingQty;
                        batch.StockQty = batch.StockQty - RemainingQty;

                        RemainingQty = 0;
                    }
                    else
                    {
                        invProductbatch.Quantity = batch.StockQty;
                        RemainingQty = RemainingQty - batch.StockQty;


                        /// PREVIOUS CODE
                        batch.StockQty = 0;
                        ///

                        // UPDATED ONE = 16 Nov 2021
                        //batchStock.Where(i => i.ProductCode == invDetail.ProductCode && i.BatchNo == batch.BatchNo && i.StockQty == batch.StockQty).FirstOrDefault().StockQty = 0;
                    }


                    // Validation
                    if (RemainingQty < 0) throw new Exception($"Remaining quantity can't be negative quantity. Remaining qty: ${RemainingQty.ToString()}");
                    if (invProductbatch.Quantity < 0) throw new Exception($"Product batch quantity can't be negative quantity. Product batch qty: ${invProductbatch.Quantity.ToString()}");


                    if (batch.StockQty < 0)
                        throw new Exception($"Stock Negative Error. {invDetail.ProductCode} - {invDetail.ProductName}  For BatchNo :{batch.BatchNo}. Contact (IT) Administrator");

                    invProductbatch.ProductCode = invDetail.ProductCode;
                    invProductbatch.BatchNo = batch.BatchNo;

                    // Assigning Product Batch to list
                    proBatch.Add(invProductbatch);
                }
            }

            return proBatch;
        }

        // Inserting sales invoice
        private async Task<Invoice> insertInvoice(Invoice invoice, List<InvoiceDetail> detail, List<InvoiceProductBatchWise> batch)
        {
            Exception error  = null;
            string workingModel = "";


            await new InvoiceLogicValidation().validateFinalInvoice(invoice, detail);


            try
            {
                // PREVENT DUPLICATE INVOICE
                if (await hasThisOrderActiveInvoice(invoice.OrderCode)) throw new Exception($"Active invoice found using order code : {invoice.OrderCode}, Invoice Code: {invoice.InvoiceCode} ");

                await this.repo.BEGIN_TRANSACTION();


                

                workingModel = "Invoice";
                // INVOICE
                Invoice newInvoice = await repo.save(invoice);
                if(newInvoice == null)
                {
                    await this.repo.ROLL_BACK();
                    throw new Exception("Failed to save master.");
                }

                workingModel = "InvoiceDetail";
                // INVOICE DETAIL
                List<InvoiceDetail> invDetail = await invDetailRepo.saveBulk(detail);
                if (!invDetail.Any())
                {
                    await this.repo.ROLL_BACK();
                    throw new Exception("Failed to save details.");
                }

                workingModel = "InvoiceProductBatchWise";
                // INVOICE BATCH WISE PRODUCT
                List<InvoiceProductBatchWise> newInvBatch = await invProductRepo.saveBulk(batch);
                if (!newInvBatch.Any())
                {
                    await this.repo.ROLL_BACK();
                    throw new Exception("Failed to save product batch.");
                }

                // PREVENT DUPLICATE INVOICE
                //if (await hasThisOrderActiveInvoice(invoice.OrderCode)) throw new Exception("Active invoice found using order code : " + invoice.OrderCode);


                // COMMIT
                await this.repo.COMMIT();
                return newInvoice;
            }
            catch(Exception ex)
            {
                await this.repo.ROLL_BACK();
                logException(ex, workingModel);
                error = ex;
            }

            if(error != null) throw error;  
            return null; 
        }



        

        private async Task<Boolean> hasThisOrderActiveInvoice(string OrderCode)
        {
            var invoice = await repo.getInvoice(p => p.OrderCode == OrderCode && p.IsActive == true);
            if (invoice != null) return true;
            else return false;
        }

        public async Task<InvoiceNewDto> getOrderDetailForInvoice(string OrderCode, Boolean HasCreditNoteAdjustment)
        {

            // exception test
            //throw new Exception("Exception testing");

            InvoiceNewDto invoiceNew = new InvoiceNewDto();

            List<InvoicePendingOrderDetail> orderProducts = await sORepo.getOrderDetailForInvoice(OrderCode);
            Order order = await sORepo.getSalesOrder(OrderCode);

            if (order == null)
            {
                // MAKE A LOG HERE
                //logException(new Exception("ORDER NOT FOUND BY ORDER CODE: " + OrderCode));
                return null;
            }

            List<InvoiceDetailNewDto> invoiceDetail = new List<InvoiceDetailNewDto>();

            // Transforming Order Detail to Invoice Detail
            foreach (var product in orderProducts)
            {
                InvoiceDetailNewDto detail = new OrderDetailToInvoiceDetailMap().map(product);
                detail.InvoiceQty = product.OrderQty;
                detail.IsInvoiceAmountDiscountApplicable = true;
                invoiceDetail.Add(detail);
            }




            invoiceNew = await applyBonusAndDiscountForInvoiceDetail(invoiceDetail, order.ChemistCode, order.PaymentMode, HasCreditNoteAdjustment);

            return invoiceNew;

        }

        //
        //
        //
        //
        //
        //
        //
        //
        //
        //
        //
        //
        //
        //
        //
        //        
        //
        //
        //        
        //
        //
        //        
        //
        //
        //
        //                                      INTENTIONAL BREAK, take a nap and come back for any changes;) 
        //
        //
        //
        //
        //
        //
        //        
        //
        //
        //        
        //
        //
        //        
        //
        //
        //        
        //
        //
        //        
        //
        //
        //        
        //
        //
        //        
        //
        //
        //        
        //
        //
        //

        #region BONUS, DISCOUNT AND SPECIAL RATE CALCULATION
        // ======================================================================================================================================================================
        // MOST IMPORTANT ::: Please review the all logic before updating any code here. Also check Summary Invoice 
        // BONUS & DISCOUNT CALCULATION
        // Note: If you update the logic here, please update MODULE VERSION. So that you can verify the discount version in invoice report 
        // Developed by: Mehedi, Last Updated on: 05 Feb 2023, Version: 0.4
        // ======================================================================================================================================================================

        public async Task<InvoiceNewDto> applyBonusAndDiscountForInvoiceDetail(List<InvoiceDetailNewDto> InvoiceDetail, string ChemistCode, string PaymentMode, Boolean HasCreditNoteAdjustment)
        {

            InvoiceNewDto invoiceNew = new InvoiceNewDto();


            SalesInvoiceFormula formula = new SalesInvoiceFormula();

            foreach (var product in InvoiceDetail)
            {

                if (string.IsNullOrEmpty(product.ProductCode)) throw new Exception("Product code not found in Invoice Detail.");

                product.TotalTP = formula.getTotalTP(product.InvoiceQty.GetValueOrDefault(), product.TP.GetValueOrDefault());
                product.TotalVat = formula.getTotalVAT(product.InvoiceQty.GetValueOrDefault(), product.Vat.GetValueOrDefault());


                // DISCOUNT:: SP -> applyChemistDiscountAndBonus
                ChemistDiscountAndBonusDto discount = await this.applyChemistDiscountAndBonusForEachProduct(ChemistCode, product.ProductCode, PaymentMode, product.InvoiceQty.GetValueOrDefault());
                if (discount != null)
                {
                    product.BonusQty = discount.BonusQuantity;
                    product.QuantityAfterBonus = discount.QuantityAfterBonus;
                    product.ProductDiscount = discount.ProductDiscount;
                    product.FacilityAmount = discount.FacilityAmount;
                    product.IsAmountInPercent = discount.IsAmountInPercent;
                    product.DiscountCode = discount.DiscountCode;
                    product.AppliedDiscountRuleNumbers = discount.AppliedDiscountRuleNumbers;
                    product.IsInvoiceAmountDiscountApplicable = discount.IsInvoiceAmountDiscountApplicable;
                    product.BonusSegment = discount.BonusSegment;
                }

                // HAS STOCK SHORT
                product.HasStockShort = formula.hasStockShort(product.StockQty.GetValueOrDefault(), product.InvoiceQty.GetValueOrDefault(), product.BonusQty.GetValueOrDefault());


            }


            // INVOICE TRADE DISCOUNT
            InvoiceDetail = await this.calculate_INVOICE_TRADE_DISCOUNT(InvoiceDetail);
   

     
            invoiceNew.InvoiceDetail = new List<InvoiceDetailNewDto>();
            invoiceNew.InvoiceDetail.AddRange(InvoiceDetail);



            ///// CREDIT NOTE ADJUSTMENT
            ///
            if (HasCreditNoteAdjustment)
            {
                var creditNoteAdjustmentAmount = await creditNoteService.getChemistAprrovedTotalAmount(ChemistCode);
                if (creditNoteAdjustmentAmount != null && creditNoteAdjustmentAmount.Amount > 0)
                {
                    invoiceNew.AdjustmentAmount = creditNoteAdjustmentAmount.Amount;
                }
            }

            return invoiceNew;
        }






        // ======================================================================================================================================================================
        // INVOICE TRADE DISCOUNT CALCULATION
        // ======================================================================================================================================================================

        public async Task<List<InvoiceDetailNewDto>> calculate_INVOICE_TRADE_DISCOUNT(List<InvoiceDetailNewDto> invoiceDetail)
        {
            SalesInvoiceFormula formula = new SalesInvoiceFormula();
            foreach (var product in invoiceDetail)
            {
                product.ProductAmount = formula.getNetAmount(product.TotalTP.GetValueOrDefault(), product.TotalVat.GetValueOrDefault(), product.ProductDiscount.GetValueOrDefault(), product.AmountDiscount.GetValueOrDefault());
            }

            // INVOICE TRADE DISCOUNT
            List<DiscountDetailForInvoiceGeneralDto> invoiceGeneralDiscount = await dRepo.getTradeDiscountDetail();
            if (invoiceGeneralDiscount == null || invoiceGeneralDiscount.Count == 0)
            {
                // MAKE A LOG HERE
                await this.bugReportingService.sendBugReport(new Exception("INVOICE TRADE DISCOUNT NOT FOUND FOR"), "calculate_INVOICE_TRADE_DISCOUNT");
                await this.bugReportingService.sendBugReport(new Exception(new DMS.Utility.Library.JSONSerialize().getJSONString(invoiceDetail)), "calculate_INVOICE_TRADE_DISCOUNT");
                return invoiceDetail;
            }


            // INVOICE TOTAL TP
            decimal totalTPForAmountDiscount = invoiceDetail.Where(p => p.IsInvoiceAmountDiscountApplicable == true).Sum(d => (d.TP.GetValueOrDefault() * d.QuantityAfterBonus)).GetValueOrDefault();

            if (totalTPForAmountDiscount <= 0)
            {
                // MAKE A LOG HERE
                await this.bugReportingService.sendBugReport(new Exception("INVALID INVOICE TOTAL TP"), "calculate_INVOICE_TRADE_DISCOUNT");
                await this.bugReportingService.sendBugReport(new Exception(new DMS.Utility.Library.JSONSerialize().getJSONString(invoiceDetail)), "calculate_INVOICE_TRADE_DISCOUNT");
                //return invoiceDetail;
            }

            decimal applicableDiscountPercent = 0;
            string tradeDiscountCode = "";


            if (totalTPForAmountDiscount > 0)
            {
                var tradeDiscount = invoiceGeneralDiscount.Where(d => totalTPForAmountDiscount > d.MinimumRange && totalTPForAmountDiscount <= d.MaximumRange).FirstOrDefault();
                if (tradeDiscount != null)
                {
                    applicableDiscountPercent = tradeDiscount.Amount.GetValueOrDefault();
                    tradeDiscountCode = tradeDiscount.DiscountCode;
                }
            }


            // APPLICABLE DISCOUNT
            if (totalTPForAmountDiscount <= 0)
            {
                // MAKE A LOG HERE
                await this.bugReportingService.sendBugReport(new Exception("INVALID INVOICE APPLICABLE DISCOUNT PERCENT"), "calculate_INVOICE_TRADE_DISCOUNT");
                await this.bugReportingService.sendBugReport(new Exception(new DMS.Utility.Library.JSONSerialize().getJSONString(invoiceDetail)), "calculate_INVOICE_TRADE_DISCOUNT");
                //return invoiceDetail;
            }

            string productCodeEP2 = "P-00275";
            string productCodeEP4 = "P-00041";
            string productCodeEP4Old = "P-00005";

            // UPDATE TRADE DISCOUNT
            foreach (var product in invoiceDetail)
            {

                if (productCodeEP2 == product.ProductCode || productCodeEP4 == product.ProductCode || productCodeEP4Old == product.ProductCode)
                {
                    product.AmountDiscount = 0;
                }
                else
                {
                    product.AmountDiscount = 0;
                }
                

                // key field => QuantityAfterBonus, DiscountCode
                // Trade discount is not applicable if any product has other facility.
                if (product.IsInvoiceAmountDiscountApplicable == true && applicableDiscountPercent > 0)
                {
                    if (productCodeEP2 == product.ProductCode || productCodeEP4 == product.ProductCode || productCodeEP4Old == product.ProductCode)
                    {
                        product.AmountDiscount = 0;
                    }
                    else
                    {
                        product.AmountDiscount = (product.TP * product.QuantityAfterBonus) * (applicableDiscountPercent / 100.0M);
                    }
                    
                    product.DiscountCode = tradeDiscountCode;
                }

                product.ProductAmount = formula.getNetAmount(product.TotalTP.GetValueOrDefault(), product.TotalVat.GetValueOrDefault(), product.ProductDiscount.GetValueOrDefault(), product.AmountDiscount.GetValueOrDefault());

                product.IndividualDiscountPercent = formula.getPercent(product.TotalTP.GetValueOrDefault(), (product.ProductDiscount.GetValueOrDefault() + product.AmountDiscount.GetValueOrDefault()));

            }

            return invoiceDetail;
        }









        // FUNCTION CALLED IN FOREACH LOOP
        public async Task<ChemistDiscountAndBonusDto> applyChemistDiscountAndBonusForEachProduct(string ChemistID, string ProductCode, string PaymentMode, int Quantity)
        {
            var discount = await repo.applyChemistDiscountAndBonus(ChemistID, ProductCode, PaymentMode, Quantity, DateTime.Now);
            return discount.FirstOrDefault();
        }


        // ======================================================================================================================================================================
        // END HERE
        // ======================================================================================================================================================================

        #endregion
        public async Task<List<LocationWiseInvoiceDateBetweenDto>> getLocationWiseInvoiceDateBetween(string FromDate, string ToDate, string PaymentMode, string LocationCode)
        {
            return await repo.getLocationWiseInvoiceDateBetween(FromDate, ToDate, PaymentMode, LocationCode); 
        }




    }
}
