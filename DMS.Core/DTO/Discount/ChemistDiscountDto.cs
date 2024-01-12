using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.Discount
{

	[Keyless]
    public class ChemistDiscountDto
    {
		public string DiscountCode { get; set; }

		public string Description { get; set; }
		public string ChemistCode { get; set; }
		public Nullable<int> NumberOfProducts { get; set; }
		public Nullable<DateTime> EffectiveFrom { get; set; }
		public Nullable<DateTime> ExpiryDate { get; set; }
		public Nullable<Boolean> IsActive { get; set; }
		public string CreatedByID { get; set; }
		public string Remarks { get; set; }
		public string Updatedby { get; set; }
	}
}
