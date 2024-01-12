using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.CreditNote
{
    public partial class CreditNoteAdjustment
    {
        public int Id { get; set; }
        public string AdjustmentCode { get; set; }
        public string ChemistCode { get; set; }
        public string InvoiceCode { get; set; }
        public decimal Amount { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
