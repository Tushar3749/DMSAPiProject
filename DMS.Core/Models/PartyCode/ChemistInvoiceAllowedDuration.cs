using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.Models.PartyCode
{
    public class ChemistInvoiceAllowedDuration
    {
        [Key]
        public int ID { get; set; }

        public string DepotCode { get; set; }
        public string ChemistCode { get; set; }
        public Nullable<DateTime> InvoiceAllowedTill { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<Boolean> IsTransferred { get; set; }

        public string CreatedByID { get; set; }

        public Nullable<DateTime> CreatedOn { get; set; }
        public string UpdatedByID { get; set; }
        public Nullable<DateTime> UpdatedOn { get; set; }
        public string Remarks { get; set; }
    }
}
