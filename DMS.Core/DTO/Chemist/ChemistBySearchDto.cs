using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.Chemist
{
	[Keyless]
    public class ChemistBySearchDto
	{
		public string? MarketName { get; set; }
		public string? ChemistID { get; set; }
		public string? MarketCode { get; set; }
		public string? ChemistName { get; set; }
		public string? AddressDetail { get; set; }
		public string? ChemistTypeCode { get; set; }
		public string? ChemistTypeName { get; set; }
		public string? TerritoryID { get; set; }

		public string? TerritoryName { get; set; }
		public string? AreaID { get; set; }
		public string? AreaName { get; set; }
		public Nullable<int> CreditDays { get; set; }
		public Nullable<DateTime> EffectiveFrom { get; set; }

		public Nullable<DateTime> ExpiryDate { get; set; }
		public Nullable<int> LimitAmount { get; set; }
	}

}
