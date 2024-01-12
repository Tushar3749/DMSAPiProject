using DMS.Core.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Accounts
{
    [Keyless]

    public class DepositReportDTO
    {
        public int ID { get; set; }
        public string DepositCode { get; set; }

		public Nullable<DateTime> DepositDate { get; set; }
		public string DepositByCode { get; set; }
		public string DepositByName { get; set; }
		public string BankCode { get; set; }
		public string BankName { get; set; }

		public string DepositBranch { get; set; }
		public string AccountCode { get; set; }
		public string CashReceivedByCode { get; set; }
		public string CashReceivedByName { get; set; }
		public Nullable<Boolean> IsRemitanceConfirmed { get; set; }

		public Nullable<int> DepositCOUNT { get; set; }
		public Nullable<decimal> TotalDepositAmount { get; set; }
		public Nullable<int> CashpaidCount { get; set; }
		public Nullable<int> ChequepaidCount { get; set; }
		public Nullable<int> DDpaidCount { get; set; }

		public Nullable<int> PayOrderpaidCount { get; set; }

    }
}
