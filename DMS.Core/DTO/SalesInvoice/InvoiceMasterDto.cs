using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.SalesInvoice
{
    public class InvoiceMasterDto
    {
        public int Id { get; set; }
        public string InvoiceCode { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string OrderCode { get; set; }
        public string ChemistCode { get; set; }
        public string Mpocode { get; set; }
        public string TerritoryCode { get; set; }
        public string DepotCode { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryTime { get; set; }

        public string PaymentMode { get; set; }
        public string DiscountCode { get; set; }
        public int? DiscountDetailId { get; set; }
        public decimal NetTp { get; set; }
        public decimal NetVat { get; set; }
        public decimal NetProductDiscount { get; set; }
        public decimal AmountDiscount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal CreditNoteAdjustedAmount { get; set; }

        public string MachineId { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
