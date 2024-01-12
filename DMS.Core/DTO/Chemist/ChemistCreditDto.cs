using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.Chemist
{

    [Keyless]
	public class ChemistCreditDto
	{
		public string ChemistID { get; set; }

		public string CreditType { get; set; }
		public Nullable<int> LimitAmount { get; set; }
		public Nullable<int> CreditDays { get; set; }
		public Nullable<Boolean> AllowDiscount { get; set; }
		public Nullable<Boolean> AllowBonus { get; set; }

		public Nullable<Boolean> IsMultipleInvoice { get; set; }
		public Nullable<DateTime> EffectiveFrom { get; set; }
		public Nullable<DateTime> ExpiryDate { get; set; }
		public Nullable<Boolean> IsTransferred { get; set; }

		public string CreatedByID { get; set; }
	}
}
