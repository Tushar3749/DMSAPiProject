using System;
using System.Collections.Generic;

namespace DMS.Core.DTO.SummaryReturn
{
    public class AllocationInvoiceForSummaryMasterDto
    {
		public string InvoiceCode { get; set; }
		public Nullable<DateTime> InvoiceDate { get; set; }
		public string ChemistCode { get; set; }
		public string MPOCode { get; set; }
		public string TerritoryCode { get; set; }
		public string PaymentMode { get; set; }

		public Nullable<decimal> NetAmount { get; set; }
		public Nullable<decimal> PayableAmount { get; set; }
		public Nullable<decimal> ReturnAmount { get; set; }
		public Nullable<decimal> NetAmountDiscount { get; set; }
		public Nullable<decimal> NetProductDiscount { get; set; }
		public Nullable<decimal> NetTP { get; set; }
		public Nullable<decimal> CreditNoteAdjustedAmount { get; set; }

		public Nullable<decimal> NetVAT { get; set; }
		public string ChemistName { get; set; }
		public Nullable<int> NumberOfProduct { get; set; }
		public Nullable<int> InvoiceReturnTypeID { get; set; }
		public string ReturnReason { get; set; }
		public string ReturnStatus { get; set; }
		public List<SummaryInvoiceDetailDto> InvoiceDetail { get; set; }
    }
}
