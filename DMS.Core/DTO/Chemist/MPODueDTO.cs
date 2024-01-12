using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Chemist
{
    [Keyless]
   public class MPODueDTO
    {
		public string TerritoryCode { get; set; }

		public string TerritoryName { get; set; }
		public string EmployeeName { get; set; }
		public string EmployeeCode { get; set; }
		public Nullable<decimal> InvoiceAmount { get; set; }
		public Nullable<decimal> PaidAmount { get; set; }

		public Nullable<decimal> DueAmount { get; set; }

	}
}
