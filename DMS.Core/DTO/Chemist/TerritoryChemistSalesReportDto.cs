using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.Chemist
{
	[Keyless]
    public class TerritoryChemistSalesReportDto
    {
		public string? TerritoryCode { get; set; }

		public string? ChemistName { get; set; }
		public string? MarketCode { get; set; }
		public string? MarketName { get; set; }
		public string? ChemistCode { get; set; }
		public Nullable<decimal> TotalTP { get; set; }

		public Nullable<decimal> TotalVat { get; set; }
		public Nullable<decimal> TotalDiscount { get; set; }
		public Nullable<decimal> TotalAmount { get; set; }
	}
}
