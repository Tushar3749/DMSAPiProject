using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.SystemManager
{
    public partial class Location
    {
        public string LocationId { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }
        public string LocationType { get; set; }
        public bool IsCurrent { get; set; }
        public string MachineNameIp { get; set; }
        public bool Transfered { get; set; }
        public bool Hotransfered { get; set; }
        public string AddedBy { get; set; }
        public DateTime DateAdded { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
