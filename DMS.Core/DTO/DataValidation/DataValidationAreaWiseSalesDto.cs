using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.DataValidation
{
    [Keyless]
    public class DataValidationAreaWiseSalesDto
    {
		public string AreaCode { get; set; }
		public string TerritoryCode { get; set; }
		public string InvoiceCode { get; set; }
		public string AllocationCode { get; set; }
		public string SummaryCode { get; set; }

		public string ChemistCode { get; set; }
		public string ChemistName { get; set; }
		public Nullable<decimal> TotalTp { get; set; }
		public Nullable<decimal> TotalVat { get; set; }
		public Nullable<decimal> TotalAmountDiscount { get; set; }

		public Nullable<decimal> TotalProductDiscount { get; set; }
		public Nullable<decimal> InvoiceAmount { get; set; }
		public string PaymentMode { get; set; }
		public string Status { get; set; }
	}
}
