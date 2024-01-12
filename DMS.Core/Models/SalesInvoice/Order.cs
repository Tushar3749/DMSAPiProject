using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.SalesInvoice
{
    public partial class Order
    {
        public int Id { get; set; }
        public string OrderCode { get; set; }
        public DateTime OrderDate { get; set; }
        public string ChemistCode { get; set; }
        public string TerritoryCode { get; set; }
        public string DepotCode { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryTime { get; set; }
        public string PaymentMode { get; set; }
        public string OrderMedia { get; set; }
        public string Remarks { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsCancelled { get; set; }
        public string ReasonToCancel { get; set; }
        public DateTime? CancelledOn { get; set; }
        public string CancelledById { get; set; }
        public string MachineId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedById { get; set; }
        public string Mpocode { get; set; }
        public string LabaidEmployeeCode { get; set; }
        public bool IsTransferred { get; set; }
    }
}
