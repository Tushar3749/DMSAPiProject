using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.Report
{
	[Keyless]
    public class ProductSalesSummaryReportDto
    {
		public string ProductID { get; set; }

		public string BrandName { get; set; }
		public string SalesCode { get; set; }
		public string PackSize { get; set; }
		public Nullable<decimal> TradePrice { get; set; }
		public Nullable<decimal> Vat { get; set; }

		public Nullable<int> TransitQty { get; set; }
		public Nullable<int> TransitBonusQty { get; set; }
		public Nullable<decimal> TransitTP { get; set; }
		public Nullable<decimal> TransitVat { get; set; }
		public Nullable<decimal> TransitDiscount { get; set; }

		public Nullable<int> SoldQty { get; set; }
		public Nullable<int> SoldBonusQty { get; set; }
		public Nullable<int> SoldReturnQty { get; set; }
		public Nullable<decimal> SoldTP { get; set; }
		public Nullable<decimal> SoldVat { get; set; }

		public Nullable<decimal> SoldDiscount { get; set; }
		public Nullable<decimal> TotalTP { get; set; }
		public Nullable<decimal> TotalVat { get; set; }
		public Nullable<decimal> TotalDiscount { get; set; }
		public Nullable<decimal> NetTotal { get; set; }
	}
}
