using DMS.Core.DTO.Inventory;
using DMS.Core.Models.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Interfaces
{
   public interface IstockService
    {
        Task<List<StockReceiveDTO>> getPendingApprovalChallanReceive();
        Task<StockReceive> UpdateApprovedChallan (StockReceive receive,string user);

        Task<StockReceive> UpdateApprovedChallanList(List<StockReceiveDTO> details, string user);
        Task<StockReceive> UpdateReceivedChallanList(List<StockReceiveDTO> details, string user);

        Task<StockReceive> UpdateReceivedChallan(StockReceive receive,string user);
        Task<List<StockReceiveDTO>> getApprovedChallanReceive();
    }
}
