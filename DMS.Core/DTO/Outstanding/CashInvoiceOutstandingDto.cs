using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DMS.Core.DTO.Outstanding
{
	[Keyless]
    public class CashInvoiceOutstandingDto
    {
		public string SummaryCode { get; set; }

		public Nullable<DateTime> SummaryDate { get; set; }
		public string AllocationCode { get; set; }
		public string DACode { get; set; }
		public string InvoiceCode { get; set; }
		public Nullable<decimal> InvoiceAmount { get; set; }

		public Nullable<DateTime> InvoiceDate { get; set; }
		public string PaymentMode { get; set; }
		public Nullable<int> InvoiceAge { get; set; }
		public Nullable<int> SummaryAge { get; set; }
		public Nullable<decimal> PaidAmount { get; set; }

		public Nullable<decimal> DueAmount { get; set; }
		public string DAName { get; set; }
		public Nullable<DateTime> AllocationDate { get; set; }
		public string MPOCode { get; set; }
		public string MPOName { get; set; }
		public string ChemistCode { get; set; }
		public string ChemistName { get; set; }

		public string TerritoryCode { get; set; }
		public string TerritoryName { get; set; }

        public bool IsExists { get; set; }
	}
    public class OutstandingDto
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Code { get; set; }
        public string PaymentMode { get; set; }
    }
    [Keyless]

    public class OutstandingMasterDto
    {
        public string TerritoryCode { get; set; }

        public string MPOName { get; set; }
        public string EmployeeID { get; set; }
        public string TerritoryName { get; set; }
        public int totalInvoiceAmount { get; set; }
        public int totalPaidAmount { get; set; }
        public int totalDueAmount { get; set; }
        public string PaymentMode { get; set; }
        public string ASMName { get; set; }
        public string ASMCode { get; set; }





        public List<CashInvoiceOutstandingDto> list { get; set; }

    }

}
