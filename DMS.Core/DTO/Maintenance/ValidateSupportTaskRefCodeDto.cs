using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Maintenance
{
    [Keyless]
    public class ValidateSupportTaskRefCodeDto
    {
        public string IsValid { get; set; }

        public string ValidationMessage { get; set; }
    }
}
