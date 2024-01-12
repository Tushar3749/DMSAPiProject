using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Inventory
{
    [Keyless]
    public class DepotLocation
    {
        public string LocationID { get; set; }

        public string LocationName { get; set; }
        public string Address { get; set; }
        public string LocationType { get; set; }
        public Nullable<Boolean> IsCurrent { get; set; }
    }
}
