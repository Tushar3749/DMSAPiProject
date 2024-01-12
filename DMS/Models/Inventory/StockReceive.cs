using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Models.Inventory
{
    public partial class StockReceive
    {
        public int Id { get; set; }
        public string ReceiveCode { get; set; }
        public DateTime ReceiveDate { get; set; }
        public string ReceiveType { get; set; }
        public string RequisitionCode { get; set; }
        public string ChallanCode { get; set; }
        public DateTime? ChallanDate { get; set; }
        public string FromWarehouse { get; set; }
        public string ToWarehouse { get; set; }
        public string DepotCode { get; set; }
        public string ChallanApprovedByCode { get; set; }
        public string ChallanApprovedByName { get; set; }
        public string ApprovalRemarks { get; set; }
        public string VehicleNo { get; set; }
        public string VatChallanNo { get; set; }
        public bool IsApproved { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string ApprovedByCode { get; set; }
        public bool IsReceived { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string ReceivedByCode { get; set; }
        public string Remarks { get; set; }
        public bool? IsActive { get; set; }
        public string MachineId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedById { get; set; }
        public string ModuleVersion { get; set; }
        public bool IsTransferred { get; set; }
    }
}
