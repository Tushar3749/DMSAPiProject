using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.Orders.OrderReport
{
	[Keyless]
    public class SalesOrderReportDetailDto
    {

		public string OrderCode { get; set; }

		public string ProductCode { get; set; }
		public Nullable<int> OrderQuantity { get; set; }
		public Nullable<decimal> TP { get; set; }
		public Nullable<decimal> VAT { get; set; }
		public Nullable<decimal> MRP { get; set; }

		public string SalesCode { get; set; }
		public string ProductName { get; set; }
		public string PackSize { get; set; }
	}
}
