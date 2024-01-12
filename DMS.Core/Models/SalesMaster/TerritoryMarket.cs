using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.SalesMaster
{
    public partial class TerritoryMarket
    {
        public int Id { get; set; }
        public string TerritoryCode { get; set; }
        public string MarketCode { get; set; }
        public bool IsActive { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
