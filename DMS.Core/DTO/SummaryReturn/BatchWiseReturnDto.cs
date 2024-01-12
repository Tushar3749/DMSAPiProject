using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.SummaryReturn
{
	[Keyless]
    public class BatchWiseReturnDto 
	{
		public string ProductName { get; set; }

		public string SalesCode { get; set; }
		public Nullable<decimal> TP { get; set; }
		public Nullable<decimal> Vat { get; set; }
		public string ProductCode { get; set; }
		public string BatchNo { get; set; }

		public Nullable<int> OrderQuantity { get; set; }
		public Nullable<int> SoldQuantity { get; set; }
		public Nullable<int> ReturnQuantity { get; set; }
	}
    [Keyless]
    public class CancelSummaryDTO
    {
        public string IsCancelled { get; set; }

    }
}
