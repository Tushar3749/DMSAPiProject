using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.Report
{
	[Keyless]
    public class OrderStatusReportDto 
	{
		public string OrderCode { get; set; }

		public Nullable<DateTime> OrderDate { get; set; }
		public string ChemistCode { get; set; }
		public string TerritoryCode { get; set; }
		public Nullable<DateTime> DeliveryDate { get; set; }
		public string PaymentMode { get; set; }

		public string OrderMedia { get; set; }
		public string InvoiceCode { get; set; }
		public Nullable<DateTime> InvoiceDate { get; set; }
		public Nullable<decimal> NetAmount { get; set; }
		public string AllocationCode { get; set; }

		public string SummaryCode { get; set; }
		public Nullable<decimal> SummaryInvoiceAmount { get; set; }
		public string CollectionCode { get; set; }
		public string MoneyReceiptCode { get; set; }
	}

}
