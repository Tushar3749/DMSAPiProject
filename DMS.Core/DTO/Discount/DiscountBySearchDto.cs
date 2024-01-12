using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.Chemist
{

		/*
	 *=============================================
	 *Author: Shamsul Hasan Siam
	 *Email: siam.it@labaidpharma.com
	 *Created on: 21 JUNE 2021
	 *Updated on: 
	 *Last updated on:
	 *Description: <>
	 *=============================================
	*/

	[Keyless]
    public class DiscountBySearchDto
    {
		public string ChemistCode { get; set; }

		public string ChemistName { get; set; }
		public string DiscountCode { get; set; }
		public Nullable<int> NoOfProduct { get; set; }
		public Nullable<DateTime> EffectiveFrom { get; set; }
		public Nullable<DateTime> ExpiryDate { get; set; }

		public string TerritoryID { get; set; }
		public string MPOID { get; set; }
		public string MPOName { get; set; }
		public string AreaID { get; set; }
		public string AreaManagerID { get; set; }

		public string AreaManagerName { get; set; }
		public string RegionID { get; set; }
		public string RegionalManagerID { get; set; }
		public string RegionalManagerName { get; set; }

		public string TerritoryName { get; set; }

		public string AreaName { get; set; }
		public string RegionName { get; set; }
		/*
	 *=============================================
	 * END Of Author Shamsul Hasan Siam
	 *=============================================
	*/
	}
}
