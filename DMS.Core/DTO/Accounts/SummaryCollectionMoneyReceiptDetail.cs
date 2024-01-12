using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Accounts
{
	[Keyless]
    public class SummaryCollectionMoneyReceiptDetail
    {
		public string CollectionCode { get; set; }
        public Nullable<DateTime> CollectionDate { get; set; }

        public string InvoiceCode { get; set; }
        public string ChemistCode { get; set; }
        public string ChemistName { get; set; }
        public string PaymentMode { get; set; }
        public Nullable<decimal> CashCollectionAmount { get; set; }
		public Nullable<decimal> ChequeCollectionAmount { get; set; }
		public Nullable<decimal> Amount { get; set; }
        public string InstrumentNumber { get; set; }
    }
}
