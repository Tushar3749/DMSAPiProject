using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.SalesMaster
{
    public partial class ChemistCredit
    {
        public string ChemistId { get; set; }
        public string CreditType { get; set; }
        public int LimitAmount { get; set; }
        public int CreditDays { get; set; }
        public bool AllowDiscount { get; set; }
        public bool AllowBonus { get; set; }
        public bool IsMultipleInvoice { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool? IsActive { get; set; }
        public bool IsTransferred { get; set; }
        public string CreatedById { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
