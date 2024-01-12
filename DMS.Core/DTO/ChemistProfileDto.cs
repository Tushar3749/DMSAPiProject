using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO
{
	[Keyless]
	public class ChemistDetailDto
	{
	
		public string ChemistID { get; set; }

		public Nullable<int> ChemistNumber { get; set; }
		public string ChemistName { get; set; }
		public string Mobile { get; set; }
		public string DepoID { get; set; }
		public string ChemistAddress { get; set; }

		public string Remarks { get; set; }
	}
}
