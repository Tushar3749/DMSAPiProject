using System;

namespace DMS.Core.DTO.Report
{
    public class LocationWiseOutstandingTerritoryDetailsDTO
    {
		public string RegionID { get; set; }

		public string RegionName { get; set; }
		public string RegionalManagerID { get; set; }
		public string RegionalManagerName { get; set; }
		public string AreaID { get; set; }
		public string AreaName { get; set; }

		public string AreaManagerID { get; set; }
		public string AreaManagerName { get; set; }
		public string TerritoryID { get; set; }
		public string TerritoryName { get; set; }
		public string MPOID { get; set; }

		public string MPOName { get; set; }
		public string TerritoryCode { get; set; }
		public Nullable<decimal> InvoiceAmount { get; set; }
		public Nullable<decimal> PaidAmount { get; set; }
		public Nullable<decimal> DueAmountCash { get; set; }

		public Nullable<decimal> DueAmountCredit { get; set; }
		public Nullable<decimal> DueAmount { get; set; }
		public Nullable<decimal> OverDueAmountCash { get; set; }
		public Nullable<decimal> OverDueAmountCredit { get; set; }
		
	}
}
