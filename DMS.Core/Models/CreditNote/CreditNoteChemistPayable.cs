using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.CreditNote
{
    public partial class CreditNoteChemistPayable
    {
        public int Id { get; set; }
        public string DepotCode { get; set; }
        public string CreditNoteCode { get; set; }
        public string ProductType { get; set; }
        public string ChemistCode { get; set; }
        public decimal Amount { get; set; }
        public string InvoiceCode { get; set; }
        public bool? IsActive { get; set; }
        public bool IsAdjusted { get; set; }
        public string AdjustedById { get; set; }
        public DateTime? AdjustedOn { get; set; }
        public bool IsTransferred { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedById { get; set; }
    }
}
