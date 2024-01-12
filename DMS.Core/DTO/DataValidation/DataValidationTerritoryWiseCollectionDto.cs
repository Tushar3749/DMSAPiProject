using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.DataValidation
{
    [Keyless]
    public class DataValidationTerritoryWiseCollectionDto
    {
        public string CollectionCode { get; set; }

        public Nullable<DateTime> CollectionDate { get; set; }
        public Nullable<decimal> CashCollecAmount { get; set; }
        public Nullable<decimal> ChequeCollecAmount { get; set; }
        public string SummaryCode { get; set; }

        public Nullable<DateTime> SummaryDate { get; set; }
        public string DACode { get; set; }
        public string DAName { get; set; }

        //public string TerritoryCode { get; set; }
        //public string TerritoryName { get; set; }
        //public string InvoiceCode { get; set; }
		//public string PaymentMode { get; set; }
		//public string ChemistID { get; set; }
		//public string ChemistName { get; set; }
		public Nullable<decimal> InvoiceAmount { get; set; }

		public Nullable<decimal> Amount { get; set; }
		public string InvoiceStatus { get; set; }
    }
}
