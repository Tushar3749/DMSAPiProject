using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.Chemist
{
    [Keyless]
	public class ChemistTerritoryDto
	{
		public Nullable<int> ID { get; set; }

		public string ChemistID { get; set; }
		public string TerritoryID { get; set; }
		public Nullable<Boolean> IsTransferred { get; set; }
		public string CreatedByID { get; set; }

	}

}
