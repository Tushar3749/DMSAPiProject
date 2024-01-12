using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.SalesInvoice
{
    [Keyless]
    public class ValidateCurrentDateInvoiceDto
    {
        public Nullable<Boolean> ISVALID { get; set; }

        public string ValidationMessage { get; set; }
    }

}

