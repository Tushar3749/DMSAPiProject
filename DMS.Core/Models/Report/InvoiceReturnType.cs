using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.Report
{
    public partial class InvoiceReturnType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string TypeName { get; set; }
    }
}
