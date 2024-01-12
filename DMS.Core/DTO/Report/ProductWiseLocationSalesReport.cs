using System;
using System.Collections.Generic;

namespace DMS.Core.DTO.Report
{
    public class ProductWiseLocationSalesReport
    {
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public string? PackSize { get; set; }
        public Nullable<decimal> TP { get; set; }
        public Nullable<int> ProductSoldQuantity { get; set; }
        public Nullable<decimal> ProductTotalTP { get; set; }

        public List<ProductWiseLocationSalesDto> LocationSales { get; set; }
    }

   
}
