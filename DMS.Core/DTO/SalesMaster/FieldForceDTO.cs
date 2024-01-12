using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.SalesMaster
{
	[Keyless]
	public class FieldForceDto 
	{
		public string OACode { get; set; }

		public string LocationName { get; set; }
		public string OAManagerID { get; set; }
		public string OAManagerName { get; set; }
		public string OAManagerMobileNumber { get; set; }
		public string ZoneCode { get; set; }

		public string ZONENAME { get; set; }
		public string ZonalManagerID { get; set; }
		public string ZonalManagerName { get; set; }
		public string ZoneMangerMobileNumber { get; set; }
		public string RegionCode { get; set; }

		public string REGIONNAME { get; set; }
		public string RegionalManagerID { get; set; }
		public string RegionalManagerName { get; set; }
		public string RegionManagerMobileNumber { get; set; }
		public string AreaCode { get; set; }

		public string AREANAME { get; set; }
		public string AreaManagerID { get; set; }
		public string AreaManagerName { get; set; }
		public string AreaManagerMobileNumber { get; set; }
		public string TerritoryCode { get; set; }

		public string TERRITORYNAME { get; set; }
		public string MPOID { get; set; }
		public string MPOName { get; set; }
		public string MPOPhoneNumber { get; set; }
		public Nullable<decimal> MPOTargetShare { get; set; }

		public Nullable<decimal> AMTargetShare { get; set; }
		public Nullable<decimal> ZMTargetShare { get; set; }
		public Nullable<decimal> OATargetShare { get; set; }
		public Nullable<decimal> RMTargetShare { get; set; }
	}
}
