using DMS.Core.Dto.User;
using DMS.Core.DTO.DepotInventory;
using DMS.Core.DTO.Inventory;
using DMS.Core.DTO.Inventory.BatchReconcilationReportDetails;
using DMS.Core.Models.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Interfaces
{
    public interface IInventoryService
    {
        Task<List<DepotLocation>> getDepotLocaiton(string IssueType);
        Task<List<ProductWithStock>> getProductWithStock(Boolean ShortStockOnly = false);
        Task<StockIssue> saveDepotIssue(DepotIssue issue, UserBasicInfo _User);

        Task<List<DepotReceiveCreditNoteDetailPendingDto>> getCreditNotePendingDetailDto(string ReceiveCode);
        Task<StockReceive> updateCreditNoteReceive(string ReceiveCode, UserBasicInfo _User);
        Task<List<DepotReceiveCreditNotePendingDto>> getCreditNotePendingDto();


        Task<List<DepotIssueApprovalDTO>> getDepotIssueApprovalList();
        Task<List<DepotIssueDispatchDTO>> getDepotIssueDispatchList();
        Task<List<DepotIssueApprovalDetailsDTO>> getDepotIssueApprovalDetailsList(string IssueCode);
        Task<StockIssue> updateDepotIssue(int Id, StockIssue issue);
        Task<StockIssue> findoneDepotIssueById(int Id);
        Task<StockIssue> SetStockIssueApprove(StockIssue StockIssue, UserBasicInfo _User);
        Task<StockIssue> SetStockIssueDispatch(StockIssue StockIssue, UserBasicInfo _User);
        Task<object> saveDepotChallan(ChallanReceivePendingDto challan, UserBasicInfo _User);

        Task<List<StockIssue>> getlateststockIssue(string FromDate,string ToDate);

        Task<List<StockIssue>> getstockIssueBySearchText(string searchText);

        Task<List<StockIssueDetailsDTO>> getstockIssueDetailsByIssueCode(string issueCode);

        Task<List<stockIssueTotalValDetailsDTO>> getstockIssueTotalValDetailsByIssueCode(string issueCode);

        Task<StockIssue> findOneStockIssueByIssueCode(string IssueCode);

        Task<List<stockIssueTotalValDetailsDTO>> getstockissueTotalandDetailsbyIssueCode(string issueCode);

        Task<List<StockWithProductInfoAndBatchDto>> getAvailableStock();
        Task<List<StockWithProductInfoAndBatchDto>> getPhysicalStock();
        Task<List<BatchReconciliationStockProductWise>> getBatchReconciliationStock(string ProductCode, string BatchNo);
        Task<List<BatchReconciliationStockBatchWise>> getBatchReconciliationStockBatchWise(string ProductCode, string BatchNo);

        Task<List<StockReceive>> getlateststockReceive(DateTime startdate, DateTime enddate);

        Task<List<stockIssueTotalValDetailsDTO>> getstockReceiveTotalandDetailsbyIssueCode(string receivecode);
        Task<List<IssueType>> getIssueTypes();
        Task<object> getStockIssueForSync();
        Task<object> updateStockIssueToTransfer(List<StockIssueForSyncDto> issue, UserBasicInfo _User);
        Task<List<DepotBatchReconciliationStockDateBetween>> getBatchReconciliationStockBatchWiseDateBetween(string FromDate, string ToDate, string ProductCode, string BatchNo);
        Task<List<DepotBatchReconciliationStockProductWiseDateBetween>> getBatchReconciliationStockProductWiseDateBetween(string FromDate, string ToDate, string ProductCode, string BatchNo);
        Task<List<StockInfoDateBetweenDto>> getAvailableStockInfoDateBetween(string FromDate, string ToDate, string ProductCode, string BatchNo);
        Task<List<StockInfoDateBetweenDto>> getPhysicalStockInfoDateBetween(string FromDate, string ToDate, string ProductCode, string BatchNo);
        Task<List<ProductBatchStockForInvoice>> getCurrentStock();
        Task<BatchWiseDetailsDto> getBatchReconciliationStockBatchWiseDetails(string batchNo);
    }
}
