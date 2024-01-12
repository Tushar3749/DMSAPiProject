using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.SummaryReturn
{
    public class SummaryDueCollectionDto
    {
        public string DACode { get; set; }
        public List<SummaryCollectionNewDto> SummaryCollectionDto {  get; set; }
    }
}
