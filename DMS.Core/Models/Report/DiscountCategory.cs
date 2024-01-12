using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.Report
{
    public partial class DiscountCategory
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string DiscountCategoryCode { get; set; }
        public bool? IsActive { get; set; }
        public string Remarks { get; set; }
        public string CreatedById { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsTransferred { get; set; }
    }
}
