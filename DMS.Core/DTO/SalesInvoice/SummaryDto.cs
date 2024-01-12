using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.SalesInvoice
{
    public class SummaryDto
    {
        public SummaryPendingInvoiceAllocationDto Allocation { get; set; }
        public List<SummaryPendingInvoiceAllocationDetailDto> Invoice { get; set; }
        public List<InvoiceDetailSummaryDto> InvoiceDetail { get; set; }
        public bool IsSaveAndLockSummary { get; set; }
    }
}
