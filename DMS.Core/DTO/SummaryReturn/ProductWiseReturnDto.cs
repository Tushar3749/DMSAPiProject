using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.SummaryReturn
{
	[Keyless]
	public class ProductWiseReturnDto 
	{
		public string ProductName { get; set; }

		public string SalesCode { get; set; }
		public Nullable<decimal> TP { get; set; }
		public Nullable<decimal> Vat { get; set; }
		public string ProductCode { get; set; }
		public Nullable<int> OrderQuantity { get; set; }

		public Nullable<int> SoldQuantity { get; set; }
		public Nullable<int> ReturnQuantity { get; set; }
	}

    [Keyless]
    public class ProductWiseSalesDto
    {
        public string ProductName { get; set; }

        public string SalesCode { get; set; }
        public Nullable<decimal> TP { get; set; }
        public Nullable<decimal> Vat { get; set; }
        public string ProductCode { get; set; }
        public Nullable<int> SoldQuantity { get; set; }
        public Nullable<decimal> TotalSoldPrice { get; set; }
        public string TerritoryCode { get; set; }


    }

    [Keyless]
    public class ProductWiseSalesMasterDetailDTO
    {

        public string ProductName { get; set; }

        public string SalesCode { get; set; }
        public Nullable<decimal> TP { get; set; }
        public Nullable<decimal> Vat { get; set; }
        public string ProductCode { get; set; }
        public Nullable<int> OrderQuantity { get; set; }

        public Nullable<int> SoldQuantity { get; set; }
        public Nullable<int> ReturnQuantity { get; set; }

        public List<ProductWiseSalesDto> pricelist { get; set; }

    }

}
