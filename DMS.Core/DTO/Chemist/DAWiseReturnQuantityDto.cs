using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.Chemist
{
	[Keyless]
    public class DAWiseReturnQuantityDto
    {
		public string EmployeeID { get; set; }
		public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public Nullable<DateTime> DOJ { get; set; }

        public Nullable<int> NumberOfAllocation { get; set; }
		public Nullable<int> NumberOfInvoice { get; set; }
		public Nullable<decimal> TotalInvoiceAmount { get; set; }
		public Nullable<decimal> TotalSummaryInvoiceAmount { get; set; }

		public Nullable<decimal> TotalReturnAmount { get; set; }
		public Nullable<decimal> TotalReturnAmountInPercent { get; set; }
	}
}
