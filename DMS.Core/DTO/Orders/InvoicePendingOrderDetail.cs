using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.Orders
{
    [Keyless]
	public class InvoicePendingOrderDetail
    {
		public string ProductCode { get; set; }

		public string SalesCode { get; set; }
		public string ProductName { get; set; }
		public string PackSize { get; set; }
		public int SPS { get; set; }
		public Nullable<decimal> TP { get; set; }
		public Nullable<decimal> Vat { get; set; }

		public Nullable<int> OrderQty { get; set; }
		public Nullable<decimal> TotalTP { get; set; }
		public Nullable<decimal> TotalVat { get; set; }
		public Nullable<int> StockQty { get; set; }
		public Nullable<int> OtherOrderProductQuantity { get; set; }
		public Nullable<Boolean> IsBonusProduct { get; set; }
	}
}
