using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.BonusAndDiscount
{

	[Keyless]
	public class ChemistDiscountAndBonusDto
    {
		public string ProductCode { get; set; }

		public Nullable<int> Quantity { get; set; }
		public Nullable<int> QuantityAfterBonus { get; set; }
		public Nullable<int> BonusQuantity { get; set; }
		public Nullable<decimal> ProductDiscount { get; set; }
		public string AppliedDiscountRuleNumbers { get; set; }
		public Nullable<decimal> FacilityAmount { get; set; }

		public Nullable<Boolean> IsAmountInPercent { get; set; }
		public Nullable<Boolean> IsInvoiceAmountDiscountApplicable { get; set; }
		public string DiscountCode { get; set; }
		public string BonusSegment { get; set; }
	}
}
