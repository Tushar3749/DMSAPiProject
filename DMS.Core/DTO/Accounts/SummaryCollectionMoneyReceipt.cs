using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Accounts
{
	[Keyless]
    public class SummaryCollectionMoneyReceipt
    {
		public string CollectionCode { get; set; }

		public string SummaryCode { get; set; }
		public Nullable<DateTime> CollectionDate { get; set; }
		public Nullable<int> NumberOfInstrument { get; set; }
		public Nullable<int> NumberOfInvoice { get; set; }
		public Nullable<int> NoOfDaysPassed {  get; set; }
		public Nullable<decimal> CashCollectionAmount { get; set; }

		public Nullable<decimal> ChequeCollectionAmount { get; set; }
		public Nullable<decimal> Amount { get; set; }
		public string DACode { get; set; }
		public string EmployeeName { get; set; }
		public string Mobile { get; set; }
		public bool? IsReturnDone { get; set; }
	}
}
