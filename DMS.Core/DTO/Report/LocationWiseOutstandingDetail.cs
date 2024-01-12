using DMS.Core.DTO.Report.Outstanding;
using System;
using System.Collections.Generic;

namespace DMS.Core.DTO.Report
{
    public class LocationWiseOutstandingDetail
	{
		public string? TerritoryName { get; set; }

		public string? AreaCode { get; set; }
		public string? AreaName { get; set; }
		public string? AreaManagerID { get; set; }
		public string? AreaManagerName { get; set; }
		public string? TerritoryCode { get; set; }

		public Nullable<decimal> InvoiceAmount { get; set; }
		public Nullable<decimal> PaidAmount { get; set; }
		public Nullable<decimal> DueAmount { get; set; }

		public List<LocationWiseOutstandingDetailDto> TerritoryInvoices { get; set; }
	}
}
