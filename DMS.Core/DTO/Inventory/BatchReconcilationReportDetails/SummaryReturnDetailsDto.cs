using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Inventory.BatchReconcilationReportDetails
{
    [Keyless]
    public class SummaryReturnDetailsDto
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string SalesCode { get; set; }
        public string PackSize { get; set; }
        public string BatchNo { get; set; }
        public string SummaryCode { get; set; }
        public DateTime SummaryDate { get; set; }
        public string InvoiceCode { get; set; }
        public int Quantity { get; set; }
        public int SoldQty { get; set; }
        public int ReturnQty { get; set; }
    }
}
