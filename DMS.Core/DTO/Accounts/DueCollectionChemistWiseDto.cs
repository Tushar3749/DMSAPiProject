using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Accounts
{
	[Keyless]
    public class DueCollectionChemistWiseDto
    {
		public string ChemistCode { get; set; }

		public string ChemistName { get; set; }
		public Nullable<int> NoOfInvoice { get; set; }
		public Nullable<int> NoOfDays { get; set; }
		public Nullable<int> NoOfCash { get; set; }
		public Nullable<int> NoOfCredit { get; set; }

		public Nullable<decimal> DueAmount { get; set; }
	}
}
