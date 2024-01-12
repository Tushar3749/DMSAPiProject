using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Allocation
{
    [Keyless]
    public class AllocationInvoiceStatementDTO
    {
        public string AllocationCode { get; set; }

        public Nullable<DateTime> AllocationDate { get; set; }
        public string DACode { get; set; }
        public string EmployeeName { get; set; }
        public Nullable<int> InvoiceNo { get; set; }
        public Nullable<decimal> NetTP { get; set; }

        public Nullable<decimal> NetVat { get; set; }
        public Nullable<decimal> NetProductDiscount { get; set; }
        public Nullable<decimal> NetAmountDiscount { get; set; }
        public Nullable<decimal> NetAmount { get; set; }
        public Nullable<decimal> TotalCash { get; set; }
        public Nullable<decimal> TotalCredit { get; set; }
        public Nullable<int> ISSummaryDone { get; set; }

        public Nullable<DateTime> ReturnDate { get; set; }



    }
}
