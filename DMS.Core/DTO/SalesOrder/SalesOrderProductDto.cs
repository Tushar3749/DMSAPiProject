using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.SalesOrder
{
	[Keyless]
    public class SalesOrderProductDto 
	{
		public Nullable<int> OrderID { get; set; }

		public Nullable<int> ProductID { get; set; }
		public Nullable<int> OrderQuantity { get; set; }
		public Nullable<decimal> TP { get; set; }
		public Nullable<decimal> MRP { get; set; }
		public string SalesCode { get; set; }

		public string ProductCode { get; set; }
		public string ProductName { get; set; }
		public string PackSize { get; set; }

		
	}
}
