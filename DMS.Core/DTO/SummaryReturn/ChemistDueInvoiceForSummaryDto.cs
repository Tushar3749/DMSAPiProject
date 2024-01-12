using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO
{
	[Keyless]
    public class ChemistDueInvoiceForSummaryDto 
	{
		//Added By Siam
		//Added on 10 JULY 2021
		public string InvoiceCode { get; set; }

		public Nullable<decimal> InvoiceAmount { get; set; }
		public Nullable<DateTime> InvoiceDate { get; set; }
		public string PaymentMode { get; set; }
		public Nullable<int> Age { get; set; }
		public Nullable<decimal> PaidAmount { get; set; }

		public Nullable<decimal> DueAmount { get; set; }
		public Nullable<decimal> NewPaidAmount { get; set; }
		public string ChemistCode { get; set; }
		public string ChemistName { get; set; }


		//END Of Author Shamsul Hasan Siam
	}

}
