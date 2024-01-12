using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Models.Inventory
{
    public partial class IssueType
    {
        public int Id { get; set; }
        public string TypeCode { get; set; }
        public string TypeName { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedByCode { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedByCode { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string Remarks { get; set; }
    }
}
