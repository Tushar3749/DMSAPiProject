using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO
{
	[Keyless]
	public class AreaDto
	{
		public string AreaCode { get; set; }

		public string AreaManagerID { get; set; }
		public string AreaName { get; set; }
		public string AreaManagerName { get; set; }
		public Nullable<decimal> AMTargetShare { get; set; }
	}

    [Keyless]

    public class TerritoryDTO
    {
        public string TerritoryCode { get; set; }
        public string TerritoryName { get; set; }

    }

    [Keyless]

    public class RegionDTO
    {
        public string RegionCode { get; set; }
        public string RegionName { get; set; }

    }

}
