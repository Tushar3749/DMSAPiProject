using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DMS.Core.DTO.SalesInvoice
{


	public class InvoiceNewDto
    {
        public string InvoiceCode { get; set; }
        public List<InvoiceDetailNewDto> InvoiceDetail { get; set; }

		public Nullable<decimal> TotalAmount { get; set; }
		public Nullable<decimal> AdjustmentAmount { get; set; }
		public Nullable<decimal> NetAmount { get; set; }
	}


	public class InvoiceDetailNewDto
    {
		public string InvoiceCode { get; set; }
		public string ProductCode { get; set; }
		public string ProductName { get; set; }
		public string SalesCode { get; set; }
		public string PackSize { get; set; }
		public int SPS { get; set; }
		public Nullable<decimal> TP { get; set; }
		public Nullable<decimal> Vat { get; set; }

		public string DiscountCode { get; set; }
		public Nullable<int> DiscountDetailId { get; set; }

		public Nullable<int> InvoiceQty { get; set; }
		public Nullable<int> BonusQty { get; set; }
		public Nullable<int> StockQty { get; set; }
		public Nullable<int> OrderQty { get; set; }
		public Nullable<int> QuantityAfterBonus { get; set; }
		public Nullable<int> OtherOrderProductQuantity { get; set; }

		public Nullable<decimal> TotalTP { get; set; }
		public Nullable<decimal> TotalVat { get; set; }
		public Nullable<decimal> FacilityAmount { get; set; }
		public Nullable<decimal> ProductDiscount { get; set; }
		public Nullable<decimal> AmountDiscount { get; set; }
		public Nullable<decimal> ProductAmount { get; set; }
		public Nullable<decimal> IndividualDiscountPercent { get; set; }
		public Nullable<Boolean> IsAmountInPercent { get; set; }
		public Nullable<Boolean> HasStockShort { get; set; }

		public Nullable<Boolean> IsInvoiceAmountDiscountApplicable { get; set; }
		public Nullable<Boolean> IsBonusProduct { get; set; }
		public string AppliedDiscountRuleNumbers { get; set; }
		public string BonusSegment { get; set; }

	}
}
