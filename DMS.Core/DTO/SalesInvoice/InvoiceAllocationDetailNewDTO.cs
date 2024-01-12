using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.SalesInvoice
{
    [Keyless]
   public class InvoiceAllocationDetailNewDTO
    {
        public Nullable<int> ID { get; set; }

        public string AllocationCode { get; set; }
        public string InvoiceCode { get; set; }
        public string MachineID { get; set; }
        public string CreatedByID { get; set; }
    }
}
