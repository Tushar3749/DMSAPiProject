using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.CreditNote
{
    public partial class CreditNoteDueAdjustmentDetail
    {
        public int Id { get; set; }
        public string AdjustmentCode { get; set; }
        public string InvoiceCode { get; set; }
        public string CreditNoteCode { get; set; }
        public decimal AdjustedAmount { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
