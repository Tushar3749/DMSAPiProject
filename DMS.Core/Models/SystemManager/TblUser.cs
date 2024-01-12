using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.SystemManager
{
    public partial class TblUser
    {
        public int UserId { get; set; }
        public string UserCode { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public bool IsLoggedIn { get; set; }
        public DateTime? LogonTime { get; set; }
        public string EmployeeCode { get; set; }
        public int? UserTypeId { get; set; }
        public bool? IsInternal { get; set; }
        public string DefaultLocation { get; set; }
        public byte[] Signature { get; set; }
        public string AddedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool IsWebAppAllowed { get; set; }
        public string EmailPassword { get; set; }
    }
}
