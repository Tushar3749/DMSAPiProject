using System;

namespace DMS.Core.DTO.Accounts
{
    public class MoneyReceiptNewDto
    {
		public string CollectionCode { get; set; }

		public string SummaryCode { get; set; }
		public Nullable<DateTime> CollectionDate { get; set; }
		public Nullable<int> NumberOfInstrument { get; set; }
		public Nullable<int> NumberOfInvoice { get; set; }
		public Nullable<int> NoOfDaysPassed { get; set; }
		public Nullable<decimal> CashCollectionAmount { get; set; }

		public Nullable<decimal> ChequeCollectionAmount { get; set; }
		public Nullable<decimal> Amount { get; set; }
		public string DACode { get; set; }
		public string EmployeeName { get; set; }
		public string Mobile { get; set; }
		public string Remarks { get; set; }
		public bool? IsReturnDone { get; set; }
	}
}
