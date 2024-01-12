using DMS.Core.DTO.SalesInvoice;
using System.Collections.Generic;

namespace DMS.Core.DTO.SummaryReturn
{
    public class SummaryReturnNewDto
    {
        public SummaryPendingInvoiceAllocationDto SummaryAllocation { get; set; }
        public List<AllocationInvoiceForSummaryMasterDto> SummaryReturn { get; set; }
        public List<SummaryCollectionNewDto> SummaryCollection { get; set; }
    }
}
