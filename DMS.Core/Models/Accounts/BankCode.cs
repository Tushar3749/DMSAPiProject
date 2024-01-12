using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.Accounts
{
    public partial class BankCode
    {
        public int SourceId { get; set; }
        public int? Acode { get; set; }
        public string BankId { get; set; }
        public string BankName { get; set; }
        public string Branch { get; set; }
        public bool? IsLabaidAccount { get; set; }
        public bool? IsActive { get; set; }
    }
}
