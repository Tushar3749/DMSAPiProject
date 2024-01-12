using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO
{
    [Keyless]
	public class LocationWiseCollectionReportDTO
    {
		public string? RegionID { get; set; }

		public string? RegionName { get; set; }
		public string? RegionalManagerID { get; set; }
		public string? RegionalManagerName { get; set; }
		public string? AreaID { get; set; }
		public string? AreaName { get; set; }

		public string? AreaManagerID { get; set; }
		public string? AreaManagerName { get; set; }
		public string? TerritoryID { get; set; }
		public string? TerritoryName { get; set; }
		public string? MPOID { get; set; }

		public string? MPOName { get; set; }
		public Nullable<decimal> CashCollectionAmount { get; set; }
		public Nullable<decimal> ChequeCollectionAmount { get; set; }
		public Nullable<decimal> TotalCollection { get; set; }
		public Nullable<decimal> CashInvoiceCollection { get; set; }

		public Nullable<decimal> CreditInvoiceCollection { get; set; }

	}
}
