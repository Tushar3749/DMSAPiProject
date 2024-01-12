using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO
{
    [Keyless]
    public class CreditAvailableforInvoice
    {
        public bool IsCreditAvailableForNewInvoice { get; set; }
        public decimal? CreditLimit { get; set; }
        public decimal? DueAmount { get; set; }
        public bool IsInvoiceCreditDaysAvailable { get; set; }
        public string? CreditInvoice { get; set; }
        public int? PreviuosDueInvoiceCreditDays { get; set; }
    }
}
