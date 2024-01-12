using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.Report
{
    [Keyless]
    public class ProductWiseLocationSalesDto
    {
        public string? ProductCode { get; set; }

        public string? LocationCode { get; set; }
        public Nullable<int> SoldQuantity { get; set; }
        public Nullable<decimal> TotalTP { get; set; }
    }
}
