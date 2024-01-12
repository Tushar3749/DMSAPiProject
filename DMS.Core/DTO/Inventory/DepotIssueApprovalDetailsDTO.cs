using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Inventory
{
    [Keyless]
   public class DepotIssueApprovalDetailsDTO
    {
        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        public string PackSize { get; set; }

        public int? Quantity { get; set; }

        public Nullable<Decimal> TP { get; set; }

        public Nullable<Decimal> Vat { get; set; }
        public Nullable<Decimal> TotalTP { get; set; }
        public Nullable<Decimal> TotalVat { get; set; }
        public Nullable<Decimal> TPwithVat { get; set; }

        public string BatchNo { get; set; }



    }
}
