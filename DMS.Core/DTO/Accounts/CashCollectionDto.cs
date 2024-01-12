using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Accounts
{
    public class CashCollectionDto
    {
        public string CollectedByCode { get; set; }
        public InstrumentInfoDto InstrumentInfo { get; set; }
        public List<CashCollectionDetailDto> CollectionDetail { get; set; }
    }
}
