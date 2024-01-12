using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.SystemManager
{
    public partial class UserAccount
    {
        public int Id { get; set; }
        public string EmployeeCode { get; set; }
        public string Password { get; set; }
        public string PasswordInPlainText { get; set; }
        public bool? IsActive { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
