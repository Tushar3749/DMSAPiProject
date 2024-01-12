using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Inventory
{
	[Keyless]
    public class DepotReceiveCreditNotePendingDto
    {
		public string ReceiveCode { get; set; }

		public Nullable<DateTime> ReceiveDate { get; set; }
		public string CreditNoteNo { get; set; }
		public Nullable<DateTime> CreditNoteDate { get; set; }
		public string ChemistCode { get; set; }
		public string ChemistName { get; set; }

		public string ToWarehouse { get; set; }
		public string ApprovedByCode { get; set; }
		public Nullable<DateTime> ApprovedDate { get; set; }
		public Nullable<int> NoOfProduct { get; set; }
		public Nullable<int> NoOfBatch { get; set; }

		public Nullable<decimal> TotalTP { get; set; }
		public Nullable<decimal> TotalVat { get; set; }
	}
}
