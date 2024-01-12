using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.Orders.OrderReport
{
    [Keyless]
    public class SalesOrderReportForPrintDto
    {
		public string OrderCode { get; set; }

		public string TerritoryCode { get; set; }
		public string MPOCode { get; set; }
		public string MPOName { get; set; }
		public string ChemistCode { get; set; }
		public string ChemistName { get; set; }
		public string PaymentMode { get; set; }
		public Nullable<DateTime> DeliveryDate { get; set; }

		public string DeliveryTime { get; set; }
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
