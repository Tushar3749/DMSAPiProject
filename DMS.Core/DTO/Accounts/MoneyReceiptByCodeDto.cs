﻿using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.Accounts
{
	[Keyless]
	public class MoneyReceiptByCodeDto 
	{
		public string MoneyReceiptCode { get; set; }

		public Nullable<DateTime> MoneyReceiptDate { get; set; }
		public string CollectedFromCode { get; set; }
		public string CollectedFromName { get; set; }
		public Nullable<decimal> CashAmount { get; set; }
		public Nullable<decimal> ChequeAmount { get; set; }

		public Nullable<decimal> Amount { get; set; }
		public string CollectionCode { get; set; }
		public Nullable<DateTime> CollectionDate { get; set; }
		public string SummaryCode { get; set; }
		public Nullable<DateTime> SummaryDate { get; set; }

		public string DACode { get; set; }
		public string DAName { get; set; }
	}
}
