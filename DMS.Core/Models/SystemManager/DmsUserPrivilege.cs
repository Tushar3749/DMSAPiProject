using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.SystemManager
{
    public partial class DmsUserPrivilege
    {
        public int Id { get; set; }
        public string EmployeeCode { get; set; }
        public int MenuId { get; set; }
        public bool? HasView { get; set; }
        public bool? HasInsert { get; set; }
        public bool? HasUpdate { get; set; }
        public bool? HasDelete { get; set; }
        public bool? HasPrint { get; set; }
        public bool? HasFullAccess { get; set; }
        public bool? HasApprove { get; set; }
        public bool? IsTransferred { get; set; }
        public string CreatedById { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
