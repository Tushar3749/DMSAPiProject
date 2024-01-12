using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.CreditNote
{
    [Keyless]
    public class CreditNoteAdjustmentPendingDto
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

    [Keyless]
    public class ApprovedCreditNoteList
    {
        public string ChemistName { get; set; }
        public string ChemistCode { get; set; }
        public string AddressDetail { get; set; }
        public string CreditNoteCode { get; set; }
        public decimal Amount { get; set; }
    }

    [Keyless]
    public class AdjustedCreditNoteDto
    {
        public string CreditNoteCode { get; set; }
        public string InvoiceCode { get; set; }
        public decimal Amount { get; set; }
        public Nullable<DateTime> InvoiceDate { get; set; }
    }

    [Keyless]
    public class ChemistApprovedTotalAmount
    {
        public decimal? Amount { get; set; }
    }
}
