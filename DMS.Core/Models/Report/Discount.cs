using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.Report
{
    public partial class Discount
    {
        public Discount()
        {
            DiscountDetails = new HashSet<DiscountDetail>();
        }

        public int Id { get; set; }
        public string DiscountCode { get; set; }
        public string Description { get; set; }
        public string DepotCode { get; set; }
        public string ChemistCode { get; set; }
        public string DiscountCategoryCode { get; set; }
        public bool? IsPolicyForAllChemist { get; set; }
        public bool? IsPolicyForAllProduct { get; set; }
        public bool? HasThisDiscountMostPriority { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Remarks { get; set; }
        public bool? IsTransferred { get; set; }
        public DateTime? TransferredOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsVerified { get; set; }
        public DateTime? VerifiedOn { get; set; }
        public string VerifiedById { get; set; }
        public string CreatedById { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual ICollection<DiscountDetail> DiscountDetails { get; set; }
    }
}
