using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.SummaryReturn
{
   [Keyless]
   public class SummaryStatementDTO
   {
        public string SummaryCode { get; set; }

        public Nullable<DateTime> SummaryDate { get; set; }
        public string AllocationCode { get; set; }
        public Nullable<DateTime> AllocationDate { get; set; }
        public Nullable<decimal> NetTP { get; set; }
        public Nullable<decimal> SoldTP { get; set; }

        public Nullable<decimal> ReturnTP { get; set; }
        public Nullable<decimal> SoldVAT { get; set; }
        public Nullable<decimal> SoldDiscount { get; set; }
        public Nullable<decimal> SoldAmount { get; set; }

        public string CollectionCode { get; set; }

        public string MoneyReceiptCode { get; set; }


    }
}
