using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Inventory
{
    public class ChallanReceivePendingDto
    {
        public List<StockReceivePendingChallanDto> Challan {  get; set; }
        public List<StockReceiveDetailPendingChallanDto> ChallanDetails { get; set; }
    }
}
