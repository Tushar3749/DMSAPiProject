using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.SalesInvoice
{
    [Keyless]

    public class InvoiceAllocationDispatchDTO
    {
        public string ProductName { get; set; }
        public string SalesCode { get; set; }
        public string PackSize { get; set; }

        public string BatchNo { get; set; }

        public int? Quantity { get; set; }

        //public decimal? ProductTP { get; set; }

        //public decimal? ProductVat { get; set; }

        //public string AllocationCode { get; set; }


        //public string DAName { get; set; }


        //public string TerritoryCode { get; set; }
        //public string InvoiceCode { get; set; }

        //public string ChemistName { get; set; }


    }
}
