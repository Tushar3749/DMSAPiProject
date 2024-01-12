using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.CreditNote
{
    public partial class CreditNoteAdjustmentDetail
    {
        public int Id { get; set; }
        public string AdjustmentCode { get; set; }
        public string CreditNoteCode { get; set; }
        public decimal Amount { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
