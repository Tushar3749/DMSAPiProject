using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.Orders
{
	[Keyless]
    public class TerritoryChemistDto 
	{
		public string ChemistID { get; set; }

		public string ChemistName { get; set; }
		public Nullable<int> ChemistNumber { get; set; }
		public string Address { get; set; }
	}


}
