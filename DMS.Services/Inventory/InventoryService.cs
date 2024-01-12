using DMS.Core.Dto.User;
using DMS.Core.DTO.DepotInventory;
using DMS.Core.DTO.Inventory;
using DMS.Core.DTO.Inventory.BatchReconcilationReportDetails;
using DMS.Core.Models.Inventory;
using DMS.Core.Models.SalesInvoice;
using DMS.Data.Repository;
using DMS.Services.Interfaces;
using DMS.Services.Map.Inventory;
using DMS.Services.Validation.Inventory;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Inventory
{
    public class InventoryService : LoggerService, IInventoryService
    {
        private readonly InventoryRepository _invRepo = null;
        private readonly StockIssueRepository _issueRepo = null;
        private readonly StockReceiveRepository _receiveRepo = null;

        private readonly StockIssueDetailRepository _issueDetailRepo = null;
        private readonly DbContext context = null;
        private readonly DbContext invContext = null;
        private readonly CodeGenerateRepository codeRepo = null;

        public Exception Error { get; set; }

        public InventoryService(IConfiguration Config)
        {
            this.invContext = new InvoiceContext(Config);
            this.codeRepo = new CodeGenerateRepository(this.invContext);

            this.context = new InventoryContext(Config);

            this._invRepo = new InventoryRepository(this.context);
            this._issueRepo = new StockIssueRepository(this.context);
            this._issueDetailRepo = new StockIssueDetailRepository(this.context);
            this._receiveRepo = new StockReceiveRepository(this.context);
        }

        public async Task<List<DepotLocation>> getDepotLocaiton(string IssueType)
        {
            List<DepotLocation> locations = await _invRepo.getDepotLocaiton(IssueType);
            //return locations.Where(i => i.IsCurrent == false).ToList();
            return locations.ToList();
        }

        public async Task<List<ProductWithStock>> getProductWithStock(Boolean ShortStockOnly = false)
        {
            return await _invRepo.getProductWithStock(ShortStockOnly);
        }


        // Receive Depot Challan
        public async Task<object> saveDepotChallan(ChallanReceivePendingDto challanDto, UserBasicInfo _User)
        {
            List<StockReceive> receivedChallan = new List<StockReceive>();
            string message = "";


            foreach (StockReceivePendingChallanDto challan in challanDto.Challan)
            {
                // Check if Challan is already received.
                StockReceive stockReceive= await _invRepo.getStockReceiveByChallanCode(challan.ChallanCode);
                if (stockReceive != null)
                {
                    message += $"Challan is already received. Challan Code: {challan.ChallanCode}, Received Code: {stockReceive.ReceiveCode}";
                    continue;
                }

                StockReceive stReceive = await mapAndValidateStockReceive(challan, _User);
                if (stReceive == null) throw new Exception("Failed to map and validate Stock Receive.");

                List<StockReceiveDetail> details = mapAndValidateStockReceiveDetail(challanDto.ChallanDetails.Where(i => i.ChallanCode == challan.ChallanCode).ToList(), _User);
                if(!details.Any()) throw new Exception("Failed to map and validate Stock Receive detail.");

                details.All(i => { i.ReceiveCode = stReceive.ReceiveCode; return true; });

                StockReceive insertedStockReceive = await InsertStockReceive(stReceive, details);
                if (insertedStockReceive == null) continue;

                receivedChallan.Add(insertedStockReceive);
            }

            if (!receivedChallan.Any()) throw new Exception("Failed to receive challan. Received Challan is empty." + message);

            return challanDto.Challan.Where(i => receivedChallan.Select(x => x.ChallanCode).ToList().Contains( i.ChallanCode));
        }

        private async Task<StockReceive> mapAndValidateStockReceive(StockReceivePendingChallanDto challan, UserBasicInfo user)
        {
            StockReceive stReceive = new StockReceiveMap().mapChallanReceive(challan);

            stReceive.ReceiveCode = await codeRepo.getGeneratedCode("RECEIVE");

            stReceive.ReceiveType = "T";

            stReceive.ApprovedByCode = challan.ChallanApprovedByCode;
            stReceive.ChallanApprovedByName = challan.ChallanApprovedByName;
            stReceive.ApprovalRemarks = challan.ApprovalRemarks;

            stReceive.ReceiveDate = System.DateTime.Now;
            stReceive.ToWarehouse = challan.IssueTo;
            stReceive.FromWarehouse = challan.IssueFrom;

            stReceive.DepotCode = user.DepotCode;
            stReceive.MachineId = "La Machina";

            stReceive.IsActive = true;
            stReceive.CreatedOn = System.DateTime.Now; 
            stReceive.CreatedById = user.EmployeeID;

            ValidationResult result = new DepotReceiveValidator().Validate(stReceive);
            if (!result.IsValid) throw new Exception(result.ToString(" ~"));

            return stReceive;
        }


        private List<StockReceiveDetail> mapAndValidateStockReceiveDetail(List<StockReceiveDetailPendingChallanDto> detailDto, UserBasicInfo _User)
        {
            List<StockReceiveDetail> details = new List<StockReceiveDetail>();

            foreach(StockReceiveDetailPendingChallanDto product in detailDto)
            {
                StockReceiveDetail productDetail = new StockReceiveDetail();

                productDetail.BatchNo = product.BatchNo;
                productDetail.ProductCode = product.ProductCode;
                productDetail.Quantity = Convert.ToInt32(product.Quantity.GetValueOrDefault());
                productDetail.ManufacturingDate = product.ManufacturingDate.GetValueOrDefault();
                productDetail.ExpiryDate = product.ExpiryDate.GetValueOrDefault();

                productDetail.IsActive = true;
                productDetail.CreatedOn = System.DateTime.Now;
                productDetail.CreatedById = _User.EmployeeID;
                productDetail.MachineId = "La Machina";

                details.Add(productDetail);
            }

            return details;
        }

        private async Task<StockReceive> InsertStockReceive(StockReceive receive, List<StockReceiveDetail> detail)
        {
            await _invRepo.BEGIN_TRANSACTION();

            StockReceive insertedStock = await _invRepo.saveStockReceive(receive);
            if(insertedStock == null)
            {
                await _invRepo.ROLL_BACK();
                throw new Exception("Failed To Save Stock Receive.");
            }

            List<StockReceiveDetail> insertedDetail = await _invRepo.saveStockReceive(detail);
            if (!insertedDetail.Any())
            {
                await _invRepo.ROLL_BACK();
                throw new Exception("Failed To Save Stock Receive.");
            }

            await _invRepo.COMMIT();
            return insertedStock;
        }

        public async Task<StockIssue> saveDepotIssue(DepotIssue issueDto, UserBasicInfo _User)
        {
            // Maping Stock Issue
            StockIssue issue = mapAndValidateStockIssue(issueDto.IssueDto, _User);
            if (issue == null) throw new Exception("Failed to map.Please try again");

            // Getting IssueCode 
            string issueCode  = await this.codeRepo.getGeneratedCode("ISSUE"); // Invoice Code
            if (string.IsNullOrEmpty(issueCode) || string.IsNullOrWhiteSpace(issueCode)) throw new Exception("Failed to generate invoice code.");

            // Get batch wise Product
            List<StockIssueDetail> detail = await mapAndValidateStockIssueDetail(issueDto.IssueDetailDto, _User, issueCode);
            if (!detail.Any()) throw new Exception("Failed to map issue detail. Please try again.");

            issue.IssueCode = issueCode;
            StockIssue depotIssue = await insertDepotIssue(issue, detail);
            
            // Updating available stock
            await _invRepo.updateDepotIssueAvailableStock();

            return depotIssue; 
        }


        private StockIssue mapAndValidateStockIssue(DepotIssueDto issueDto, UserBasicInfo _User)
        {
            // Maping Stock Issue
            StockIssue stockIssue = new DepotIssueMap().map(issueDto);
            if (stockIssue == null) throw new Exception("Failed to map.Please try again");

            stockIssue.FromWarehouse = _User.DepotCode; // DepotCode
            stockIssue.DepotCode = _User.DepotCode; // DepotCode
            stockIssue.CreatedById = _User.EmployeeID;
            stockIssue.CreatedOn = System.DateTime.Now;
            stockIssue.IsActive = true;
            stockIssue.MachineId = "La Machina";
            stockIssue.ModuleVersion = Core._MODULE_VERSION.INVENTORY;


            ValidationResult result = new DepotIssueValidator().Validate(stockIssue);
            if (!result.IsValid) throw new Exception(result.ToString(" ~"));

            return stockIssue;
        }


        private async Task<List<StockIssueDetail>> mapAndValidateStockIssueDetail(List<DepotIssueDetailDto> depotIssue, UserBasicInfo _User, string issueCode)
        {
            List<StockIssueDetail> issueDetails = new List<StockIssueDetail>();

            //await _invRepo.updateDepotAvailableStock();
            // Getting Current stock
            //List<ProductBatchStockForInvoice> batchStock = await _invRepo.getCurrentStock();
            //if(!batchStock.Any()) throw new Exception($"Stock Not Found. Contact (IT) Administrator");

            foreach (DepotIssueDetailDto detail in depotIssue)
            {
                StockIssueDetail invProductbatch = new DepotIssueMap().mapDetail(detail);

                invProductbatch.IssueCode = issueCode;
                invProductbatch.CreatedById = _User.EmployeeID;
                invProductbatch.CreatedOn = System.DateTime.Now;
                invProductbatch.IsActive = true;
                invProductbatch.MachineId = "La Machina";

                // Validating issue detail
                ValidationResult result = new DepotIssueDetailValidator().Validate(invProductbatch);
                if (!result.IsValid) throw new Exception(result.ToString(" ~"));

                // Assigning Product Batch to list
                issueDetails.Add(invProductbatch);


                //int issuedQty = detail.Quantity.GetValueOrDefault();
                //int stockQty = batchStock.Where(i => i.ProductCode == detail.ProductCode).Sum(i => i.StockQty);

                // Checking if stock is out of order
                //if (issuedQty > stockQty) throw new Exception($"Out Of Stock {detail.ProductName} Issue Quantity : {issuedQty} Stock Quantity {stockQty}");

                //while (issuedQty > 0)
                //{
                //    StockIssueDetail invProductbatch = new DepotIssueMap().mapDetail(detail);

                //    //Getting Individual batch
                //    ProductBatchStockForInvoice batch = batchStock.Where(i => i.ProductCode == detail.ProductCode && i.StockQty > 0).OrderBy(j => j.BatchNo).ToList().FirstOrDefault();
                //    if (batch == null) throw new Exception($"Product Stock Not Found. Contact (IT) Administrator");

                //    // Checking if Batch Quantity is greater than or equal remaining quantity
                //    if (batch.StockQty >= issuedQty)
                //    {
                //        invProductbatch.Quantity = issuedQty;
                //        batch.StockQty = batch.StockQty - issuedQty;

                //        issuedQty = 0;
                //    }
                //    else
                //    {
                //        invProductbatch.Quantity = batch.StockQty;
                //        issuedQty = issuedQty - batch.StockQty;

                //        batch.StockQty = 0;
                //    }

                //    if (batch.StockQty < 0)
                //        throw new Exception($"Stock Negative Error. {detail.ProductCode} - {detail.ProductName}  For BatchNo :{batch.BatchNo}. Contact (IT) Administrator");


                //    invProductbatch.IssueCode = issueCode;
                //    invProductbatch.ProductCode = detail.ProductCode;
                //    invProductbatch.BatchNo = batch.BatchNo;
                //    invProductbatch.CreatedById = _User.EmployeeID;
                //    invProductbatch.CreatedOn = System.DateTime.Now;
                //    invProductbatch.IsActive = true;
                //    invProductbatch.MachineId = "La Machina";

                //    // Validating issue detail
                //    ValidationResult result = new DepotIssueDetailValidator().Validate(invProductbatch);
                //    if (!result.IsValid) throw new Exception(result.ToString(" ~"));

                //    // Assigning Product Batch to list
                //    issueDetails.Add(invProductbatch);
                //}

            }

            return issueDetails;
        }


        private async Task<StockIssue> insertDepotIssue(StockIssue issue, List<StockIssueDetail> detail)
        {
            try
            {
                await this._invRepo.BEGIN_TRANSACTION();

                // Stock Issue
                StockIssue savedIssue = await this._issueRepo.save(issue);
                if (savedIssue == null)
                {
                    await this._invRepo.ROLL_BACK();
                    throw new Exception("Failed to save master.");
                }

                // INVOICE DETAIL
                List<StockIssueDetail> invDetail = await this._issueDetailRepo.saveBulk(detail);
                if (!invDetail.Any())
                {
                    await this._invRepo.ROLL_BACK();
                    throw new Exception("Failed to save details.");
                }

                await this._invRepo.COMMIT();
                return savedIssue;
            }
            catch(Exception ex)
            {
                await this._invRepo.ROLL_BACK();
                logException(ex);
                return null;
            }
        }

        public  async Task<List<DepotIssueApprovalDTO>> getDepotIssueApprovalList()
        {
            try
            {
                return await _invRepo.getDepotIssueApprovalList();
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public async Task<List<DepotIssueDispatchDTO>> getDepotIssueDispatchList()
        {
            try
            {
                return await _invRepo.getDepotIssueDispatchList();
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public async Task<List<DepotIssueApprovalDetailsDTO>> getDepotIssueApprovalDetailsList(string IssueCode)
        {
            return await _invRepo.getDepotIssueApprovalDetailsList(IssueCode);
        }

        public async Task<StockIssue> updateDepotIssue(int Id, StockIssue issue)
        {
            try
            {
                return await _invRepo.updateDepotIssue(Id, issue);
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public async Task<StockIssue> findoneDepotIssueById(int Id)
        {
            try
            {
                return await _invRepo.findoneDepotIssueById(Id);
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }
        
        public async Task<StockIssue> SetStockIssueApprove(StockIssue issue, UserBasicInfo _User)
        {
            StockIssue StockIssue = await _invRepo.findoneDepotIssueById(issue.Id);

            StockIssue.IsApproved = true;
            StockIssue.ApprovedByCode = _User.EmployeeID;
            StockIssue.ApprovedDate = DateTime.Now;
            StockIssue.UpdatedById = _User.EmployeeID;
            StockIssue.UpdatedOn = DateTime.Now;

            return await _invRepo.updateDepotIssue(StockIssue.Id, StockIssue);
        }
        
        public async Task<StockIssue> SetStockIssueDispatch(StockIssue StockIssue, UserBasicInfo _User)
        {

            StockIssue.IsDispatched = true;
            StockIssue.DispatchByCode = _User.EmployeeID;
            StockIssue.DispatchedDate = DateTime.Now;
            StockIssue.UpdatedById = _User.EmployeeID;
            StockIssue.UpdatedOn = DateTime.Now;

            return StockIssue;
        }

        public async Task<List<DepotReceiveCreditNotePendingDto>> getCreditNotePendingDto()
        {
            return await _invRepo.getCreditNotePendingDto();
        }

        public async Task<List<DepotReceiveCreditNoteDetailPendingDto>> getCreditNotePendingDetailDto(string ReceiveCode)
        {
            return await _invRepo.getCreditNotePendingDetailDto(ReceiveCode);
        }

        public async Task<StockReceive> updateCreditNoteReceive(string ReceiveCode, UserBasicInfo _User)
        {
            StockReceive _stock = await _invRepo.getStockReceive(ReceiveCode);

            _stock.IsReceived = true;
            _stock.ReceivedByCode = _User.EmployeeID;
            _stock.ReceivedDate = System.DateTime.Now;

            StockReceive _receive = await _invRepo.updateStockReceive(_stock);

            return _receive;
        }
        
        public async Task<List<StockIssue>> getlateststockIssue(string FromDate, string ToDate)
        {
            return await _invRepo.getlateststockIssue(FromDate,ToDate);
        }
        
        public async Task<List<StockIssue>> getstockIssueBySearchText(string searchText)
        {
            return await _invRepo.getstockIssueBySearchText(searchText);
        }
        
        public async Task<List<StockIssueDetailsDTO>> getstockIssueDetailsByIssueCode(string issueCode)
        {
            return await _invRepo.getstockIssueDetailsByIssueCode(issueCode);
        }

        public async Task<List<stockIssueTotalValDetailsDTO>> getstockIssueTotalValDetailsByIssueCode(string issueCode)
        {
            return await _invRepo.getstockIssueTotalValDetailsByIssueCode(issueCode);
        }

        public async Task<StockIssue> findOneStockIssueByIssueCode(string IssueCode)
        {
           return await _invRepo.findOneStockIssueByIssueCode(IssueCode);
        }

        public async Task<List<stockIssueTotalValDetailsDTO>> getstockissueTotalandDetailsbyIssueCode(string issueCode)
        {
            try
            {
                // Getting All invoice data
                List<stockIssueTotalValDetailsDTO> master = await _invRepo.getstockIssueTotalValDetailsByIssueCode(issueCode);

                // Getting all invoice detail data
                List<StockIssueDetailsDTO> detail = await _invRepo.getstockIssueDetailsByIssueCode(issueCode);

                // mapping and initializing invoice data with invoice invoice detail data
                master.AsEnumerable().All(c => { c.StockIssueDetailsDTO = new List<StockIssueDetailsDTO>(); 
               
                c.StockIssueDetailsDTO.AddRange(detail.AsEnumerable().Where(x => (x.ProductID == c.ProductID)).ToList()); return true; });

                return master;
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public async Task<List<StockWithProductInfoAndBatchDto>> getAvailableStock()
        {
            List<StockInfoDto> stockInfo = await this._invRepo.getAvailableStock();
            return mapBatchWiseStockWithProduct(stockInfo);
        }

        public async Task<List<StockInfoDateBetweenDto>> getAvailableStockInfoDateBetween(string FromDate, string ToDate, string ProductCode, string BatchNo)
        {
            return await this._invRepo.getAvailableStockInfoDateBetween(FromDate, ToDate, ProductCode, BatchNo);
        }

        public async Task<List<StockInfoDateBetweenDto>> getPhysicalStockInfoDateBetween(string FromDate, string ToDate, string ProductCode, string BatchNo)
        {
            return await this._invRepo.getPhysicalStockInfoDateBetween(FromDate, ToDate, ProductCode, BatchNo);
        }

        public async Task<List<StockWithProductInfoAndBatchDto>> getPhysicalStock()
        {
            List<StockInfoDto> stockInfo = await this._invRepo.getPhysicalStock();
            return mapBatchWiseStockWithProduct(stockInfo);
        }

        private List<StockWithProductInfoAndBatchDto> mapBatchWiseStockWithProduct(List<StockInfoDto> stock)
        {
            List<StockWithProductInfoAndBatchDto> stockWithProdcutAndBatch = new List<StockWithProductInfoAndBatchDto>();

            stockWithProdcutAndBatch = (stock.Select(c => new StockWithProductInfoAndBatchDto
            {
                ProductCode = c.ProductCode,
                SalesCode = c.SalesCode,
                ProductName = c.ProductName,
                PackSize = c.PackSize,
                TP = c.TP,
                Vat = c.Vat,
                TotalStockQty = c.TotalStockQty,
                ProductBatch = stock.Where( i => i.ProductCode == c.ProductCode).Select( j => new BatchInfoDto 
                    { 
                        ProductCode = j.ProductCode, 
                        BatchNo = j.BatchNo, 
                        StockQty = j.StockQty, 
                        ExpiryDate = j.ExpiryDate, 
                        ManufacturingDate = j.ManufacturingDate
                    }).ToList()

            })).GroupBy(p => p.ProductCode).Select(n => n.FirstOrDefault()).ToList();

            return stockWithProdcutAndBatch;
        }

        public async Task<List<BatchReconciliationStockProductWise>> getBatchReconciliationStock(string ProductCode, string BatchNo)
        {
            return await this._invRepo.getBatchReconciliationStock(ProductCode, BatchNo);
        }

        public async Task<List<BatchReconciliationStockBatchWise>> getBatchReconciliationStockBatchWise(string ProductCode, string BatchNo)
        {
            return await this._invRepo.getBatchReconciliationStockBatchWise(ProductCode, BatchNo);
        }

        public async Task<List<DepotBatchReconciliationStockDateBetween>> getBatchReconciliationStockBatchWiseDateBetween(string FromDate, string ToDate, string ProductCode, string BatchNo)
        {
            return await this._invRepo.getBatchReconciliationStockBatchWiseDateBetween(FromDate, ToDate, ProductCode, BatchNo);
        }

        public async Task<List<DepotBatchReconciliationStockProductWiseDateBetween>> getBatchReconciliationStockProductWiseDateBetween(string FromDate, string ToDate, string ProductCode, string BatchNo)
        {
            return await this._invRepo.getBatchReconciliationStockProductWiseDateBetween(FromDate, ToDate, ProductCode, BatchNo);
        }

        public async Task<List<StockReceive>> getlateststockReceive(DateTime startdate, DateTime enddate)
        {
            return await _receiveRepo.GetStockReceiveMaster(startdate, enddate);
        }

        public async Task<List<stockIssueTotalValDetailsDTO>> getstockReceiveTotalandDetailsbyIssueCode(string receivecode)
        {
            try
            {
                // Getting All invoice data
                List<stockIssueTotalValDetailsDTO> master = await _receiveRepo.getstockReceiveTotalValDetailsByReceiveCode(receivecode);

                // Getting all invoice detail data
                List<StockIssueDetailsDTO> detail = await _receiveRepo.getstockReceiveDetailsByReceiveCode(receivecode);

                // mapping and initializing invoice data with invoice invoice detail data
                master.AsEnumerable().All(c => {
                    c.StockIssueDetailsDTO = new List<StockIssueDetailsDTO>();

                    c.StockIssueDetailsDTO.AddRange(detail.AsEnumerable().Where(x => (x.ProductID == c.ProductID)).ToList()); return true;
                });

                return master;
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public async Task<List<IssueType>> getIssueTypes()
        {
            return await _invRepo.GetIssueTypes();
        }

        public async Task<object> getStockIssueForSync()
        {
            var Issue = await _invRepo.getStockIssueForSync();
            var Detail = await _invRepo.getStockIssueDetailForSync();

            return new { Issue = Issue, Detail = Detail };
        }

        public async Task<object> updateStockIssueToTransfer(List<StockIssueForSyncDto> issue, UserBasicInfo _User)
        {
            List<StockIssue> issueList = new List<StockIssue>();

           


            foreach (var item in issue)
            {
                StockIssue dIssue = await _invRepo.GetStockIssue(item.IssueID);
                dIssue.IsTransferred = true;
                dIssue.CreatedById = _User.EmployeeID;
                dIssue.CreatedOn = DateTime.Now;

                StockIssue updatedIssue = await _invRepo.UpdateStockIssue(dIssue);
                if (updatedIssue == null) throw new Exception("Failed to update stock issue.");

                issueList.Add(updatedIssue);
            }

            if (!issueList.Any()) throw new Exception("Issue list empty to update transfer status. Please check updateStockIssueToTransfer");

            return issueList;
        }

        public async Task<List<ProductBatchStockForInvoice>> getCurrentStock()
        {
            await _invRepo.updateDepotAvailableStock();

            return await _invRepo.getCurrentStock();
        }

        public async Task<BatchWiseDetailsDto> getBatchReconciliationStockBatchWiseDetails(string batchNo)
        {
            List<ReceiveDetailsDto> ReceiveDetails = await _invRepo.getReceiveDetails(batchNo);
            List<IssueDetailsDto> IssueDetails = await _invRepo.getIssueDetails(batchNo);
            List<InvoiceDetailsDto> InvoiceDetails = await _invRepo.getInvoiceDetails(batchNo);
            List<SummaryReturnDetailsDto> SummaryDetails = await _invRepo.getSummaryDetails(batchNo);
            List<SummaryReturnDetailsDto> ReturnDetails = await _invRepo.getReturnDetails(batchNo);

            return new BatchWiseDetailsDto { ReceiveDetails = ReceiveDetails, IssueDetails = IssueDetails, InvoiceDetails = InvoiceDetails, SummaryDetails = SummaryDetails, ReturnDetails = ReturnDetails };
        }
    }
}
