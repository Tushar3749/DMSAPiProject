using Microsoft.EntityFrameworkCore;
using System;

namespace HODataService.Core.Dto
{
    [Keyless]
    public class validateDepotWiseSalesDto
    {
        public string? AreaCode { get; set; }

        public string? AreaName { get; set; }
        public string? TerritoryCode { get; set; }
        public string? TERRITORYNAME { get; set; }
        public string? MPOID { get; set; }
        public string? MPOName { get; set; }

        public Nullable<decimal> TotalSalesInTP { get; set; }
    }
}
