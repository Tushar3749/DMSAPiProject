using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.SalesInvoice
{
    public class ReceiveBatchProduct
    {
        public ProductReceivePendingSummary SummaryInvoice { get; set; }
        public List<ProductReceivePendingSummaryDetail> SummaryInvoiceDetail { get; set; }
    }
}
