using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.SalesInvoice
{
    [Keyless]
    public class InvoiceCollectionStatusDTO
    {
	    public string InvoiceCode { get; set; }

        public Nullable<DateTime> InvoiceDate { get; set; }
        public Nullable<DateTime> CollectionDate { get; set; }
        public string ChemistCode { get; set; }
        public string MPOCode { get; set; }
        public string CollectionCode { get; set; }
        public Nullable<decimal> ChequeCollectionAmount { get; set; }
        public Nullable<decimal> CashCollectionAmount { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string MoneyReceiptCode { get; set; }
        public Nullable<DateTime> MoneyReceiptDate { get; set; }
        public string PaymentMode { get; set; }

    }
}
