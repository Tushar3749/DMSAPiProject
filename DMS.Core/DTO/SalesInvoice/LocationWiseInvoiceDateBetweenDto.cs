using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.SalesInvoice
{
	[Keyless]
    public class LocationWiseInvoiceDateBetweenDto
	{
		public string InvoiceCode { get; set; }

		public Nullable<DateTime> InvoiceDate { get; set; }
		public string ChemistCode { get; set; }
		public string ChemistName { get; set; }
		public string MPOCode { get; set; }
		public string MPOName { get; set; }

		public string TerritoryCode { get; set; }
		public string TERRITORYNAME { get; set; }
		public string PaymentMode { get; set; }
		public Nullable<decimal> NetTP { get; set; }
		public Nullable<decimal> NetVat { get; set; }

		public Nullable<decimal> NetProductDiscount { get; set; }
		public Nullable<decimal> NetAmountDiscount { get; set; }
		public Nullable<decimal> NetAmount { get; set; }
		public string AddressDetail { get; set; }
		public string AllocationCode { get; set; }

		public string DACode { get; set; }
		public string DAName { get; set; }
		public string SummaryCode { get; set; }
		public Nullable<decimal> SoldTP { get; set; }
		public Nullable<decimal> SoldVat { get; set; }

		public Nullable<decimal> SoldProductDiscount { get; set; }
		public Nullable<decimal> SoldAmountDiscount { get; set; }
		public Nullable<decimal> SoldAmount { get; set; }
	}
}
