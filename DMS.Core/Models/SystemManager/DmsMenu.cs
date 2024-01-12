using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.SystemManager
{
    public partial class DmsMenu
    {
        public int MenuId { get; set; }
        public int? ModuleId { get; set; }
        public string MenuName { get; set; }
        public int? ParentMenuId { get; set; }
        public int? MenuNumber { get; set; }
        public int? OrderId { get; set; }
        public string Route { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsNonPrivilegedMenu { get; set; }
        public string CreatedById { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
