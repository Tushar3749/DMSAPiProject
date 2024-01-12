using DMS.Core.DTO;
using DMS.Core.DTO.Accounts;
using DMS.Core.DTO.SalesInvoice;
using DMS.Core.DTO.SummaryReturn;
using DMS.Core.Models.SystemManager;
using Microsoft.EntityFrameworkCore;

namespace DMS.Core.Models_StoredProcedure
{
    public class SummaryContext_ModelClasses : DbContext
    {
        public SummaryContext_ModelClasses(): base()
        {

        }

        
        protected virtual DbSet<SummaryCollectionsDateBetween> SummaryCollectionsDateBetween { get; set; }
        protected virtual DbSet<SummaryPendingInvoiceAllocationDto> SummaryPendingInvoiceAllocationDto { get; set; }
        protected virtual DbSet<SummaryPendingInvoiceAllocationDetailDto> SummaryPendingInvoiceAllocationDetailDto { get; set; }
        protected virtual DbSet<InvoiceDetailSummaryDto> SummaryPendingAllocationInvoiceProductDetail { get; set; }
        protected virtual DbSet<ProductReceivePendingSummary> ProductReceivePendingSummary { get; set; }
        protected virtual DbSet<ProductReceivePendingSummaryDetail> ProductReceivePendingSummaryDetail { get; set; }
        protected virtual DbSet<SummaryCollectionMoneyReceipt> SummaryCollectionMoneyReceipt { get; set; }
        protected virtual DbSet<SummaryCollectionMoneyReceiptDetail> SummaryCollectionMoneyReceiptDetail { get; set; }
        protected virtual DbSet<SummaryCollectionMoneyReceiptInstrument> SummaryCollectionMoneyReceiptInstrument { get; set; }
        protected virtual DbSet<SummaryCollectionByDACodeDto> SummaryCollectionByDACodeDto { get; set; }
        protected virtual DbSet<SummaryCollectionByCodeDto> SummaryCollectionByCodeDto { get; set; }
        protected virtual DbSet<BatchWiseReturnDto> BatchWiseReturnDto { get; set; }
        protected virtual DbSet<ProductWiseReturnDto> ProductWiseReturnDto { get; set; }
        protected virtual DbSet<RegionDTO> RegionDTO { get; set; }

        protected virtual DbSet<LocationWiseCollectionReportDTO> LocationWiseCollectionReportDTO { get; set; }

        protected virtual DbSet<Location> Location { get; set; }
        protected virtual DbSet<UnadjustedCreditNoteListDto> UnadjustedCreditNoteListDto { get; set; }


    }
}
