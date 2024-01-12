using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.SalesInvoice
{
  public class InvoiceAllocationDTO
    {
        public Nullable<int> ID { get; set; }

        public string AllocationCode { get; set; }
        public Nullable<DateTime> AllocationDate { get; set; }
        public string DACode { get; set; }
        public string DepotCode { get; set; }
        public Nullable<DateTime> ReturnDate { get; set; }

        public string MachineID { get; set; }
        public string CreatedByID { get; set; }

        public string Remarks { get; set; }

    }
}
