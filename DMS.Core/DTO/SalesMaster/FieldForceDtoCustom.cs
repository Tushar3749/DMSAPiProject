using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.SalesMaster
{
	[Keyless]
	public class FieldForceDtoCustom
	{

		//public List<ZMDetails> ZMs { get; set; }
		public List<RMDetails> RMs { get; set; }

	}


	public class MPODetails
	{
		public string AreaCode { get; set; }
		public string TerritoryCode { get; set; }
        public string TERRITORYNAME { get; set; }
        public string MPOID { get; set; }
        public string MPOName { get; set; }
        public string MPOPhoneNumber { get; set; }
        public Nullable<decimal> MPOTargetShare { get; set; }
    }

	public class AMDetails
    {
		public string RegionCode { get; set; } = string.Empty;
		public string AreaCode { get; set; }
		public string AREANAME { get; set; }
		public string AreaManagerID { get; set; }
		public string AreaManagerName { get; set; }
		public string AreaManagerMobileNumber { get; set; } = string.Empty;
		public Nullable<decimal> AMTargetShare { get; set; }

		public List<MPODetails> MPOs { get; set; }
    }

	public class RMDetails
    {
        public string ZoneCode { get; set; }
        public string RegionCode { get; set; }
		public string REGIONNAME { get; set; }
		public string RegionalManagerID { get; set; }
		public string RegionalManagerName { get; set; }
		public string RegionManagerMobileNumber { get; set; }
		public Nullable<decimal> RMTargetShare { get; set; }
		public List<AMDetails> AMs { get; set; }
    }

	//public class ZMDetails
 //   {
	//	public string OACode { get; set; }
	//	public string ZoneCode { get; set; }
	//	public string ZONENAME { get; set; }
	//	public string ZonalManagerID { get; set; }
	//	public string ZonalManagerName { get; set; }
	//	public string ZoneMangerMobileNumber { get; set; }
	//	public Nullable<decimal> ZMTargetShare { get; set; }
	//	public List<RMDetails> RMs { get; set; }
 //   }


}