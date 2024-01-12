using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Allocation
{
    [Keyless]
   public class ProductReturnReportDTO
    {
        public string SummaryCode { get; set; }

        public Nullable<DateTime> SummaryDate { get; set; }
        public string AllocationCode { get; set; }
        public Nullable<DateTime> AllocationDate { get; set; }
    }
}
