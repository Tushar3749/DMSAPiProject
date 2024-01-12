using DMS.Core.DTO.Inventory;
using DMS.Core.Models.Inventory;
using DMS.Data.Repositories.GenericRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMS.Data.Repository
{
    public class StockReceiveRepository :Repository
    {
        private GenericRepository<StockReceive> repo = null;
        private DbContext context = null;

        public StockReceiveRepository(DbContext context) : base(context)
        {
            this.context = context;
            this.repo = new GenericRepository<StockReceive>(this.context);
        }
        
        public async Task<List<StockReceiveDTO>> getPendingApprovalChallanReceive()
        {
            return await new GenericRepository<StockReceiveDTO>(context).FindUsingSPAsync("getPendingApprovalChallanReceive", null);
        }
        
        public async Task<List<StockReceiveDTO>> getApprovedChallanReceive()
        {
            return await new GenericRepository<StockReceiveDTO>(context).FindUsingSPAsync("getApprovedChallanReceive", null);
        }

        public async Task<StockReceive> update(StockReceive detail)
        {

            return await repo.Update(detail, i => i.Id == detail.Id);
        }

        public async Task<bool> updateDepotReceiveAvailableStock()
        {
            return await new GenericRepository<StockIssue>(this.context).ExecuteCommand("EXEC Inventory_DMS.dbo.updateDepotReceiveQuantityToAvailableStock");
        }

        // Find One
        public async Task<StockReceive> findOneChallanReceive(int Id)
        {
            return await new GenericRepository<StockReceive>(this.context).FindOne(i => i.IsActive == true && i.Id == Id);
        }
        
        public async Task<List<StockReceive>> GetStockReceiveMaster(DateTime startdate,DateTime enddate)
        {
            return await repo.Find(x => x.ReceiveDate >= startdate && x.ReceiveDate <= enddate.AddHours(23).AddMinutes(59).AddSeconds(59) && x.IsReceived == true && x.IsActive == true);
        }

        public async Task<List<stockIssueTotalValDetailsDTO>> getstockReceiveTotalValDetailsByReceiveCode(string receivecode)
        {
            SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@receivecode", receivecode) };

            return await new GenericRepository<stockIssueTotalValDetailsDTO>(context).FindUsingSPAsync("exec getstockReceiveTotalValDetailsByIssueCode @receivecode", sqlParams);
        }
        
        public async Task<List<StockIssueDetailsDTO>> getstockReceiveDetailsByReceiveCode(string receivecode)
        {
            SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@receivecode", receivecode) };

            return await new GenericRepository<StockIssueDetailsDTO>(context).FindUsingSPAsync("exec getstockReceiveDetailsByReceiveCode @receivecode", sqlParams);
        }
    }
}
