using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.SalesMaster
{
    public partial class Chemist
    {
        public string ChemistId { get; set; }
        public string ChemistName { get; set; }
        public string DepotCode { get; set; }
        public string ContactPerson { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string House { get; set; }
        public string Road { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string AddressDetail { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public bool IsTransferred { get; set; }
        public string ChemistTypeCode { get; set; }
        public string CreatedById { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
