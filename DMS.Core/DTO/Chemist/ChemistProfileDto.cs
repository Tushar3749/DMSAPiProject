using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.Chemist
{
    [Keyless]
    public class ChemistCreditDuesDto
    {
        public string InvoiceCode { get; set; }

        public string SummaryCode { get; set; }
        public Nullable<decimal> DUEAMOUNT { get; set; }
    }
}
