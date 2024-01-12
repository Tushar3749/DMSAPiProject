using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.CreditNote
{
    public partial class CreditNoteDueAdjustment
    {
        public int Id { get; set; }
        public string AdjustmentCode { get; set; }
        public string ChemistCode { get; set; }
        public bool? IsActive { get; set; }
        public bool IsTransferred { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
