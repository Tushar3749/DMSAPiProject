using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.SalesInvoice
{
    [Keyless]
   public class PendingAllocationDispatchDTO
    {
        public string AllocationCode { get; set; }
        public DateTime AllocationDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public string DAName { get; set; }

        public int? NoOfInvoices { get; set; }

    }
}
