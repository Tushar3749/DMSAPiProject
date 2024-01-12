using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.Accounts
{
    public partial class Bank
    {
        public int SourceId { get; set; }
        public int? Acode { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public bool? IsLabaidAccount { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
