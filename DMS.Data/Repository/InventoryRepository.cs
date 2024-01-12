/*
 *=============================================
 *Author: Md. Rahat Hossain 
 *Email: rahat@labaidpharma.com
 *Created on: 7 June, 2021
 *Updated on:
 *Last updated on:
 *Description:
 *=============================================
*/

using DMS.Core.DTO.DepotInventory;
using DMS.Core.DTO.Inventory;
using DMS.Core.DTO.Inventory.BatchReconcilationReportDetails;
using DMS.Core.Models.Inventory;
using DMS.Data.Repositories.GenericRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Data.Repository
{
    public class InventoryRepository : Repository
    {
        private DbContext context = null;
        
        public InventoryRepository(DbContext context): base(context)
        {
            this.context = context;
        }

        public async Task<List<ProductBatchStockForInvoice>> getCurrentStock()
        {
            List<ProductBatchStockForInvoice> stock = await this.context.Set<ProductBatchStockForInvoice>().FromSqlRaw("exec getStockForInvoice").ToListAsync();
            return stock.AsEnumerable().Where(i => i.StockQty > 0).ToList();
        }

        public async Task<bool> updateDepotIssueAvailableStock()
        {
            return await new GenericRepository<StockIssue>(this.context).ExecuteCommand("EXEC Inventory_DMS.dbo.updateDepotIssueQuantityToAvailableStock");
        }

        public async Task<bool> updateDepotReceiveAvailableStock()
        {
            return await new GenericRepository<StockIssue>(this.context).ExecuteCommand("EXEC Inventory_DMS.dbo.updateDepotReceiveQuantityToAvailableStock");
        }
        
        public async Task<bool> updateDepotAvailableStock()
        {
            return await new GenericRepository<StockIssue>(this.context).ExecuteCommand("EXEC Inventory_DMS.dbo.updateDepotAvailableStock");
        }
        public async Task<bool> updateDepotAvailableStock_OrderSpecific(string OrderCode)
        {
            this.context.Database.SetCommandTimeout(180000);
            return await new GenericRepository<StockIssue>(this.context).ExecuteCommand("EXEC Inventory_DMS.dbo.updateDepotAvailableStock_OrderSpecific @OrderCode", new SqlParameter("@OrderCode", OrderCode));
        }
        public async Task<List<DepotLocation>> getDepotLocaiton(string IssueType)
        {
            return await this.context.Set<DepotLocation>().FromSqlRaw("exec getDepotLocations @IssueType",new SqlParameter("@IssueType", IssueType)).ToListAsync();
        }

        public async Task<List<ProductWithStock>> getProductWithStock(Boolean OnlyShortStock = false)
        {
            return await this.context.Set<ProductWithStock>().FromSqlRaw("exec getProductWithStock @OnlyShortStock", new SqlParameter("@OnlyShortStock", OnlyShortStock)).ToListAsync();
        }

        public async Task<List<DepotIssueApprovalDTO>> getDepotIssueApprovalList()
        {
            return await this.context.Set<DepotIssueApprovalDTO>().FromSqlRaw("exec getDepotIssueApproval").ToListAsync();
        }
        public async Task<List<DepotIssueDispatchDTO>> getDepotIssueDispatchList()
        {
            return await this.context.Set<DepotIssueDispatchDTO>().FromSqlRaw("exec getDepotIssueDispatch").ToListAsync();
        }
        public async Task<List<DepotIssueApprovalDetailsDTO>> getDepotIssueApprovalDetailsList(string IssueCode)
        {
            SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@IssueCode", IssueCode) };

            return await new GenericRepository<DepotIssueApprovalDetailsDTO>(context).FindUsingSPAsync("exec getDepotIssueApprovalDetails @IssueCode", sqlParams);
        }
        public async Task<StockIssue> updateDepotIssue(int? ID, StockIssue Entity)
        {

            var result = await new GenericRepository<StockIssue>(this.context).Update(Entity, I => I.Id == ID);

            return result;
        }
        public async Task<StockIssue> findoneDepotIssueById(int Id)
        {
            return await new GenericRepository<StockIssue>(this.context).FindOne(i => i.IsActive == true && i.Id == Id);
        }

        public async Task<List<DepotReceiveCreditNotePendingDto>> getCreditNotePendingDto()
        {
            return await this.context.Set<DepotReceiveCreditNotePendingDto>().FromSqlRaw("exec getCreditNoteReceivePending").ToListAsync();
        }

        public async Task<List<DepotReceiveCreditNoteDetailPendingDto>> getCreditNotePendingDetailDto(string ReceiveCode)
        {
            return await this.context.Set<DepotReceiveCreditNoteDetailPendingDto>().FromSqlRaw("exec getCreditNoteReceiveDetailPending @ReceiveCode", new SqlParameter("@ReceiveCode", ReceiveCode)).ToListAsync();
        }

        public async Task<StockReceive> getStockReceive(string ReceiveCode)
        {
            return await new GenericRepository<StockReceive>(this.context).FindOne(i => i.ReceiveCode == ReceiveCode);
        }

        public async Task<StockReceive> updateStockReceive(StockReceive entity)
        {
            return await new GenericRepository<StockReceive>(this.context).Update(entity, i => i.ReceiveCode == entity.ReceiveCode);
        }

        public async Task<List<StockIssue>> getlateststockIssue(string FromDate, string ToDate)
        {
           return await this.context.Set<StockIssue>().FromSqlRaw("getlateststockIssue @FromDate, @ToDate",
                new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate)).ToListAsync();
        }

        public async Task<List<StockIssue>> getstockIssueBySearchText(string searchText)
        {
            SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@searchText", searchText) };

            return await new GenericRepository<StockIssue>(context).FindUsingSPAsync("exec getstockIssueBySearchText @searchText", sqlParams);
        }

        public async Task<List<StockIssueDetailsDTO>> getstockIssueDetailsByIssueCode(string issueCode)
        {
            SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@issueCode", issueCode) };

            return await new GenericRepository<StockIssueDetailsDTO>(context).FindUsingSPAsync("exec getstockIssueDetailsByIssueCode @issueCode", sqlParams);
        }

        public async Task<List<stockIssueTotalValDetailsDTO>> getstockIssueTotalValDetailsByIssueCode(string issueCode)
        {
            SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@issueCode", issueCode) };

            return await new GenericRepository<stockIssueTotalValDetailsDTO>(context).FindUsingSPAsync("exec getstockIssueTotalValDetailsByIssueCode @issueCode", sqlParams);
        }

        // Find One
        public async Task<StockIssue> findOneStockIssueByIssueCode(string IssueCode)
        {
            return await new GenericRepository<StockIssue>(this.context).FindOne(i => i.IsActive == true && i.IssueCode == IssueCode);
        }

        public async Task<StockReceive> getStockReceiveByChallanCode(string ChallanCode)
        {
            return await new GenericRepository<StockReceive>(this.context).FindOne(i => i.IsActive == true && i.ChallanCode == ChallanCode);
        }

        public async Task<List<StockInfoDto>> getAvailableStock()
        {
            return await this.context.Set<StockInfoDto>().FromSqlRaw("exec getAvailableStockInfo").ToListAsync();
        }

        public async Task<List<StockInfoDto>> getPhysicalStock()
        {
            return await this.context.Set<StockInfoDto>().FromSqlRaw("exec getPhysicalStockInfo").ToListAsync();
        }

        public async Task<List<BatchReconciliationStockProductWise>> getBatchReconciliationStock(string ProductCode, string BatchNo)
        {
            return await this.context.Set<BatchReconciliationStockProductWise>().FromSqlRaw("exec getBatchReconciliationStockProductWise @productCode, @batchNo", new SqlParameter("@productCode", ProductCode), new SqlParameter("@batchNo", BatchNo)).ToListAsync();
        }

        public async Task<List<BatchReconciliationStockBatchWise>> getBatchReconciliationStockBatchWise(string ProductCode, string BatchNo)
        {
            return await this.context.Set<BatchReconciliationStockBatchWise>().FromSqlRaw("exec getBatchReconciliationStockBatchWise @productCode, @batchNo", new SqlParameter("@productCode", ProductCode), new SqlParameter("@batchNo", BatchNo)).ToListAsync();
        }

        public async Task<List<DepotBatchReconciliationStockDateBetween>> getBatchReconciliationStockBatchWiseDateBetween(string FromDate, string ToDate, string ProductCode, string BatchNo)
        {
            return await this.context.Set<DepotBatchReconciliationStockDateBetween>().FromSqlRaw("exec getDepotBatchReconciliationStockDateBetween @FromDate, @ToDate, @productCode, @batchNo", new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate), new SqlParameter("@productCode", ProductCode), new SqlParameter("@batchNo", BatchNo)).ToListAsync();
        }

        public async Task<List<DepotBatchReconciliationStockProductWiseDateBetween>> getBatchReconciliationStockProductWiseDateBetween(string FromDate, string ToDate, string ProductCode, string BatchNo)
        {
            return await this.context.Set<DepotBatchReconciliationStockProductWiseDateBetween>().FromSqlRaw("exec getDepotBatchReconciliationStockProductWiseDateBetween @FromDate, @ToDate, @productCode, @batchNo", new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate), new SqlParameter("@productCode", ProductCode), new SqlParameter("@batchNo", BatchNo)).ToListAsync();
        }

        public async Task<List<StockInfoDateBetweenDto>> getAvailableStockInfoDateBetween(string FromDate, string ToDate, string ProductCode, string BatchNo)
        {
            return await this.context.Set<StockInfoDateBetweenDto>().FromSqlRaw("exec getAvailableStockInfoDateBetween @FromDate, @ToDate, @productCode, @batchNo", new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate), new SqlParameter("@productCode", ProductCode), new SqlParameter("@batchNo", BatchNo)).ToListAsync();
        }

        public async Task<List<StockInfoDateBetweenDto>> getPhysicalStockInfoDateBetween(string FromDate, string ToDate, string ProductCode, string BatchNo)
        {
            return await this.context.Set<StockInfoDateBetweenDto>().FromSqlRaw("exec getPhysicalStockInfoDateBetween @FromDate, @ToDate, @productCode, @batchNo", new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate), new SqlParameter("@productCode", ProductCode), new SqlParameter("@batchNo", BatchNo)).ToListAsync();
        }

        public async Task<StockReceive> saveStockReceive(StockReceive stock)
        {
            return await new GenericRepository<StockReceive>(this.context).Insert(stock);
        }

        public async Task<List<StockReceiveDetail>> saveStockReceive(List<StockReceiveDetail> stock)
        {
            return await new GenericRepository<StockReceiveDetail>(this.context).InsertBulk(stock);
        }

        public async Task<List<IssueType>> GetIssueTypes()
        {
            return await new GenericRepository<IssueType>(this.context).GetAll();
        }

        public async Task<List<StockIssueForSyncDto>> getStockIssueForSync()
        {
            return await this.context.Set<StockIssueForSyncDto>().FromSqlRaw("exec getDepotIssueForSync").ToListAsync();
        }

        public async Task<List<StockIssueDetailForSyncDto>> getStockIssueDetailForSync()
        {
            return await this.context.Set<StockIssueDetailForSyncDto>().FromSqlRaw("exec getDepotIssueDetailsForSync").ToListAsync();
        }

        public async Task<StockIssue> GetStockIssue(string IssueCode)
        {
            return await new GenericRepository<StockIssue>(this.context).FindOne(i => i.IssueCode == IssueCode);
        }

        public async Task<StockIssue> UpdateStockIssue(StockIssue issue)
        {
            return await new GenericRepository<StockIssue>(this.context).Update(issue, i => i.IssueCode == issue.IssueCode);
        }

        public async Task<List<ReceiveDetailsDto>> getReceiveDetails(string batchNo)
        {
            return await this.context.Set<ReceiveDetailsDto>().FromSqlRaw("exec getAllDetailsReportBatchWise @BatchNo,'RECEIVE'", new SqlParameter("@BatchNo", batchNo)).ToListAsync();
        }

        public async Task<List<IssueDetailsDto>> getIssueDetails(string batchNo)
        {
            return await this.context.Set<IssueDetailsDto>().FromSqlRaw("exec getAllDetailsReportBatchWise @BatchNo,'ISSUE'", new SqlParameter("@BatchNo", batchNo)).ToListAsync();
        }

        public async Task<List<InvoiceDetailsDto>> getInvoiceDetails(string batchNo)
        {
            return await this.context.Set<InvoiceDetailsDto>().FromSqlRaw("exec getAllDetailsReportBatchWise @BatchNo,'INVOICE'", new SqlParameter("@BatchNo", batchNo)).ToListAsync();
        }

        public async Task<List<SummaryReturnDetailsDto>> getSummaryDetails(string batchNo)
        {
            return await this.context.Set<SummaryReturnDetailsDto>().FromSqlRaw("exec getAllDetailsReportBatchWise @BatchNo,'SUMMARY'", new SqlParameter("@BatchNo", batchNo)).ToListAsync();
        }

        public async Task<List<SummaryReturnDetailsDto>> getReturnDetails(string batchNo)
        {
            return await this.context.Set<SummaryReturnDetailsDto>().FromSqlRaw("exec getAllDetailsReportBatchWise @BatchNo,'RETURN'", new SqlParameter("@BatchNo", batchNo)).ToListAsync();
        }
    }
}
