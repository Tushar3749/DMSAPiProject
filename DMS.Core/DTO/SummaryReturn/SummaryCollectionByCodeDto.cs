using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.SummaryReturn
{
	[Keyless]
    public class SummaryCollectionByCodeDto
	{
		public string CollectionCode { get; set; }

		public Nullable<DateTime> CollectionDate { get; set; }
		public Nullable<decimal> CashCollectionAmount { get; set; }
		public Nullable<decimal> ChequeCollectionAmount { get; set; }
		public Nullable<decimal> Amount { get; set; }
		public string SummaryCode { get; set; }

		public Nullable<DateTime> SummaryDate { get; set; }
		public string DACode { get; set; }
		public string DAName { get; set; }
		public string MoneyReceiptCode { get; set; }
		public Nullable<Boolean> IsMoneyReceiptDone { get; set; }

	}
}
