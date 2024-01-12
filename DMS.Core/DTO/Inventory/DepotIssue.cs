using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Inventory
{
    public class DepotIssue
    {
        public virtual DepotIssueDto IssueDto { get; set; }
        public virtual List<DepotIssueDetailDto> IssueDetailDto { get; set; }
    }
}
