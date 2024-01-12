using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.SalesMaster
{
    public partial class ChemistType
    {
        public int Id { get; set; }
        public string TypeCode { get; set; }
        public string TypeName { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedById { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
