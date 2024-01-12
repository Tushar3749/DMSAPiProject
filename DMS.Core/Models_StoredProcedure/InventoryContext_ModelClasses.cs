using DMS.Core.DTO.DayOperation;
using DMS.Core.DTO.DepotInventory;
using DMS.Core.DTO.Inventory;
using DMS.Core.DTO.Inventory.BatchReconcilationReportDetails;
using DMS.Core.Models.Inventory;
using DMS.Core.Models.SystemManager;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.Models_StoredProcedure
{
    public class InventoryContext_ModelClasses : DbContext
    {
        public InventoryContext_ModelClasses() : base()
        {

        }

        /*
         *=============================================
         *Author: Md. Rahat Hossain
         *Email: rahat@labaidpharma.com
         *Created on: 09 June 2021
         *=============================================
        */
        protected virtual DbSet<StockReceiveDTO> StockReceiveDTO { get; set; }
        protected virtual DbSet<DepotLocation> DepotLocation { get; set; }
        protected virtual DbSet<ProductWithStock> ProductWithStock { get; set; }
        protected virtual DbSet<ProductBatchStockForInvoice> ProductBatchStockForInvoice { get; set; }
        protected virtual DbSet<DepotReceiveCreditNoteDetailPendingDto> DepotReceiveCreditNoteDetailPendingDto { get; set; }
        protected virtual DbSet<DepotReceiveCreditNotePendingDto> DepotReceiveCreditNotePendingDto { get; set; }
        protected virtual DbSet<StockInfoDto> StockInfoDto { get; set; }
        protected virtual DbSet<BatchReconciliationStockProductWise> BatchReconciliationStockProductWise { get; set; }
        protected virtual DbSet<BatchReconciliationStockBatchWise> BatchReconciliationStockBatchWise { get; set; }

        protected virtual DbSet<StockIssueForSyncDto> StockIssueForSyncDto { get; set; }
        protected virtual DbSet<StockIssueDetailForSyncDto> StockIssueDetailForSyncDto { get; set; }
        protected virtual DbSet<DepotBatchReconciliationStockDateBetween> DepotBatchReconciliationStockDateBetween { get; set; }
        protected virtual DbSet<DepotBatchReconciliationStockProductWiseDateBetween> DepotBatchReconciliationStockProductWiseDateBetween { get; set; }
        protected virtual DbSet<StockInfoDateBetweenDto> StockInfoDateBetweenDto { get; set; }


        /*
        *=============================================
        * END Of Author Md. Rahat Hossian
        *=============================================
        */


        /*
       *=============================================
       *Author: shafiqul bari sadman
       *Email: sadman.it@labaidpharma.com
       *Created on: 09 June 2021
       *=============================================
      */
        protected virtual DbSet<DepotIssueApprovalDTO> DepotIssueApproval { get; set; }
        protected virtual DbSet<DepotIssueApprovalDetailsDTO> DepotIssueApprovalDetails { get; set; }
        protected virtual DbSet<DepotIssueDispatchDTO> DepotIssueDispatch { get; set; }
        protected virtual DbSet<stockIssueTotalValDetailsDTO> stockIssueTotalValDetailsDTO { get; set; }
        protected virtual DbSet<StockIssueDetailsDTO> StockIssueDetailsDTO { get; set; }
        protected virtual DbSet<Location> Location { get; set; }


        /*
     *=============================================
     * END Of Author shafiqul bari sadman
     *=============================================
     */



     /*
     *=============================================
     *Author: Md Monir Uddin
     *Email: monir@labaidpharma.com
     *Created on: 04 Sept 2022
     *=============================================
    */
        protected virtual DbSet<ReceiveDetailsDto> ReceiveDetails { get; set; }
        protected virtual DbSet<IssueDetailsDto> IssueDetails { get; set; }
        protected virtual DbSet<InvoiceDetailsDto> InvoiceDetails { get; set; }
        protected virtual DbSet<SummaryReturnDetailsDto> SummaryReturnDetails { get; set; }


     /*
     *=============================================
     * END Of Author Md Monir Uddin
     *=============================================
     */




    }
}
