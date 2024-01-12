using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.CreditNote
{
    [Keyless]
    public class CreditNoteAdjustedMoneyDto
    {
        public string AreaCode { get; set; }
        public string TerritoryCode { get; set; }
        public string AREANAME { get; set; }
        public string TerritoryName { get; set; }
        public string ChemistName { get; set; }
        public string ChemistCode { get; set; }
        public string AddressDetail { get; set; }
        public decimal Amount { get; set; }
    }
}
