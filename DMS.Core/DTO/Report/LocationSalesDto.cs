using Microsoft.EntityFrameworkCore;

namespace DMS.Core.DTO.Report
{

	[Keyless]
	public class LocationRegionDto
	{
		public string RegionID { get; set; }

		public string RegionName { get; set; }
		public string RegionalManagerName { get; set; }
		public string RegionalManagerID { get; set; }
	}


	[Keyless]
	public class LocationAreaDto
	{
		public string AreaID { get; set; }

		public string RegionID { get; set; }
		public string RegionName { get; set; }
		public string RegionalManagerName { get; set; }
		public string RegionalManagerID { get; set; }
		public string AreaName { get; set; }

		public string AreaManagerID { get; set; }
		public string AreaManagerName { get; set; }
	}

	[Keyless]
	public class LocationTerritoryDto
	{
		public string TerritoryID { get; set; }
		public string AreaID { get; set; }
		public string RegionID { get; set; }
		public string RegionName { get; set; }
		public string RegionalManagerName { get; set; }
		public string RegionalManagerID { get; set; }
		public string AreaName { get; set; }
		public string AreaManagerID { get; set; }
		public string AreaManagerName { get; set; }
		public string TerritoryName { get; set; }
	}



	[Keyless]
	public class LocationSalesDto
    {
		public string AreaID { get; set; }

		public string AreaName { get; set; }
		public string AreaManagerID { get; set; }
		public string AreaManagerName { get; set; }
		public string TerritoryID { get; set; }
		public string TerritoryName { get; set; }

		public string MPOID { get; set; }
		public string MPOName { get; set; }
	}
}
