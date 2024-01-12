
using DMS.Core.Dto.User;
using DMS.Core.DTO.SalesInvoice;
using DMS.Core.Models.SalesInvoice;
using DMS.Core.Models.SummaryInvoice;
using DMS.Data.Repository;
using DMS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Services.SalesInvoice
{
    public class InvoiceSummaryService : LoggerService, IInvoiceSummaryService
    {
        private readonly InvoiceSummaryRepository _sumRepo = null;
        private readonly InvoiceRepository _invoRepo = null;
        private readonly CodeGenerateRepository _codeRepo = null;
        private readonly InvoiceProductBatchWiseRepository _proBatchRepo = null;

        private readonly DbContext context = null;
        private readonly DbContext _invoContext = null;

        public InvoiceSummaryService(IConfiguration Config)
        {
            this.context = new SummaryInvoiceContext(Config);
            this._invoContext = new InvoiceContext(Config);

            this._sumRepo = new InvoiceSummaryRepository(this.context);
            this._codeRepo = new CodeGenerateRepository(this._invoContext);
            this._proBatchRepo = new InvoiceProductBatchWiseRepository(this._invoContext);
        }

        // will be removed
        public async Task<List<SummaryPendingInvoiceAllocationDto>> getSummaryPendingInvoiceAllocaiton()
        {
            return await _sumRepo.getSummaryPendingInvoiceAllocaiton();
        }

        public async Task<List<SummaryPendingInvoiceAllocationDto>> getAllocationForSummaryReturn()
        {
            return await _sumRepo.getAllocationForSummaryReturn();
        }

        public async Task<List<SummaryPendingInvoiceAllocationDetailDto>> getSummaryPendingInvoiceAllocaitonDetail(string allocationCode)
        {
            return await _sumRepo.getSummaryPendingInvoiceAllocaitonDetail(allocationCode);
        }

        public async Task<List<InvoiceDetailSummaryDto>> getSummaryPendingAllocaitonInvoiceProductDetail(string invoiceCode)
        {
            return await _sumRepo.getSummaryPendingAllocaitonInvoiceProductDetail(invoiceCode); ;
        }

        //public async Task<string> saveInvoiceSummary(SummaryDto summaryDto, UserBasicInfo _User)
        //{

        //    // Decalring Variables
        //    List<SummaryInvoiceDetail> invoiceDetailSummary = new List<SummaryInvoiceDetail>();
        //    List<SummaryInvoice> invoiceSummary = new List<SummaryInvoice>();
        //    List<SummaryInvoiceProductBatchWise> productBatch = new List<SummaryInvoiceProductBatchWise>();
        //    Summary insertedSummary = new Summary();

        //    // Checking if allocation code exists.
        //    string allocationCode = summaryDto.Allocation.AllocationCode;
        //    if (string.IsNullOrEmpty(allocationCode)) throw new Exception("Allocation code not found.");

        //    // CHECK IF INVOICE ALLOCATION SUMMARY EXISTS
        //    Summary existingSummaryByAllocationCode = await _sumRepo.getSummaryByAllocationCode(allocationCode);
        //    bool isSummaryExists = existingSummaryByAllocationCode == null ? false : true;



        //    // If Allocation summary is new and no return is in summary
        //    if (!isSummaryExists && !summaryDto.Invoice.Any() && !summaryDto.InvoiceDetail.Any())
        //    {
        //        List<SummaryPendingInvoiceAllocationDetailDto> allInvoice = await this._sumRepo.getSummaryPendingInvoiceAllocaitonDetail(allocationCode);
        //        var invSummary = mapAndValidateInvoiceSummary(allInvoice, _User);
        //        if (!invSummary.Any()) throw new Exception("No Invoice found. try again.");
        //        invoiceSummary.AddRange(invSummary);

        //        // MAP AND Validate invoice detail who has no return
        //        List<InvoiceDetailSummaryDto> invDetailSummary = new List<InvoiceDetailSummaryDto>();
        //        foreach (SummaryPendingInvoiceAllocationDetailDto inv in allInvoice)
        //        {
        //            var invDetail = await this._sumRepo.getSummaryPendingAllocaitonInvoiceProductDetail(inv.InvoiceCode);
        //            if (!invDetail.Any()) throw new Exception("No Invoice found. Try again.");

        //            invDetailSummary.AddRange(invDetail);
        //        }


        //        List<SummaryInvoiceDetail> invDetailSummaryMapped = mapAndValidateInvoiceDetailSummary(invDetailSummary, _User);
        //        if (!invDetailSummaryMapped.Any()) throw new Exception("Invoice Detail Summary not found.");
        //        invoiceDetailSummary.AddRange(invDetailSummaryMapped);


        //        // INVOICE PRODUCT BATCH
        //        List<InvoiceProductBatchWise> invProductBatch = new List<InvoiceProductBatchWise>();
        //        foreach (SummaryInvoice tempInvoice in invoiceSummary)
        //        {
        //            var _invProductBatch = await _proBatchRepo.getByInvioceCode(tempInvoice.InvoiceCode);
        //            if (!_invProductBatch.Any()) throw new Exception("Invoice product batch wise not found.");

        //            invProductBatch.AddRange(_invProductBatch);
        //        }


        //        // Initializing product batch to product batch summary
        //        productBatch = invProductBatch.AsEnumerable().Select(c => new SummaryInvoiceProductBatchWise
        //        {
        //            Id = 0,
        //            SummaryCode = "",
        //            InvoiceCode = c.InvoiceCode,
        //            ProductCode = c.ProductCode,
        //            BatchNo = c.BatchNo,
        //            Quantity = c.Quantity,
        //            ReturnQty = 0,
        //            SoldQty = c.Quantity, // Initial case we sold every qunatity
        //            CreatedOn = System.DateTime.Now
        //        }).ToList();


        //        insertedSummary = await getAllocaitonSummary(allocationCode, _User);
        //        if (insertedSummary == null) throw new Exception("Invoice Summary not found.");


        //        // inserting new allocation by summary code
        //        //var insertedSummaryList = await this._sumRepo.insertAllocationSummary(allocationCode, _User.EmployeeID, "La Machina");
        //        //insertedSummary = insertedSummaryList.FirstOrDefault();
        //        //return insertedSummary.SummaryCode;
        //    }

        //    // If Allocation summary is new and has return in some invoice;
        //    else if (!isSummaryExists && summaryDto.Invoice.Any() && summaryDto.InvoiceDetail.Any())
        //    {
        //        // MAP AND VALIDATE INVOICE SUMMARY
        //        var invSummary = mapAndValidateInvoiceSummary(summaryDto.Invoice, _User);
        //        if(!invSummary.Any()) throw new Exception("No Invoice found. try again.");
        //        invoiceSummary.AddRange(invSummary);


        //        // MAP AND VALIDATE INVOICE PRODUCT DETAIL SUMMARY
        //        List<SummaryInvoiceDetail> invDetailSummary = mapAndValidateInvoiceDetailSummary(summaryDto.InvoiceDetail, _User);
        //        if(!invDetailSummary.Any()) throw new Exception("Invoice Detail Summary not found.");
        //        invoiceDetailSummary.AddRange(invDetailSummary);



        //        List<SummaryPendingInvoiceAllocationDetailDto> allInvoice = await this._sumRepo.getSummaryPendingInvoiceAllocaitonDetail(allocationCode);
        //        //filtering invoice from
        //        List<SummaryPendingInvoiceAllocationDetailDto> invoiceWhomHasZeroReturn = allInvoice.Where(i => !invSummary.Any(x => x.InvoiceCode == i.InvoiceCode)).Select(i => i).ToList();
        //        // Check if invoice whom has zero return exists.

        //        // Other invoice who have no return
        //        if (invoiceWhomHasZeroReturn.Any())
        //        {
        //            // MAP AND Validate Invoice who has no return
        //            var invSummaryZeroReturn = mapAndValidateInvoiceSummary(invoiceWhomHasZeroReturn, _User);
        //            if (!invSummaryZeroReturn.Any()) throw new Exception("No Invoice found. try again.");
        //            invSummaryZeroReturn.All(c => { c.ReturnType = "NONE"; return true; });
        //            invoiceSummary.AddRange(invSummaryZeroReturn);

        //            // MAP AND Validate invoice detail who has no return
        //            List<InvoiceDetailSummaryDto> invDetailZeroReturnSummary = new List<InvoiceDetailSummaryDto>();
        //            foreach (SummaryPendingInvoiceAllocationDetailDto inv in invoiceWhomHasZeroReturn)
        //            {
        //                var invDetailZeroReturn = await this._sumRepo.getSummaryPendingAllocaitonInvoiceProductDetail(inv.InvoiceCode);
        //                if (!invDetailZeroReturn.Any()) throw new Exception("No Invoice found. Try again.");

        //                invDetailZeroReturnSummary.AddRange(invDetailZeroReturn);
        //            }


        //            List<SummaryInvoiceDetail> invDetailSummaryHasZeroReturn = mapAndValidateInvoiceDetailSummary(invDetailZeroReturnSummary, _User);
        //            if (!invDetailSummaryHasZeroReturn.Any()) throw new Exception("Invoice Detail Summary not found.");
        //            invoiceDetailSummary.AddRange(invDetailSummaryHasZeroReturn);
        //        }


        //        // INVOICE PRODUCT BATCH
        //        List<InvoiceProductBatchWise> invProductBatch = new List<InvoiceProductBatchWise>();
        //        foreach(SummaryInvoice tempInvoice in invoiceSummary)
        //        {
        //            var _invProductBatch = await _proBatchRepo.getByInvioceCode(tempInvoice.InvoiceCode);
        //            if (!_invProductBatch.Any()) throw new Exception("Invoice product batch wise not found.");

        //            invProductBatch.AddRange(_invProductBatch);
        //        }


        //        // Initializing product batch to product batch summary
        //         productBatch = invProductBatch.AsEnumerable().Select(c => new SummaryInvoiceProductBatchWise
        //            {
        //                Id = 0,
        //                SummaryCode = "",
        //                InvoiceCode = c.InvoiceCode,
        //                ProductCode = c.ProductCode,
        //                BatchNo = c.BatchNo,
        //                Quantity = c.Quantity,
        //                ReturnQty = 0,
        //                SoldQty = c.Quantity, // Initial case we sold every qunatity
        //                CreatedOn = System.DateTime.Now
        //            }).ToList();


        //        insertedSummary = await getAllocaitonSummary(allocationCode, _User);
        //        if(insertedSummary == null) throw new Exception("Invoice Summary not found.");

        //    }
        //    else if (isSummaryExists && !summaryDto.Invoice.Any() && !summaryDto.InvoiceDetail.Any())
        //    {
        //        if (summaryDto.IsSaveAndLockSummary)
        //        {
        //            Summary lockedSummary = await finalizeAllocationSummary(summaryDto.Allocation.AllocationCode);
        //            return lockedSummary.SummaryCode;
        //        }
        //        else
        //        {
        //            throw new Exception("Allocation Summary already created.");
        //        }
        //    }
        //    else if (isSummaryExists && summaryDto.Invoice.Any() && summaryDto.InvoiceDetail.Any())
        //    {
        //        // MAP AND VALIDATE INVOICE SUMMARY
        //        var invSummary = mapAndValidateInvoiceSummary(summaryDto.Invoice, _User);
        //        if (!invSummary.Any()) throw new Exception("No Invoice found. try again.");
        //        invoiceSummary.AddRange(invSummary);


        //        // MAP AND VALIDATE INVOICE PRODUCT DETAIL SUMMARY
        //        List<SummaryInvoiceDetail> invDetailSummary = mapAndValidateInvoiceDetailSummary(summaryDto.InvoiceDetail, _User);
        //        if (!invDetailSummary.Any()) throw new Exception("Invoice Detail Summary not found.");
        //        invoiceDetailSummary.AddRange(invDetailSummary);

        //        //UPDATE to inactive all previous invoice
        //        foreach (SummaryInvoice tempInvoice in invoiceSummary)
        //        {
        //            var result = await _sumRepo.updateInvoiceSummary(tempInvoice.InvoiceCode);
        //            var detailResult = await _sumRepo.updateInvoiceDetailSummary(tempInvoice.InvoiceCode);
        //        }

        //        insertedSummary = existingSummaryByAllocationCode;
        //        if (string.IsNullOrEmpty(insertedSummary.SummaryCode)) throw new Exception("Failed to get summary code.");
        //    }



        //    // Updating summary code to invoice detail summary
        //    invoiceDetailSummary.All(c => { c.SummaryCode = insertedSummary.SummaryCode; return true; });
        //    invoiceSummary.All(c => { c.SummaryCode = insertedSummary.SummaryCode; return true; });
        //    if(productBatch.Any() && !isSummaryExists) productBatch.All(c => { c.SummaryCode = insertedSummary.SummaryCode; return true; });


        //    // Inserted invoice summary
        //    Summary newInvoiceSummary = await insertInvoiceSummary(insertedSummary, invoiceSummary, invoiceDetailSummary, productBatch, isSummaryExists, summaryDto.IsSaveAndLockSummary);

        //    return newInvoiceSummary.SummaryCode; 
        //}


        //private async Task<Summary> getAllocaitonSummary(string allocationCode, UserBasicInfo _User)
        //{
        //    Summary summary = new Summary();

        //    string summaryCode = await _codeRepo.getGeneratedCode("SUMMARY");
        //    if (string.IsNullOrEmpty(summaryCode)) throw new Exception("Failed to generate summary code.");

        //    summary.AllocationCode = allocationCode;
        //    summary.SummaryCode = summaryCode;
        //    summary.SummaryDate = System.DateTime.Now;
        //    summary.IsActive = true;
        //    summary.CreatedById = _User.EmployeeID;
        //    summary.CreatedOn = System.DateTime.Now;
        //    summary.MachineId = "La Machina";
        //    summary.ModuleVersion = Core._MODULE_VERSION.SUMMARY;

        //    return summary;
        //}

        //private List<SummaryInvoice> mapAndValidateInvoiceSummary(List<SummaryPendingInvoiceAllocationDetailDto> invoiceDto, UserBasicInfo _User)
        //{
        //    List<SummaryInvoice> invoiceSummary = new List<SummaryInvoice>();
            
            
        //    foreach(SummaryPendingInvoiceAllocationDetailDto invoice in invoiceDto)
        //    {
        //        SummaryInvoice invSummary = new InvoiceSummaryMap().map(invoice);
        //        if (invSummary == null) throw new Exception("Invoice Summary not found.");

        //        invSummary.CreatedById = _User.EmployeeID;
        //        invSummary.CreatedOn = System.DateTime.Now;
        //        invSummary.IsActive = true;
        //        invSummary.MachineId = "La Machina";

        //        // VALIDATE INVOICE SUMMARY
        //        ValidationResult result = new InvoiceSummaryValidator().Validate(invSummary);
        //        if (!result.IsValid) throw new Exception(result.ToString(" ~"));

        //        invoiceSummary.Add(invSummary);
        //    }

        //    return invoiceSummary;
        //}


        //private List<SummaryInvoiceDetail> mapAndValidateInvoiceDetailSummary(List<InvoiceDetailSummaryDto> detail, UserBasicInfo _User)
        //{
        //    List<SummaryInvoiceDetail> invDetail = new List<SummaryInvoiceDetail>();

        //    foreach(InvoiceDetailSummaryDto product in detail.ToList())
        //    {
        //        SummaryInvoiceDetail productDetail = new InvoiceSummaryMap().mapDetail(product);
        //        if (productDetail == null) throw new Exception("Invoice Summary product not found.");

        //        productDetail.ReturnQty = 0; // Till Return product to SIC return quantity wolud be 0.
        //        productDetail.CreatedById = _User.EmployeeID;
        //        productDetail.CreatedOn = System.DateTime.Now;
        //        productDetail.IsActive = true;
        //        productDetail.MachineId = "La Machina";

        //        // VALIDATE INVOICE SUMMARY
        //        ValidationResult result = new InvoiceDetailSummaryValidator().Validate(productDetail);
        //        if (!result.IsValid) throw new Exception(result.ToString(" ~"));


        //        invDetail.Add(productDetail);
        //    }

        //    return invDetail;
        //}


        private async Task<Summary> insertInvoiceSummary(Summary summary, List<SummaryInvoice> invSummary, List<SummaryInvoiceDetail> invDetail, List<SummaryInvoiceProductBatchWise> productBatch, bool isSummaryExists, bool isSaveAndLockSummary)
        {
            try
            {
                await this._sumRepo.BEGIN_TRANSACTION();

                Summary insertedSummary = new Core.Models.SummaryInvoice.Summary();

                // SUMMARY 
                if (!isSummaryExists)
                {
                    insertedSummary = await this._sumRepo.insertSummary(summary);
                    if (insertedSummary == null)
                    {
                        await this._sumRepo.ROLL_BACK();
                        throw new Exception("Failed to save master.");
                    }
                }

                // SUMMARY INVOICE
                List<SummaryInvoice> invSum = await this._sumRepo.insertInvoiceSummaryBulk(invSummary);
                if (!invSum.Any())
                {
                    await this._sumRepo.ROLL_BACK();
                    throw new Exception("Failed to save Summary Invoice.");
                }

                // INVOICE Summary PRODUCT
                List<SummaryInvoiceDetail> invDetailSum = await this._sumRepo.insertInvoiceDetailSummaryAll(invDetail);
                if (invDetailSum == null || !invDetailSum.Any())
                {
                    await this._sumRepo.ROLL_BACK();
                    throw new Exception("Failed to save invoice summary products.");
                }

                // INVOICE PRODUCT BATCH WISE SUMMARY
                if (!isSummaryExists)
                {
                    List<SummaryInvoiceProductBatchWise> invProductBatchSum = await this._sumRepo.insertInvoiceProductBatchWiseSummaryAll(productBatch);
                    if (invProductBatchSum == null || invProductBatchSum.Count == 0)
                    {
                        await this._sumRepo.ROLL_BACK();
                        throw new Exception("Failed to save invoice product batch wise summary.");
                    }
                }

                if (isSaveAndLockSummary)
                {
                    Summary lockedSummary = await finalizeAllocationSummary(isSummaryExists ? summary.AllocationCode : insertedSummary.AllocationCode);
                    insertedSummary = lockedSummary;
                }

                await this._sumRepo.COMMIT();
                return isSummaryExists ? summary : insertedSummary;
            }
            catch (Exception ex)
            {
                await this._sumRepo.ROLL_BACK();
                logException(ex);
                return null;
            }  
        }

        public async Task<List<ProductReceivePendingSummary>> getProductReceivePendingSummary()
        {
            return await this._sumRepo.getProductReceivePendingSummary();
        }


        public async Task<List<ProductReceivePendingSummaryDetail>> getProductReceivePendingSummaryDetail(string SummaryCode, string AllocationCode, string InvoiceCode)
        {
            List<ProductReceivePendingSummaryDetail> invoiceProduct = await this._sumRepo.getProductReceivePendingSummaryDetail(SummaryCode, AllocationCode, InvoiceCode);

            foreach(ProductReceivePendingSummaryDetail product in invoiceProduct)
            {
                List<SummaryInvoiceProductBatchWise> productBatch = await this._sumRepo.getInvoiceProductBatchWiseSummary(product.SummaryCode, product.InvoiceCode, product.ProductCode);
                if(!productBatch.Any()) throw new Exception("Product batch not found. Please try again.");

                product.ProductBatch = new List<SummaryInvoiceProductBatchWise>();
                product.ProductBatch.AddRange(productBatch);
            }

            return invoiceProduct.OrderBy(p=> p.ProductName).ToList();
        }



        /// Updated by: Mehedi Hasan, on: 02 May 23
        public async Task<SummaryInvoice> receiveBatchProduct(List<ProductReceivePendingSummaryDetail> receive, UserBasicInfo _User)
        {
            if(!receive.Any()) throw new Exception("No receive product detail found. Please refresh or login again. [List<ProductReceivePendingSummaryDetail> -> receive] ");

            if(_User == null)
            {
                throw new Exception($"User basic info not found. Please refresh or login again. [UserBasicInfo -> _User]");
            }


            await this._sumRepo.BEGIN_TRANSACTION();

            foreach(ProductReceivePendingSummaryDetail item in receive)
            {
                // Get Invoice Detail Summary
                SummaryInvoiceDetail invDetailSummary = await this._sumRepo.getInvoiceDetailSummary(item.SummaryCode, item.InvoiceCode, item.ProductCode);
                if(invDetailSummary == null)
                {
                    await this._sumRepo.ROLL_BACK();
                    throw new Exception($"Invoice Detail Summary not found. Summary Code:{item.SummaryCode}, Invoice Code: ${item.InvoiceCode}, Product Code: ${item.ProductCode}");
                }


                invDetailSummary.ReturnQty = item.ReturnQty.GetValueOrDefault();
                invDetailSummary.UpdatedById = _User.EmployeeID;
                invDetailSummary.UpdatedOn = DateTime.Now;

                SummaryInvoiceDetail updatedInvoiceDetailSummary = await this._sumRepo.updateInvoiceDetailSummaryReturnQty(invDetailSummary);
                if(updatedInvoiceDetailSummary == null)
                {
                    await this._sumRepo.ROLL_BACK();
                    throw new Exception("Product Return Failed. Please try again.");
                }

                foreach (SummaryInvoiceProductBatchWise batch in item.ProductBatch)
                {
                    SummaryInvoiceProductBatchWise invBatch = await this._sumRepo.updateInvoiceProductBatchSummary(batch);
                    if (invBatch == null)
                    {
                        await this._sumRepo.ROLL_BACK();
                        throw new Exception("Product Return Failed. Please try again.");
                    }
                }
            }

            await this._sumRepo.COMMIT();

            try
            {
                await _sumRepo.updateDepotSoldAvailableStock();
            }
            catch { }

            return await this._sumRepo.getInvoiceSummary(receive[0].SummaryCode, receive[0].InvoiceCode);
        }

        public async Task<Summary> finalizeAllocationSummary(string AllocationCode)
        {
            // Get Summary By Allocation Code.
            Summary summary = await this._sumRepo.getSummaryByAllocationCode(AllocationCode);
            summary.IsFinalized = true;

            // get Updated Summary 
            Summary updatedSummary = await this._sumRepo.updateSummary(summary);
            return updatedSummary;
        }
        public async Task<List<AITDocumentReceiveStatusDTO>> getReceivedAITDocument()
        {
            return await _sumRepo.getReceivedAITDocument();
        }
        public async Task<List<AITDocumentReceiveStatusDTO>> getReceivePendingAITDocument()
        {
            return await _sumRepo.getReceivePendingAITDocument();
        }
    }
}
