using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.Discount
{
	[Keyless]
    public class DiscountDetailDto 
	{
		public Nullable<int> ID { get; set; }

		public string DiscountCode { get; set; }
		public string ProductCode { get; set; }
		public string ProductName { get; set; }
		public string DosageFormName { get; set; }
		public Nullable<decimal> TP { get; set; }

		public Nullable<decimal> VAT { get; set; }
		public string packsize { get; set; }
		public Nullable<decimal> Amount { get; set; }
		public Nullable<decimal> MRP { get; set; }
		public Nullable<decimal> InvoiceAmount { get; set; }

		public Nullable<Boolean> IsAmountInPercent { get; set; }
		public Nullable<decimal> MinimumOrder { get; set; }
		public Nullable<decimal> MaximumOrder { get; set; }
	}
}
