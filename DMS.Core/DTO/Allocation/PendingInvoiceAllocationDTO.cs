using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.SalesInvoice
{
   public class PendingInvoiceAllocationDTO
    {
        public int Id { get; set; }

        public string InvoiceCode { get; set; }
        public Nullable<DateTime> InvoiceDate { get; set; }
        public string ChemistCode { get; set; }

        public string TerritoryCode { get; set; }

        public Nullable<decimal> NetAmount { get; set; }

        public string ChemistName { get; set; }
        public string PaymentMode { get; set; }


        public string ChemistAddress { get; set; }

        public Nullable<decimal> Discount { get; set; }

        public Nullable<decimal> NetTP { get; set; }

        public Nullable<decimal> NetVat { get; set; }

       public int? ProductsNo { get; set; }











    }
}
