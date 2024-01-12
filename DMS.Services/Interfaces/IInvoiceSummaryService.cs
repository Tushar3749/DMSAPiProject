using DMS.Core.Dto.User;
using DMS.Core.DTO.SalesInvoice;
using DMS.Core.Models.SummaryInvoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Interfaces
{
    public interface IInvoiceSummaryService
    {
        Task<List<SummaryPendingInvoiceAllocationDto>> getAllocationForSummaryReturn();
        Task<List<SummaryPendingInvoiceAllocationDetailDto>> getSummaryPendingInvoiceAllocaitonDetail(string allocationCode);
        Task<List<InvoiceDetailSummaryDto>> getSummaryPendingAllocaitonInvoiceProductDetail(string invoiceCode);
        //Task<string> saveInvoiceSummary(SummaryDto summaryDto, UserBasicInfo _User);
        Task<SummaryInvoice> receiveBatchProduct(List<ProductReceivePendingSummaryDetail> receive, UserBasicInfo _User);
        Task<List<ProductReceivePendingSummary>> getProductReceivePendingSummary();
        Task<List<ProductReceivePendingSummaryDetail>> getProductReceivePendingSummaryDetail(string SummaryCode, string AllocationCode, string InvoiceCode);
        Task<Summary> finalizeAllocationSummary(string AllocationCode);

        Task<List<SummaryPendingInvoiceAllocationDto>> getSummaryPendingInvoiceAllocaiton();
        Task<List<AITDocumentReceiveStatusDTO>> getReceivedAITDocument();
        Task<List<AITDocumentReceiveStatusDTO>> getReceivePendingAITDocument();


    }
}
