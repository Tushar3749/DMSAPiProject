using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Inventory
{
	[Keyless]
    public class ProductWithStock
    {
		public string ProductCode { get; set; }

		public string ProductName { get; set; }
		public string SalesCode { get; set; }
		public string PackSize { get; set; }
		public Nullable<decimal> TP { get; set; }
		public Nullable<decimal> Vat { get; set; }

		public Nullable<int> StockQuantity { get; set; }
	}
}
