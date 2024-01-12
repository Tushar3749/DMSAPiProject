using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Accounts
{
	[Keyless]
    public class SummaryCollectionMoneyReceiptInstrument
    {
		public string CollectionCode { get; set; }

		public string ChemistCode { get; set; }
		public string InstrumentNumber { get; set; }
		public Nullable<decimal> Amount { get; set; }
		public string InstrumentType { get; set; }
		public string InstrumentBank { get; set; }

		public Nullable<DateTime> InstrumentDate { get; set; }
	}
}
