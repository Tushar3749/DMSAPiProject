using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.Discount
{
    [Keyless]
    public class DiscountReportDto
    {
		public string DiscountCode { get; set; }

		public string Description { get; set; }
		public string ChemistCode { get; set; }
		public string ChemistName { get; set; }
		public string TerritoryID { get; set; }
		public string TerritoryName { get; set; }

		public string DepotCode { get; set; }
		public Nullable<DateTime> EffectiveFrom { get; set; }
		public Nullable<DateTime> ExpiryDate { get; set; }
		public Nullable<Boolean> IsPolicyForAllChemist { get; set; }
		public string DiscountCategoryCode { get; set; }

		public Nullable<Boolean> IsPolicyForAllProduct { get; set; }
		public string CreatedByID { get; set; }
		public string Remarks { get; set; }

		public string Updatedby { get; set; }
	}
}
