using System;

namespace DMS.Core.DTO.SummaryReturn
{
    public class SummaryInvoiceDetailDto
    {

		public string InvoiceCode { get; set; }

		public string ProductCode { get; set; }
		public string SalesCode { get; set; }
		public string PackSize { get; set; }
		public Nullable<int> SPS { get; set; }
		public Nullable<decimal> TP { get; set; }

		public Nullable<decimal> Vat { get; set; }
		public string DiscountCode { get; set; }
		public Nullable<int> InvoiceQty { get; set; }
		public Nullable<int> BonusQty { get; set; }
		public Nullable<int> SoldBonusQty { get; set; }
		public Nullable<int> ReturnQuantity { get; set; }
		public Nullable<int> ReturnWithBonusQuantity { get; set; }
		public Nullable<int> ReturnBonusQuantity { get; set; }
		public Nullable<int> SoldQuantity { get; set; }
		public Nullable<decimal> ReturnAmount { get; set; }

		public Nullable<decimal> TotalTP { get; set; }
		public Nullable<decimal> TotalVAT { get; set; }
		public Nullable<decimal> Amount { get; set; }
		public string ProductName { get; set; }

		public Nullable<int> QuantityAfterBonus { get; set; }
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
		public string BatchNo { get; set; }
	}
}
