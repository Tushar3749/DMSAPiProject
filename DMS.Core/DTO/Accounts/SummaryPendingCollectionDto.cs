using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Accounts
{
	[Keyless]
    public class SummaryPendingCollectionDto
    {
		public string SummaryCode { get; set; }

		public Nullable<DateTime> SummaryDate { get; set; }
		public string AllocationCode { get; set; }
		public string DACode { get; set; }
		public string PaymentMode { get; set; }
		public string EmployeeName { get; set; }

		public Nullable<int> NoOfDays { get; set; }
		public Nullable<int> NoOfChemist { get; set; }
		public Nullable<int> NoOfInvoice { get; set; }
		public Nullable<decimal> DueAmount { get; set; }
	}
}
