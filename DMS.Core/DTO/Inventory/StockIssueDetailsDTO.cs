using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Inventory
{
    [Keyless]
   public class StockIssueDetailsDTO
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string BatchNo { get; set; }
        public int? Quantity { get; set; }

    }
}
