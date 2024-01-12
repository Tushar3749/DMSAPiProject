using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Accounts
{
	[Keyless]
    public class MoneyReceiptDto
    {
		public string MoneyReceiptCode { get; set; }

		public Nullable<DateTime> MoneyReceiptDate { get; set; }
		public string SummaryCollectionCode { get; set; }
		public Nullable<DateTime> CollectionDate { get; set; }
		public string CollectedFromCode { get; set; }
		public string EmployeeName { get; set; }

		public string Mobile { get; set; }
		public Nullable<decimal> ChequeAmount { get; set; }
		public Nullable<decimal> CashAmount { get; set; }
		public Nullable<decimal> Amount { get; set; }
	}
}
