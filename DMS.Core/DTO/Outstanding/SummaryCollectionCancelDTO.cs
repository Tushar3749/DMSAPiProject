using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Outstanding
{
	[Keyless]
    public class SummaryCollectionCancelDTO
    {
		public string CollectionCode { get; set; }
		public string PaymentMode { get; set; }
		public Nullable<decimal> CashCollectionAmount { get; set; }
		public Nullable<decimal> ChequeCollectionAmount { get; set; }

		public Nullable<decimal> PaidAmount { get; set; }
		public string SummaryCode { get; set; }
	
		public string InvoiceCode { get; set; }
		public Nullable<DateTime> InvoiceDate { get; set; }
		public string ChemistCode { get; set; }

		public string ChemistName { get; set; }

		public Nullable<decimal> NetAmount { get; set; }

		public string TerritoryCode { get; set; }
	}



	[Keyless]

	public class SummaryInvoiceCancelDTO
	{
		public string InvoiceCode { get; set; }

		public string TerritoryCode { get; set; }
		public string ChemistName { get; set; }
		public string ChemistCode { get; set; }
		public Nullable<decimal> NetTP { get; set; }
		public Nullable<decimal> NetAmountDiscount { get; set; }

		public Nullable<decimal> NetProductDiscount { get; set; }
		public Nullable<decimal> NetVat { get; set; }
		public Nullable<decimal> NetAmount { get; set; }
	}


}
