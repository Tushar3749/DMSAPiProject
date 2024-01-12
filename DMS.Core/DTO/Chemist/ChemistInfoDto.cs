using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Chemist
{
	[Keyless]
    public class ChemistInfoDto
    {
		public string ChemistID { get; set; }

		public string ChemistName { get; set; }
		public string DepotCode { get; set; }
		public string ContactPerson { get; set; }
		public string Mobile { get; set; }
		public string Phone { get; set; }

		public string Fax { get; set; }
		public string House { get; set; }
		public string Road { get; set; }
		public string Area { get; set; }
		public string City { get; set; }

		public string AddressDetail { get; set; }
		public string ChemistTypeCode { get; set; }
		public string TypeName { get; set; }
		public string MarketCode { get; set; }
		public string MarketName { get; set; }

		public string TerritoryCode { get; set; }
		public string TerritoryName { get; set; }
		public string AreaCode { get; set; }
		public string AREANAME { get; set; }
		public Nullable<int> LimitAmount { get; set; }
		public Nullable<int> CreditDays { get; set; }
	}
}
