using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.Chemist
{
	[Keyless]
    public class ChemistBusinessDateWiseDto
	{
		public string ChemistCode { get; set; }

		public string ChemistName { get; set; }
		public string SalesCode { get; set; }
		public string ProductCode { get; set; }
		public string ProductName { get; set; }
		public Nullable<decimal> TP { get; set; }
        public Nullable<decimal> TPVat { get; set; }

        public Nullable<int> SoldQty { get; set; }

		public Nullable<int> SoldBonusQty { get; set; }
		public Nullable<int> ReturnQty { get; set; }
		public Nullable<int> TransitQty { get; set; }
		public Nullable<int> TransitBonusQty { get; set; }
	}

}
