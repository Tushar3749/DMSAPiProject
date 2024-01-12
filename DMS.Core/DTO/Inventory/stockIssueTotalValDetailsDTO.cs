using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Inventory
{
    [Keyless]
   public class stockIssueTotalValDetailsDTO
    {
        public string SalesCode { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string PackSize { get; set; }
        public int? TotalQTY { get; set; }
        public Nullable<decimal> TotalTP { get; set; }
        public Nullable<decimal> TotalVAT { get; set; }
        public Nullable<decimal> TPwithVAT { get; set; }

        public List<StockIssueDetailsDTO> StockIssueDetailsDTO { get; set; }



    }
}
