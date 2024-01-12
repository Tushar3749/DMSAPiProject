using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.SalesInvoice
{
    [Keyless]
    public class ProductReceivePendingSummary
    {
        public string SummaryCode { get; set; }

        public Nullable<DateTime> SummaryDate { get; set; }
        public string AllocationCode { get; set; }
        public string InvoiceCode { get; set; }
        public string DACode { get; set; }
        public string EmployeeName { get; set; }
        public int NoOfDays { get; set; }
        
    }
}
