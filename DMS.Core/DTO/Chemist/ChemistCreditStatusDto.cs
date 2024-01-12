using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Chemist
{
	[Keyless]
	public class ChemistCreditStatusDto
	{
		public Nullable<decimal> CreditLimit { get; set; }

		public Nullable<int> CreditDays { get; set; }
		public Nullable<decimal> DueAmount { get; set; }
		public Nullable<decimal> CreditAvaiableAmount { get; set; }
		public string LastInvoiceCode { get; set; }
		public Nullable<decimal> LastInvoiceAmount { get; set; }

	}
}
