using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.Report.Outstanding
{
	[Keyless]
    public class LocationWiseOutstandingDetailDto
    {
		public string? TerritoryName { get; set; }

		public string? AreaCode { get; set; }
		public string? AreaName { get; set; }
		public string? AreaManagerID { get; set; }
		public string? AreaManagerName { get; set; }
		public string? InvoiceCode { get; set; }
		public Nullable<DateTime> InvoiceDate { get; set; }
		public string? EmployeeCode { get; set; }

		public string? ChemistCode { get; set; }
		public string? TerritoryCode { get; set; }
		public string? PaymentMode { get; set; }
		public Nullable<decimal> TP { get; set; }
		public Nullable<decimal> Vat { get; set; }

		public Nullable<decimal> ProductDiscount { get; set; }
		public Nullable<decimal> AmountDiscount { get; set; }
		public Nullable<decimal> InvoiceAmount { get; set; }
		public Nullable<decimal> PaidAmount { get; set; }
		public string? AllocationCode { get; set; }

		public Nullable<DateTime> AllocationDate { get; set; }
		public string? DACode { get; set; }
		public string? SummaryCode { get; set; }
		public Nullable<DateTime> SummaryDate { get; set; }
		public string? MPOID { get; set; }

		public string? MPOName { get; set; }
		public string? DAName { get; set; }
		public string? ChemistName { get; set; }
		public string? AddressDetail { get; set; }
		public Nullable<decimal> DueAmount { get; set; }
		public Nullable<int> CreditDays { get; set; }
		public Nullable<int> DueDurationDays { get; set; }
	}
}
