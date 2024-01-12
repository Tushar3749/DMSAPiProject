using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.SalesInvoice
{
    public partial class InvoiceAllocationDetail
    {
        public int Id { get; set; }
        public string AllocationCode { get; set; }
        public string InvoiceCode { get; set; }
        public string MachineId { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedById { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsTransferred { get; set; }
    }
}
