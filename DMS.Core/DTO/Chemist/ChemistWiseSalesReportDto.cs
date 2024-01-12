

// Name: Somaiya Jannat, somaiyajannat044@gmail.com
// Date: 17 june 2023
// Description: location wise chemist sales, collection, due

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Chemist
{
    [Keyless]
    public class ChemistWiseSalesReportDto
    {
        public string TerritoryCode { get; set; }
        public string TerritoryName { get; set; }
        public string ChemistCode { get; set; }
        public string ChemistName { get; set; }
        public decimal TotalTP { get; set; }
        public decimal TotalAmountDiscount { get; set; }
        public decimal InvoiceAmount { get; set; }
        public decimal CollectionAmount { get; set; }
        public decimal DueAmount { get; set; }
        public string AddressDetail { get; set; }
    }
}
