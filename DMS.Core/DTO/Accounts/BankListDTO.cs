using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Accounts
{
   [Keyless]
   public class BankListDTO
    {
        public int? Acode { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public int SourceID { get; set; }
        public bool? IsActive { get; set; }
    }

    [Keyless]
    public class GenerateCodeDTO
    {
        public string Code { get; set; }
    }
}
