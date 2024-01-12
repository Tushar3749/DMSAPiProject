using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Inventory.BatchReconcilationReportDetails
{
    public class BatchWiseDetailsDto
    {
        public List<ReceiveDetailsDto> ReceiveDetails { get; set; }
        public List <IssueDetailsDto> IssueDetails { get; set; }
        public List <InvoiceDetailsDto> InvoiceDetails { get; set; }
        public List<SummaryReturnDetailsDto> SummaryDetails { get; set; }
        public List<SummaryReturnDetailsDto> ReturnDetails { get; set; }
    }
}
