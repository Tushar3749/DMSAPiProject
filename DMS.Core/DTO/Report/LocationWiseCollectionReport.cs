using System;
using System.Collections.Generic;

namespace DMS.Core.DTO.Report
{
    public class LocationWiseCollectionReport
    {
		public string RegionID { get; set; }
		public string RegionName { get; set; }
		public string RegionalManagerID { get; set; }
		public string RegionalManagerName { get; set; }

		public string AreaID { get; set; }
		public string AreaName { get; set; }
		public string AreaManagerID { get; set; }
		public string AreaManagerName { get; set; }
		public Nullable<decimal> CashCollectionAmount { get; set; }
		public Nullable<decimal> ChequeCollectionAmount { get; set; }
		public Nullable<decimal> TotalCollection { get; set; }
		public Nullable<decimal> CashInvoiceCollection { get; set; }
		public Nullable<decimal> CreditInvoiceCollection { get; set; }

		public List<LocationWiseCollectionTerritoryDetailsDto> TerritoryDetail { get; set; }
	}
}
