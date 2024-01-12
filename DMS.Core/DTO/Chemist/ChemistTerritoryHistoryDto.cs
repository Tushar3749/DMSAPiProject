using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Chemist
{
	[Keyless]
	public class ChemistTerritoryHistoryDto 
	{
		public string EmployeeID { get; set; }

		public string EmployeeName { get; set; }
		public Nullable<int> NumberOfAllocation { get; set; }
		public Nullable<int> NumberOfInvoice { get; set; }
		public Nullable<decimal> TotalInvoiceAmount { get; set; }
		public Nullable<decimal> TotalSummaryInvoiceAmount { get; set; }

		public Nullable<decimal> TotalReturnAmount { get; set; }
		public Nullable<decimal> TotalReturnAmountInPercent { get; set; }
	}
}
