using DMS.Core.Models.Accounts;
using System;
using System.Collections.Generic;

namespace DMS.Core.DTO.Accounts
{
    public class BankDepositDto
    {
        public Deposit Deposit {  get; set; }
        public List<DepositDetail> DepositDetail {  get; set; }
    }
    public class BannkCodeDto
    {
        public string SourceID { get; set; }
        public string Acode { get; set; }
        public string BankID { get; set; }
        public string BankName { get; set; }
        public string Branch { get; set; }
        public Nullable<Boolean> IsLabaidAccount { get; set; }
        public Nullable<Boolean> IsActive { get; set; }

    }
}
