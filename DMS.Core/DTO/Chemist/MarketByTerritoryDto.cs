using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.Chemist
{
	[Keyless]
    public class MarketByTerritoryDto
	{
		public string MarketCode { get; set; }

		public string MarketName { get; set; }
		public Nullable<int> NumberOfChemist { get; set; }
	}

}
