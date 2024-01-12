using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.Orders
{
	[Keyless]
    public class InvoicePendingOrdersDto
    {
		public string OrderCode { get; set; }

		public Nullable<DateTime> OrderDate { get; set; }
		public string ChemistCode { get; set; }
		public string ChemistName { get; set; }
		public string ChemistAddress { get; set; }
		public string PaymentMode { get; set; }
		public string OrderMedia { get; set; }

		public Nullable<DateTime> DeliveryDate { get; set; }
		public string DeliveryTime { get; set; }
		public string Remarks { get; set; }
		public Nullable<int> NoOfProduct { get; set; }
		public string TerritoryCode { get; set; }

		public string TerritoryName { get; set; }
		public string MPOCode { get; set; }
		public string MPOName { get; set; }
		public Nullable<Boolean> HasChemistSpecialDiscount { get; set; }
	}
}
