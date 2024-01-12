using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.SummaryReturn
{
    [Keyless]
    public class UnadjustedCreditNoteListDto
    {
        public string CreditNoteCode { get; set; }

        public string ChemistCode { get; set; }
        public string ChemistName { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string ProductType { get; set; }
    }
}
