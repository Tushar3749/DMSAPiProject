using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.SalesOrder
{
	[Keyless]
    public class ChemistsDto 
	{
		public string ChemistID { get; set; }

		public string ChemistName { get; set; }
		public Nullable<int> ChemistNumber { get; set; }
		public Nullable<int> CreditAmount { get; set; }
		public Nullable<int> CreditDays { get; set; }
		public string ChemistAddress { get; set; }

		public string ContactPerson1 { get; set; }
		public string Mobile { get; set; }
	}

}
