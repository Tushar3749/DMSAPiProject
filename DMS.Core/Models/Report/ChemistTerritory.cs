using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.Report
{
    public partial class ChemistTerritory
    {
        public int Id { get; set; }
        public string ChemistId { get; set; }
        public string TerritoryId { get; set; }
        public bool? IsActive { get; set; }
        public bool IsTransferred { get; set; }
        public string CreatedById { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
