using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Chemist
{
	[Keyless]
	public class ChemistDto
	{
		public string ChemistID { get; set; }

		public string ChemistName { get; set; }
		public string DepoID { get; set; }
		public string ContactPerson { get; set; }
		public string Mobile { get; set; }
		public string Phone { get; set; }

		public string Fax { get; set; }
		public string House { get; set; }
		public string Road { get; set; }
		public string Area { get; set; }
		public string City { get; set; }

		public string AddressDetail { get; set; }
		public string Remarks { get; set; }
		public Nullable<Boolean> IsTransferred { get; set; }
		public string ChemistTypeCode { get; set; }

		public string CreatedByID { get; set; }

		public string ChemistCreditInfo { get; set; }
		public string ChemistTerritoryInfo { get; set; }
	}
}
