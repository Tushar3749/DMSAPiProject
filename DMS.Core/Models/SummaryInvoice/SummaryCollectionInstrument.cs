using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.SummaryInvoice
{
    public partial class SummaryCollectionInstrument
    {
        public int Id { get; set; }
        public string CollectionCode { get; set; }
        public string ChemistCode { get; set; }
        public string InstrumentNumber { get; set; }
        public decimal Amount { get; set; }
        public string InstrumentType { get; set; }
        public string InstrumentBank { get; set; }
        public DateTime InstrumentDate { get; set; }
        public string MachineId { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsTransferred { get; set; }
    }
}
