using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.HRMS
{
    public partial class EmployeeUpload
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string SignatureFilename { get; set; }
        public string ProfileImagename { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
