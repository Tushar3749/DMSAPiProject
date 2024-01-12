using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.DataValidation
{
    [Keyless]
    public class DataValidationRegionWiseCollectionDto
    {
		public string TerritoryCode { get; set; }
		public string TerritoryName { get; set; }
		public string AreaCode { get; set; }
		public string AreaName { get; set; }
		public string RegionCode { get; set; }
		public string RegionName { get; set; }
		public string InvoiceCode { get; set; }
		public string PaymentMode { get; set; }
		public string ChemistID { get; set; }

		public string ChemistName { get; set; }
		public Nullable<decimal> InvoiceAmount { get; set; }
		public Nullable<decimal> CollectionAmount { get; set; }
		public string InvoiceStatus { get; set; }
	}
}
