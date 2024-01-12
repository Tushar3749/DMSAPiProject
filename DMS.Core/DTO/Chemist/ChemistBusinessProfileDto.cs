using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Chemist
{
	[Keyless]
	public class ChemistBusinessProfileDto
	{
		public Nullable<DateTime> ReportMonth { get; set; }

		public Nullable<decimal> MonthlyTotal { get; set; }
	}

}
