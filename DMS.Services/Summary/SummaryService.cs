
/*
*=============================================
*Author: MEHEDI
*Email: mehedi@labaidpharma.com
*Created on: 19 JUNE 2021
*Updated on: 
*Last updated on:
*Description: <>
*=============================================
*/

using DMS.Core.Dto.User;
using DMS.Core.DTO;
using DMS.Core.DTO.BonusAndDiscount;
using DMS.Core.DTO.Discount;
using DMS.Core.DTO.Outstanding;
using DMS.Core.DTO.SalesInvoice;
using DMS.Core.DTO.SummaryReturn;
using DMS.Core.GlobalConstant;
using DMS.Core.Models.SalesInvoice;
using DMS.Core.Models.SummaryInvoice;
using DMS.Data.Repository;
using DMS.Services.Formulas;
using DMS.Services.Interfaces;
using DMS.Services.Map.Accounts;
using DMS.Services.Map.SalesSummary;
using DMS.Services.Map.SummaryReturn;
using DMS.Services.Validation;
using DMS.Services.Validation.Inventory;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Services.SummaryAndReturn
{
    public class SummaryService : LoggerService, ISummaryService
    {
        private Exception error;

        private readonly DbContext context;
        private readonly DbContext sumContext = null;

        private readonly SummaryRepository repo = null;
        private readonly InvoiceSummaryRepository _sumRepo = null;
        private readonly InvoiceRepository invRepo = null;
        private readonly DiscountRepository dRepo = null;
        private readonly CodeGenerateRepository _codeRepo = null;
        private readonly InvoiceProductBatchWiseRepository _proBatchRepo = null;
        public DepoDayStatementRepository dayRepo;


        public SummaryService(IConfiguration Config)
        {
            this.sumContext = new SummaryInvoiceContext(Config);
            this.context = new InvoiceContext(Config);

            this.repo = new SummaryRepository(this.context);
            this.invRepo = new InvoiceRepository(this.context);
            this.dRepo = new DiscountRepository(this.context);
            this._codeRepo = new CodeGenerateRepository(this.context);
            this._proBatchRepo = new InvoiceProductBatchWiseRepository(this.context);
            this._sumRepo = new InvoiceSummaryRepository(this.sumContext);

            this.dayRepo = new DepoDayStatementRepository(context);
        }



        // ======================================================
        // SUMMARY RETURN
        // ======================================================

        public async Task<string> saveSummaryReturnCollection(SummaryReturnNewDto SummaryNewDto, UserBasicInfo _User)
        {
            // VALIDATION ====================================
            // 0. Check if day already closed
            if (await validateDepotDayOperation() == false) throw new Exception($"Operation day already closed.");

            

            SummaryPendingInvoiceAllocationDto SummaryAllocation = SummaryNewDto.SummaryAllocation;
            List<AllocationInvoiceForSummaryMasterDto> SummaryReturn = SummaryNewDto.SummaryReturn;
            List<SummaryCollectionNewDto> SummaryCollectionDto = SummaryNewDto.SummaryCollection ;

            SummaryLogicValidation summaryLogicValidation = new SummaryLogicValidation();

            // ********************************************************************************
            // SUMMARY INVOICE PART

            // Decalring Variables
            List<SummaryInvoiceDetail> invoiceDetailSummary = new List<SummaryInvoiceDetail>();
            List<SummaryInvoice> invoiceSummary = new List<SummaryInvoice>();
            List<SummaryInvoiceProductBatchWise> productBatch = new List<SummaryInvoiceProductBatchWise>();

            List<SummaryCollectionDetail> collectionDetails = new List<SummaryCollectionDetail>();
            List<SummaryCollectionInstrument> collectionInstrumets = new List<SummaryCollectionInstrument>();

            // Checking if allocation code exists.
            string allocationCode = SummaryNewDto.SummaryAllocation.AllocationCode;
            if (string.IsNullOrEmpty(allocationCode)) throw new Exception("Allocation code not found. Allocation Code: " + allocationCode);



            foreach (AllocationInvoiceForSummaryMasterDto invoice in SummaryReturn)
            {
                // VALIDATION :: SUMMARY INVOICE
                summaryLogicValidation.validateSummaryInvoice(invoice);

                // VALIDATION :: INVOICE DETAIL
                List<SummaryInvoiceDetail> sumInvoiceDetail = mapAndValidateInvoiceDetailSummary(invoice.InvoiceDetail, _User);
                if (!sumInvoiceDetail.Any()) throw new Exception("Failed to map summary invoice detail. mapAndValidateInvoiceDetailSummary");


                invoiceDetailSummary.AddRange(sumInvoiceDetail);

                // Summary Invoice
                SummaryInvoice sumInvoice = mapAndValidateInvoiceSummary(invoice, _User);
                if (sumInvoice == null) throw new Exception("Failed to map summary invoice. mapAndValidateInvoiceSummary");

                sumInvoice.IsInvoiceSettled = false;
                sumInvoice.NetTp = invoiceDetailSummary.Sum(i => i.TotalTp); 
                sumInvoice.NetVat = invoiceDetailSummary.Sum(i => i.TotalVat.GetValueOrDefault());
                sumInvoice.NetProductDiscount = invoiceDetailSummary.Sum(i => i.TotalProductDiscount);
                sumInvoice.NetAmountDiscount = invoiceDetailSummary.Sum(i => i.TotalAmountDiscount);
                sumInvoice.NetAmount = Math.Round(invoiceDetailSummary.Sum(i => i.Amount) - sumInvoice.CreditNoteAdjustedAmount) ;

                invoiceSummary.Add(sumInvoice);
            }

            productBatch = await mapAndValidateProductBatchWise(invoiceSummary);
            if(!productBatch.Any()) throw new Exception("Failed to map summary product wise batch. mapAndValidateProductBatchWise");

            // ********************************************************************************
            // SUMMARY COLLECTION PART
            //collectionDetail = 
            foreach(SummaryCollectionNewDto collectionDto in SummaryCollectionDto)
            {
                foreach(SummaryCollectionDetailNew collectionDetailDto in collectionDto.CollectionDetail)
                {
                    if(collectionDetailDto.CollectionAmount != null && collectionDetailDto.CollectionAmount > 0)
                    {
                        SummaryCollectionDetail collDetail = new MeneyReceiptMap().mapCollectionDetail(collectionDetailDto);
                        if (collDetail == null) throw new Exception("Summary colleciton detail not found.");

                        collDetail.Amount = collectionDetailDto.CollectionAmount.GetValueOrDefault();
                        collDetail.IsAitdocumentReceived = collectionDetailDto.IsAITDocumentReceived;
                        collDetail.AitdeductionAmount = collectionDetailDto.AITDeductionAmount.GetValueOrDefault();

                        if (collectionDto.HasChequePayment)
                        {
                            collDetail.InstrumentNumber = collectionDto.ChequeNumber;
                            if (collDetail.CashCollectionAmount.GetValueOrDefault() > 0) collDetail.CollectionType = CollectionMode.BOTH;
                            else collDetail.CollectionType = CollectionMode.CHEQUE;
                        }
                        else collDetail.CollectionType = CollectionMode.CASH;


                        collDetail.IsActive = true;
                        collDetail.CreatedById = _User.EmployeeID;
                        collDetail.CreatedOn = System.DateTime.Now;
                        collDetail.ModuleVersion = Core._MODULE_VERSION.SUMMARY;

                        collectionDetails.Add(collDetail);
                    }
                }

                if (collectionDto.HasChequePayment)
                {
                    SummaryCollectionInstrument collInstrument = new SummaryCollectionInstrument();

                    collInstrument.ChemistCode = collectionDto.ChemistCode;
                    collInstrument.InstrumentNumber = collectionDto.ChequeNumber;
                    collInstrument.InstrumentType = "Cheque";
                    collInstrument.InstrumentBank = $"{collectionDto.ChequeBankName}, {collectionDto.ChequeBankBranch}";
                    collInstrument.InstrumentDate = Convert.ToDateTime(collectionDto.ChequeDate);
                    collInstrument.Amount = collectionDto.ChequeAmount.GetValueOrDefault();

                    collInstrument.IsActive = true;
                    collInstrument.CreatedById = _User.EmployeeID;
                    collInstrument.CreatedOn = System.DateTime.Now;
                    collInstrument.MachineId = "La Machina";

                    collectionInstrumets.Add(collInstrument);
                }
            }

            bool hasCollection = collectionDetails.Any();




            Summary insertedSummary = await getAllocaitonSummary(allocationCode, SummaryAllocation.DACode, _User);
            if (insertedSummary == null) throw new Exception("Invoice summary not found.");


            SummaryCollection collection = await getSummaryCollection(_User);

            // Updating summary code to invoice detail summary
            collection.SummaryCode = insertedSummary.SummaryCode;
            invoiceDetailSummary.All(c => { c.SummaryCode = insertedSummary.SummaryCode; return true; });

            invoiceSummary.All(c => { c.SummaryCode = insertedSummary.SummaryCode; 
                c.NetTp = invoiceDetailSummary.Where(j => j.InvoiceCode == c.InvoiceCode).Sum(i => i.TotalTp);
                c.NetVat = invoiceDetailSummary.Where(j => j.InvoiceCode == c.InvoiceCode).Sum(i => i.TotalVat.GetValueOrDefault());
                c.NetAmountDiscount = invoiceDetailSummary.Where(j => j.InvoiceCode == c.InvoiceCode).Sum(i => i.TotalAmountDiscount);
                c.NetProductDiscount = invoiceDetailSummary.Where(j => j.InvoiceCode == c.InvoiceCode).Sum(i => i.TotalProductDiscount);
                c.NetAmount = Math.Round(((c.NetTp + c.NetVat) - (c.NetAmountDiscount + c.NetProductDiscount + c.CreditNoteAdjustedAmount)));

                return true; });

            productBatch.All(c => { c.SummaryCode = insertedSummary.SummaryCode; return true; });

            if(hasCollection)
            {
                collectionDetails.All(c => { c.CollectionCode = collection.CollectionCode; return true; });
                collectionInstrumets.All(c => { c.CollectionCode = collection.CollectionCode; return true; });
            }



            await validateFinalInvoice(invoiceSummary, invoiceDetailSummary);

            // Inserted invoice summary
            Summary newInvoiceSummary = await insertInvoiceSummary(insertedSummary, invoiceSummary, invoiceDetailSummary, productBatch, collection, collectionDetails, collectionInstrumets, hasCollection);
            
            // Updating sold and return to available stock
            await repo.updateDepotSoldAvailableStock();

            if (newInvoiceSummary == null) throw this.error;
            //return insertedSummary.SummaryCode;
            return newInvoiceSummary.SummaryCode;
        }

        private async Task<Boolean> validateFinalInvoice(List<SummaryInvoice> SummaryInvoices, List<SummaryInvoiceDetail> SummaryInvoiceDetails)
        {
            foreach (var invoice in SummaryInvoices)
            {
                List<SummaryInvoiceDetail> invoiceDetail = SummaryInvoiceDetails.Where(i=> i.InvoiceCode == invoice.InvoiceCode).ToList();
                await new SummaryLogicValidation().validateFinalInvoice(invoice, invoiceDetail);
            }

            return true;
        }


        public async Task<string> saveSummaryCollection(SummaryDueCollectionDto SummaryCollectionDto, UserBasicInfo _User)
        {
            // Decalring Variables
            List<SummaryCollectionDetail> collectionDetails = new List<SummaryCollectionDetail>();
            List<SummaryCollectionInstrument> collectionInstruments = new List<SummaryCollectionInstrument>();
            string allocationCode = "";

            // ********************************************************************************
            // SUMMARY COLLECTION PART

            //collectionDetail = 
            foreach (SummaryCollectionNewDto collectionDto in SummaryCollectionDto.SummaryCollectionDto)
            {
                foreach (SummaryCollectionDetailNew collectionDetailDto in collectionDto.CollectionDetail)
                {
                    if (collectionDetailDto.CollectionAmount != null && collectionDetailDto.CollectionAmount > 0)
                    {
                        SummaryCollectionDetail collDetail = new MeneyReceiptMap().mapCollectionDetail(collectionDetailDto);
                        if (collDetail == null) throw new Exception("Summary colleciton detail not found.");

                        collDetail.CashCollectionAmount = Math.Round(collectionDetailDto.CashCollectionAmount.GetValueOrDefault());
                        collDetail.ChequeCollectionAmount = Math.Round(collectionDetailDto.ChequeCollectionAmount.GetValueOrDefault());
                        collDetail.Amount = Math.Round(collectionDetailDto.CollectionAmount.GetValueOrDefault());

                        collDetail.IsAitdocumentReceived = collectionDetailDto.IsAITDocumentReceived;
                        collDetail.AitdeductionAmount = collectionDetailDto.AITDeductionAmount.GetValueOrDefault();

                        if (collectionDto.HasChequePayment) collDetail.InstrumentNumber = collectionDto.ChequeNumber;
                        collDetail.IsActive = true;
                        collDetail.CreatedById = _User.EmployeeID;
                        collDetail.CreatedOn = System.DateTime.Now;
                        collDetail.ModuleVersion = Core._MODULE_VERSION.SUMMARY;
                        collectionDetails.Add(collDetail);
                    }
                }

                if (collectionDto.HasChequePayment)
                {
                    SummaryCollectionInstrument collInstrument = new SummaryCollectionInstrument();

                    collInstrument.ChemistCode = collectionDto.ChemistCode;
                    collInstrument.InstrumentNumber = collectionDto.ChequeNumber;
                    collInstrument.InstrumentType = "Cheque";
                    collInstrument.InstrumentBank = $"{collectionDto.ChequeBankName}, {collectionDto.ChequeBankBranch}";
                    collInstrument.InstrumentDate = Convert.ToDateTime(collectionDto.ChequeDate);
                    collInstrument.Amount = Math.Round(collectionDto.ChequeAmount.GetValueOrDefault());

                    collInstrument.IsActive = true;
                    collInstrument.CreatedById = _User.EmployeeID;
                    collInstrument.CreatedOn = System.DateTime.Now;
                    collInstrument.MachineId = "La Machina";

                    collectionInstruments.Add(collInstrument);
                }
            }

            bool hasCollection = collectionDetails.Any();

            Summary insertedSummary = await getAllocaitonSummary("", SummaryCollectionDto.DACode, _User);
            if (insertedSummary == null) throw new Exception("Invoice Summary not found.");

            SummaryCollection collection = await getSummaryCollection(_User);

            // Updating summary code to invoice detail summary
            collection.SummaryCode = insertedSummary.SummaryCode;
            
            collectionDetails.All(c => { c.CollectionCode = collection.CollectionCode; return true; });
            collectionInstruments.All(c => { c.CollectionCode = collection.CollectionCode; return true; });

            // Inserted invoice summary
            Summary newInvoiceSummary = await insertCollectionSummary(insertedSummary, collection, collectionDetails, collectionInstruments);

            //return insertedSummary.SummaryCode;
            if (newInvoiceSummary == null) throw this.error;
            
            return newInvoiceSummary.SummaryCode;
        }


        private async Task<SummaryCollection> getSummaryCollection(UserBasicInfo _User)
        {
            SummaryCollection collection = new SummaryCollection();

            string collectionCode = await _codeRepo.getGeneratedCode("COLLECTION");
            if (string.IsNullOrEmpty(collectionCode)) throw new Exception("Failed to generate collection code.");

            collection.CollectionCode = collectionCode;
            collection.IsActive = true;
            collection.CreatedById = _User.EmployeeID;
            collection.CreatedOn = System.DateTime.Now;
            collection.ModuleVersion = Core._MODULE_VERSION.SUMMARY;

            return collection;
        }


        private async Task<Summary> getAllocaitonSummary(string allocationCode, string DACode, UserBasicInfo _User)
        {
            Summary summary = new Summary();

            string summaryCode = await _codeRepo.getGeneratedCode("SUMMARY");
            if (string.IsNullOrEmpty(summaryCode)) throw new Exception("Failed to generate summary code.");
            summary.Dacode = DACode;
            summary.AllocationCode = allocationCode;
            summary.SummaryCode = summaryCode;
            summary.SummaryDate = System.DateTime.Now;
            summary.IsFinalized = true;
            summary.IsActive = true;
            summary.CreatedById = _User.EmployeeID;
            summary.CreatedOn = System.DateTime.Now;
            summary.MachineId = "La Machina";
            summary.ModuleVersion = Core._MODULE_VERSION.SUMMARY;

            return summary;
        }


        private async Task<List<SummaryInvoiceProductBatchWise>> mapAndValidateProductBatchWise(List<SummaryInvoice> invoiceSummary)
        {
            // INVOICE PRODUCT BATCH
            List<InvoiceProductBatchWise> invProductBatch = new List<InvoiceProductBatchWise>();
            foreach (SummaryInvoice tempInvoice in invoiceSummary)
            {
                var _invProductBatch = await _proBatchRepo.getByInvioceCode(tempInvoice.InvoiceCode);
                if (!_invProductBatch.Any()) throw new Exception("Invoice product batch wise not found.");

                invProductBatch.AddRange(_invProductBatch);
            }


            // Initializing product batch to product batch summary
            List<SummaryInvoiceProductBatchWise> productBatch = invProductBatch.AsEnumerable().Select(c => new SummaryInvoiceProductBatchWise
            {
                Id = 0,
                SummaryCode = "",
                InvoiceCode = c.InvoiceCode,
                ProductCode = c.ProductCode,
                BatchNo = c.BatchNo,
                Quantity = c.Quantity,
                ReturnQty = 0,
                SoldQty = c.Quantity, // Initial case we sold every qunatity
                CreatedOn = System.DateTime.Now
            }).ToList();


            return productBatch;
        }


        private SummaryInvoice mapAndValidateInvoiceSummary(AllocationInvoiceForSummaryMasterDto invoiceDto, UserBasicInfo _User)
        {
            SummaryInvoice invSummary = new InvoiceSummaryMap().map(invoiceDto);
            if (invSummary == null) throw new Exception("Invoice Summary not found.");

            invSummary.CreatedById = _User.EmployeeID;
            invSummary.CreatedOn = System.DateTime.Now;
            invSummary.IsActive = true;
            invSummary.MachineId = "La Machina";

            // VALIDATE INVOICE SUMMARY
            ValidationResult result = new InvoiceSummaryValidator().Validate(invSummary);
            if (!result.IsValid) throw new Exception(result.ToString(" ~"));

            return invSummary;
        }


        private List<SummaryInvoiceDetail> mapAndValidateInvoiceDetailSummary(List<SummaryInvoiceDetailDto> detail, UserBasicInfo _User)
        {
            List<SummaryInvoiceDetail> invDetail = new List<SummaryInvoiceDetail>();

            foreach (SummaryInvoiceDetailDto product in detail.ToList())
            {
                SummaryInvoiceDetail productDetail = new InvoiceSummaryMap().mapDetail(product);
                if(productDetail == null) throw new Exception("Invoice Summary product not found.");

                productDetail.Tp = product.TP.GetValueOrDefault();
                productDetail.Sps = product.SPS.GetValueOrDefault();

                productDetail.TotalTp = product.TotalTP.GetValueOrDefault();
                productDetail.TotalVat = product.TotalVAT.GetValueOrDefault();
                productDetail.TotalAmountDiscount = product.AmountDiscount.GetValueOrDefault();
                productDetail.TotalProductDiscount = product.ProductDiscount.GetValueOrDefault();

                productDetail.IsInvoiceDiscountApplicable = product.IsInvoiceAmountDiscountApplicable.GetValueOrDefault();


                productDetail.BonusQty = product.SoldBonusQty.GetValueOrDefault();
                productDetail.SoldQty = product.SoldQuantity.GetValueOrDefault();

                // RETURN QTY = 0 IS INTENTIONAL, UNTIL RETURN PRODUCT RECEIVED BY STORE IN CHARGE 
                productDetail.ReturnQty = 0; ///   product.ReturnWithBonusQuantity.GetValueOrDefault();
                //

                productDetail.Amount = (product.TotalTP.GetValueOrDefault() + product.TotalVAT.GetValueOrDefault()) - (product.ProductDiscount.GetValueOrDefault() + product.AmountDiscount.GetValueOrDefault());
                

                

                productDetail.CreatedById = _User.EmployeeID;
                productDetail.CreatedOn = System.DateTime.Now;
                productDetail.IsActive = true;
                productDetail.MachineId = "La Machina";

                // VALIDATE INVOICE SUMMARY
                ValidationResult result = new InvoiceDetailSummaryValidator().Validate(productDetail);
                if (!result.IsValid) throw new Exception(result.ToString(" ~"));


                invDetail.Add(productDetail);
            }

            return invDetail;
        }


        private async Task<Summary> insertInvoiceSummary(
            Summary summary, 
            List<SummaryInvoice> invSummary, 
            List<SummaryInvoiceDetail> invDetail, 
            List<SummaryInvoiceProductBatchWise> productBatch, 
            SummaryCollection collection,
            List<SummaryCollectionDetail> collectionDetails,
            List<SummaryCollectionInstrument> collectionInstrument,
            bool hasCollection)
        {
            try
            {

                await this._sumRepo.BEGIN_TRANSACTION();

                Summary insertedSummary = new Summary();

                // Check if summary already done.
                Summary existingSummary = await _sumRepo.getSummaryByAllocationCode(summary.AllocationCode);
                if (existingSummary != null) throw new Exception($"Summary already done for Allocation {summary.AllocationCode}. Summary Code: " + existingSummary.SummaryCode);
                

                // SUMMARY 
                insertedSummary = await this._sumRepo.insertSummary(summary);
                if (insertedSummary == null) throw new Exception("Failed to save master.");
                

                // SUMMARY INVOICE
                List<SummaryInvoice> invSum = await this._sumRepo.insertInvoiceSummaryBulk(invSummary);
                if (!invSum.Any()) throw new Exception("Failed to save Summary Invoice.");
       

                // SUMMARY INVOICE DETAIL
                List<SummaryInvoiceDetail> invDetailSum = await this._sumRepo.insertInvoiceDetailSummaryAll(invDetail);
                if (invDetailSum == null || !invDetailSum.Any()) throw new Exception("Failed to save invoice summary products.");
                

                // SUMMARY INVOICE PRODUCT BATCH WISE
                List<SummaryInvoiceProductBatchWise> invProductBatchSum = await this._sumRepo.insertInvoiceProductBatchWiseSummaryAll(productBatch);
                if(!invProductBatchSum.Any()) throw new Exception("Failed to save invoice product batch wise summary.");
                


                // Checking if summary has collection
                if(hasCollection)
                {
                    // SUMMARY COLLECTION
                    SummaryCollection summaryColleciton = await this._sumRepo.insertSummaryCollection(collection);
                    if (summaryColleciton == null) throw new Exception("Failed to save summary collection.");
                    


                    // SUMMARY Collection Detail
                    List<SummaryCollectionDetail> insertedSummaryCollectionDetails = await this._sumRepo.insertSummaryCollecitonDetail(collectionDetails);
                    if (!insertedSummaryCollectionDetails.Any()) throw new Exception("Failed to insert summary collection detail.");
                    


                    // SUMMARY COLLECTION INSTRUMENT
                    if(collectionInstrument.Any())
                    {
                        List<SummaryCollectionInstrument> insertedSummaryCollectionInstrument = await this._sumRepo.insertSummaryCollecitonInstrument(collectionInstrument);
                        if (!insertedSummaryCollectionInstrument.Any()) throw new Exception("Failed to insert summary collection instrument.");
                        
                    }
                }

                await this._sumRepo.COMMIT();
                return insertedSummary;
            }
            catch (Exception ex)
            {
                await this._sumRepo.ROLL_BACK();
                logException(ex);
                this.error = ex;
                return null;
            }
        }


        private async Task<Summary> insertCollectionSummary(
            Summary summary,
            SummaryCollection collection,
            List<SummaryCollectionDetail> collectionDetails,
            List<SummaryCollectionInstrument> collectionInstrument)
        {
            try
            {
                await this._sumRepo.BEGIN_TRANSACTION();

                Summary insertedSummary = new Core.Models.SummaryInvoice.Summary();

                // SUMMARY 
                insertedSummary = await this._sumRepo.insertSummary(summary);
                if (insertedSummary == null)
                {
                    await this._sumRepo.ROLL_BACK();
                    throw new Exception("Failed to save master.");
                }

                // Checking if summary has collection
                // SUMMARY COLLECTION
                SummaryCollection summaryColleciton = await this._sumRepo.insertSummaryCollection(collection);
                if (summaryColleciton == null)
                {
                    await this._sumRepo.ROLL_BACK();
                    throw new Exception("Failed to save summary collection.");
                }


                // SUMMARY Collection Detail
                List<SummaryCollectionDetail> insertedSummaryCollectionDetails = new List<SummaryCollectionDetail>();
                if(collectionDetails.Count > 0)
                {
                    foreach (var item in collectionDetails)
                    {
                        if (item.CashCollectionAmount > 0) item.CollectionType = "CASH";
                        if (item.ChequeCollectionAmount > 0) item.CollectionType = "CHEQUE";

                    }
                }
             
                insertedSummaryCollectionDetails = await this._sumRepo.insertSummaryCollecitonDetail(collectionDetails);
                if (!insertedSummaryCollectionDetails.Any())
                {
                    await this._sumRepo.ROLL_BACK();
                    throw new Exception("Failed to insert summary collection detail.");
                }


                // SUMMARY COLLECTION INSTRUMENT
                if (collectionInstrument.Any())
                {
                    List<SummaryCollectionInstrument> insertedSummaryCollectionInstrument = await this._sumRepo.insertSummaryCollecitonInstrument(collectionInstrument);
                    if (!insertedSummaryCollectionInstrument.Any())
                    {
                        await this._sumRepo.ROLL_BACK();
                        throw new Exception("Failed to insert summary collection instrument.");
                    }
                }

                await this._sumRepo.COMMIT();
                return insertedSummary;
            }
            catch (Exception ex)
            {
                await this._sumRepo.ROLL_BACK();
                logException(ex);
                this.error = ex;
                return null;
            }
        }





        public async Task<List<AllocationInvoiceForSummaryMasterDto>> getAllocationInvoiceForSummary(string AllocationCode)
        {
            List<AllocationInvoiceForSummaryMasterDto> report = new List<AllocationInvoiceForSummaryMasterDto>();

            var invoices =  await repo.getAllocationInvoiceForSummary(AllocationCode);
            if (!invoices.Any()) throw new Exception("Invoice not found using allocation code : " + AllocationCode);


            List<SummaryInvoiceDetailNewDto> SummaryInvoiceDetail = await repo.getSummaryInvoiceDetailForSummary(AllocationCode);
            if (SummaryInvoiceDetail == null || SummaryInvoiceDetail.Count() == 0) throw new Exception("Invoice detail not found using allocation code : " + AllocationCode);

            foreach (var item in invoices)
            {

                AllocationInvoiceForSummaryMasterDto invoice = new AllocationInvoiceForSummaryMasterMap().map(item);
                if (invoice == null) throw new Exception("Failed to map AllocationInvoiceForSummaryMasterDto");


                
                invoice.ReturnStatus = InvoiceReturnType.NONE;
                List<SummaryInvoiceDetailNewDto> invoiceDetail = SummaryInvoiceDetail.Where(p => p.InvoiceCode == invoice.InvoiceCode).ToList();
                if (invoiceDetail == null) continue;

                       
                invoice.InvoiceDetail = new List<SummaryInvoiceDetailDto>();

                foreach(SummaryInvoiceDetailNewDto Detail in invoiceDetail)
                {
                    var detail = new SummaryInvoiceDetailDtoMap().map(Detail);
                    detail.ProductAmount = detail.Amount;
                    detail.BatchNo = Detail.BatchNo;
                    detail.SoldBonusQty = detail.BonusQty.GetValueOrDefault(); 
                    invoice.InvoiceDetail.Add(detail);
                }

                report.Add(invoice);
            }


            return report;
        }

        public async Task<List<InvoiceReturnTypeDto>> getInvoiceReturnType()
        {
            return await repo.getInvoiceReturnType();        
        }

        public async Task<List<SalesInvoiceDateBetweenDto>> getSalesInvoiceDateBetween(string FromDate, string ToDate, string PaymentMode,string Status)
        {
            return await repo.getSalesInvoiceDateBetween(FromDate, ToDate, PaymentMode,Status);
        }

        public async Task<List<SalesInvoiceDateBetweenDto>> getSalesInvoiceByTerritoryORMpo(string FromDate, string ToDate, string Code, string PaymentMode)
        {
           
                return await repo.getSalesInvoiceByTerritoryORMpo(FromDate, ToDate, Code,PaymentMode);
        }


        public async Task<List<SalesInvoiceDateBetweenDto>> getSalesInvoiceByCode(string Code)
        {
            
                return await repo.getSalesInvoiceByCode(Code);
        }


        public async Task<List<SalesInvoiceDateBetweenDto>> getSalesByMPOTerritory(string FromDate, string ToDate, string Code, string PaymentMode)
        {
            
                return await repo.getSalesByMPOTerritory(FromDate, ToDate, Code,PaymentMode);
        }

        public async Task<List<SalesInvoiceDateBetweenDto>> getSalesByCode(string Code)
        {
            
                return await repo.getSalesByCode(Code);     
        }
        public async Task<List<SalesInvoiceDateBetweenDto>> getSalesByArea(string FromDate, string ToDate, string AreaID,string PaymentMode)
        {
                return await repo.getSalesByArea(FromDate, ToDate, AreaID,PaymentMode);   
        }

        public async Task<List<RegionDTO>> getRegionList()
        {

            return await repo.getRegionList();

        }
        public async Task<List<AreaDto>> getArea()
        {

                return await repo.getArea();
           
        }

        public async Task<List<BatchWiseReturnDto>> getBatchWiseReturn(string FromDate, string ToDate)
        {
            
                return await repo.getBatchWiseReturn(FromDate, ToDate);
   
        }

        public async Task<List<ProductWiseReturnDto>> getProductWiseReturn(string FromDate, string ToDate)
        {
           
                return await repo.getProductWiseReturn(FromDate, ToDate);

        }


        // ==================================================================
        // TERRITORY WISE PRODUCT SALES
        // ==================================================================
        public async Task<List<ProductWiseSalesDto>> getTerritoryWiseAllProductSales(string FromDate, string ToDate,string AreaCode)
        {

            return await repo.getTerritoryWiseAllProductSales(FromDate, ToDate, AreaCode);

        }
        public async Task<List<RegionDTO>> getAllAreaCodeByRegion(string RegionCode)
        {

            return await repo.getAllAreaCodeByRegion(RegionCode);

        }
        public async Task<List<TerritoryDTO>> getAllTerritoryCodeByArea(string AreaCode)
        {

            return await repo.getAllTerritoryCodeByArea(AreaCode);

        }
        public async Task<List<ProductWiseSalesMasterDetailDTO>> getProductWiseSales(string FromDate, string ToDate,string AreaCode)
        {
            // Getting All repeated data
            List<ProductWiseSalesMasterDetailDTO> master = await repo.getProductWiseSales(FromDate, ToDate);


            // Getting all non repeated data
            List<ProductWiseSalesDto> detail = await repo.getTerritoryWiseAllProductSales(FromDate, ToDate, AreaCode);

            // mapping and initializing repreated and non repeated data
            master.AsEnumerable().All(c =>
            {
                c.pricelist = new List<ProductWiseSalesDto>();

                c.pricelist.AddRange(detail.AsEnumerable().Where(x => (x.ProductCode == c.ProductCode)).ToList());
                return true;
            });

            return master;

         //   return await repo.getProductWiseReturn(FromDate, ToDate);

        }


        // ==================================================================
        // TERRITORY WISE PRODUCT SALES
        // ==================================================================


        public async Task<List<SalesInvoiceDateBetweenDto>> getSalesDateBetween(string FromDate, string ToDate, string PaymentMode)
        {
            return await repo.getSalesDateBetween(FromDate, ToDate, PaymentMode);
        }

        // ==================================================================
        // SUMMARY INVOICE DETAIL UPDATE & CALCULATION
        // ==================================================================
        public async Task<AllocationInvoiceForSummaryMasterDto> updateSummaryInvoiceForNewSummary(AllocationInvoiceForSummaryMasterDto SummaryInvoice)
        {
            if (SummaryInvoice == null) throw new Exception("Summary Invoice not found");
            SalesInvoiceFormula formula = new SalesInvoiceFormula();


            var returnQuantity = 0;
            Boolean IsPreviousMonthInvoice = false;

            DateTime invoiceDate = SummaryInvoice.InvoiceDate.GetValueOrDefault();
            

            foreach (var product in SummaryInvoice.InvoiceDetail)
            {

                if (string.IsNullOrEmpty(product.ProductCode)) throw new Exception("Product code not found in Invoice Detail.");

                if (SummaryInvoice.ReturnStatus == InvoiceReturnType.FULL)
                {
                    product.ReturnQuantity =  product.InvoiceQty.GetValueOrDefault() + product.BonusQty.GetValueOrDefault();
                }


                // VALIDATING RETURN QTY 
                returnQuantity = product.ReturnQuantity.GetValueOrDefault();
                if (returnQuantity > product.InvoiceQty)
                {
                    product.ReturnQuantity = returnQuantity = product.InvoiceQty.GetValueOrDefault();                    
                }


                //// BONUS PRODUCT FULL RETURN 
                //if(product.ReturnQuantity==product.InvoiceQty)
                //{
                    //product.ReturnWithBonusQuantity = product.InvoiceQty.GetValueOrDefault() + product.BonusQty.GetValueOrDefault();
                //}

                // RETURN BONUS QUANTITY
                //product.ReturnBonusQuantity = product.ReturnQuantity.GetValueOrDefault() - product.InvoiceQty.GetValueOrDefault();

                product.SoldQuantity = product.InvoiceQty - returnQuantity;
                if (product.SoldQuantity <= 0) product.SoldBonusQty = 0;






                product.TotalTP = formula.getTotalTP(product.SoldQuantity.GetValueOrDefault(), product.TP.GetValueOrDefault());
                product.TotalVAT = formula.getTotalVAT(product.SoldQuantity.GetValueOrDefault(), product.Vat.GetValueOrDefault());


                // Ignoring bonus product
                //if (product.BonusQty.GetValueOrDefault() == 0)
                //{
                    // DISCOUNT:: SP -> applyChemistDiscountAndBonus
                    ChemistDiscountAndBonusDto discount = await this.applyChemistDiscountAndBonusForEachProduct(SummaryInvoice.ChemistCode, product.ProductCode, SummaryInvoice.PaymentMode, product.SoldQuantity.GetValueOrDefault(), invoiceDate);
                    if (discount != null)
                    {
                        product.SoldBonusQty = discount.BonusQuantity;
                        product.QuantityAfterBonus = discount.QuantityAfterBonus;

                        product.ProductDiscount = discount.ProductDiscount;
                        product.FacilityAmount = discount.FacilityAmount;
                        product.IsAmountInPercent = discount.IsAmountInPercent;
                        product.DiscountCode = discount.DiscountCode;
                        product.AppliedDiscountRuleNumbers = discount.AppliedDiscountRuleNumbers;
                        product.IsInvoiceAmountDiscountApplicable = discount.IsInvoiceAmountDiscountApplicable;
                        product.BonusSegment = discount.BonusSegment;


                        // RETURN BONUS
                        product.ReturnBonusQuantity = product.BonusQty.GetValueOrDefault() - product.SoldBonusQty.GetValueOrDefault();
                        product.ReturnWithBonusQuantity = product.ReturnQuantity.GetValueOrDefault() + product.ReturnBonusQuantity.GetValueOrDefault();
                    }
                //}

                
            }

            // INVOICE TRADE DISCOUNT
            SummaryInvoice.InvoiceDetail = await this.calculate_INVOICE_TRADE_DISCOUNT(SummaryInvoice.InvoiceDetail);

            return SummaryInvoice;
        }

        // FUNCTION CALLED IN FOREACH LOOP
        public async Task<ChemistDiscountAndBonusDto> applyChemistDiscountAndBonusForEachProduct(string ChemistID, string ProductCode, string PaymentMode, int Quantity, DateTime InvoiceDate)
        {
            var discount = await invRepo.applyChemistDiscountAndBonus(ChemistID, ProductCode, PaymentMode, Quantity, InvoiceDate);
            return discount.FirstOrDefault();
        }

        // ======================================================================================================================================================================
        // INVOICE TRADE DISCOUNT CALCULATION
        // ======================================================================================================================================================================
        public async Task<List<SummaryInvoiceDetailDto>> calculate_INVOICE_TRADE_DISCOUNT(List<SummaryInvoiceDetailDto> invoiceDetail)
        {
            SalesInvoiceFormula formula = new SalesInvoiceFormula();
            foreach (var product in invoiceDetail)
            {
                product.ProductAmount = formula.getNetAmount(product.TotalTP.GetValueOrDefault(), product.TotalVAT.GetValueOrDefault(), product.ProductDiscount.GetValueOrDefault(), product.AmountDiscount.GetValueOrDefault());
            }

            // INVOICE TRADE DISCOUNT
            List<DiscountDetailForInvoiceGeneralDto> invoiceGeneralDiscount = await dRepo.getTradeDiscountDetail();
            if (invoiceGeneralDiscount == null || invoiceGeneralDiscount.Count == 0)
            {
                // MAKE A LOG HERE
                logException(new Exception("INVOICE TRADE DISCOUNT NOT FOUND FOR"));
                logException(new Exception(new DMS.Utility.Library.JSONSerialize().getJSONString(invoiceDetail)));
                return invoiceDetail;
            }


            // INVOICE TOTAL TP
            decimal totalTPForAmountDiscount = invoiceDetail.Where(p => p.IsInvoiceAmountDiscountApplicable == true).Sum(d => (d.TP.GetValueOrDefault() * d.QuantityAfterBonus)).GetValueOrDefault();

            if (totalTPForAmountDiscount <= 0)
            {
                // MAKE A LOG HERE
                logException(new Exception("INVALID INVOICE TOTAL TP"));
                logException(new Exception(new DMS.Utility.Library.JSONSerialize().getJSONString(invoiceDetail)));
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
                logException(new Exception("INVALID INVOICE APPLICABLE DISCOUNT PERCENT"));
                logException(new Exception(new DMS.Utility.Library.JSONSerialize().getJSONString(invoiceDetail)));
                //return invoiceDetail;
            }


            // UPDATE TRADE DISCOUNT
            foreach (var product in invoiceDetail)
            {
                product.AmountDiscount = 0;

                // key field => QuantityAfterBonus, DiscountCode
                // Trade discount is not applicable if any product has other facility.
                if (product.IsInvoiceAmountDiscountApplicable == true && applicableDiscountPercent > 0)
                {
                    product.AmountDiscount = (product.TP * product.QuantityAfterBonus) * (applicableDiscountPercent / 100.0M);
                    product.DiscountCode = tradeDiscountCode;
                }

                product.ProductAmount = formula.getNetAmount(product.TotalTP.GetValueOrDefault(), product.TotalVAT.GetValueOrDefault(), product.ProductDiscount.GetValueOrDefault(), product.AmountDiscount.GetValueOrDefault());

                product.IndividualDiscountPercent = formula.getPercent(product.TotalTP.GetValueOrDefault(), (product.ProductDiscount.GetValueOrDefault() + product.AmountDiscount.GetValueOrDefault()));
                product.ReturnAmount = product.Amount - product.ProductAmount;


                if(product.ReturnAmount < -0.04M)
                {
                    //throw new Exception($"Return Amount ({product.ReturnAmount}) can't be negative value for {product.ProductName}");
                    product.ReturnAmount = 0;
                }
            }

            return invoiceDetail;
        }

        //sales report territory wise
        public async Task<List<MasterSalesTerritoryDto>> getSalesByTerritory(OutstandingDto outstandingDto)
        {
            
            //remove unnecessary caharacter 
            outstandingDto.Code = outstandingDto.Code.TrimStart('"');
            outstandingDto.Code = outstandingDto.Code.TrimEnd('"');
            outstandingDto.Code = outstandingDto.Code.TrimEnd(',');
         //   if (String.IsNullOrEmpty(outstandingDto.Code)) throw new Exception("Select At least One Territory/Area");


            // Getting All repeated data
            List<MasterSalesTerritoryDto> master = await repo.getMasterSalesTerritory(outstandingDto);


            // Getting all non repeated data
            List<SalesInvoiceNewDateBetwwen> detail = await repo.getSalesReportDateBetween(outstandingDto);

            // mapping and initializing repreated and non repeated data
            master.AsEnumerable().All(c =>
            {
                c.salesInvoiceDateBetweenDtos = new List<SalesInvoiceNewDateBetwwen>();

                c.salesInvoiceDateBetweenDtos.AddRange(detail.AsEnumerable().Where(x => (x.TerritoryCode.ToUpper() == c.TerritoryCode.ToUpper() && x.MPOCode.Replace(" ", "") == c.MPOCode && x.PaymentMode == c.PaymentMode)).ToList());
                return true;
            });

            return master;

        }

        private async Task<bool> validateDepotDayOperation()
        {
            var data = await dayRepo.getDepotDayOperationStatus();
            if (data == null) throw new Exception("Failed to load depot day operational data. Please check getDepotDayOperationStatus() ");
            var dayStatus = data.FirstOrDefault();

            // check day is not opened
            if (dayStatus.IsDayOpened == null || dayStatus.IsDayOpened.Value == false) throw new Exception("Day is not open. Please open the day from Administration -> Day Operation");

            // check day closed
            if (dayStatus.IsDayClosed != null && dayStatus.IsDayClosed.Value == true) return false;
            else
            {
                // check invoice date and day open date is same
                DateTime reportDate = Convert.ToDateTime(dayStatus.ReportDate);
                var dayDiff = reportDate.Subtract(DateTime.Now).Days;
                if (dayDiff != 0)
                {
                    throw new Exception($"Summary date [{DateTime.Now.ToString("dd MMM yyyy")}] is not same depot opening date [{reportDate.ToString("dd MMM yyyy")}]");
                }
                return true;
            }
        }



        public async Task<List<UnadjustedCreditNoteListDto>> getUnadjustedCreditNoteList()
        {
                return await _sumRepo.getUnadjustedCreditNoteList();

        }


    }
}
