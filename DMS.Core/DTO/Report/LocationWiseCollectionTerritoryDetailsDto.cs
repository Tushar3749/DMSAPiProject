using System;

namespace DMS.Core.DTO.Report
{
    public class LocationWiseCollectionTerritoryDetailsDto
    {
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
