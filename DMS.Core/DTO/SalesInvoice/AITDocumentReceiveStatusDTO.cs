using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.SalesInvoice
{
    [Keyless]

    public class AITDocumentReceiveStatusDTO
    {
        public string SummaryCode { get; set; }
        public string InvoiceCode { get; set; }
        public Nullable<DateTime> InvoiceDate { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public decimal? AITDeductionAmount { get; set; }
        public string ChemistCode { get; set; }
        public string ChemistName { get; set; }

    }
}
