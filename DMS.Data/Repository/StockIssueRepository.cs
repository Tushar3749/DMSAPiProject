using DMS.Core.Models.Inventory;
using DMS.Data.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Data.Repository
{
    public class StockIssueRepository
    {
        private readonly DbContext context = null; 
        private readonly GenericRepository<StockIssue> repo = null;
        public StockIssueRepository(DbContext context)
        {
            this.context = context;
            this.repo = new GenericRepository<StockIssue>(this.context);
        }

        public async Task<StockIssue> save(StockIssue StockIssue)
        {
            return await repo.Insert(StockIssue);
        }

        public async Task<StockIssue> update(StockIssue issue)
        {
            return await repo.Update(issue, i => i.IssueCode == issue.IssueCode);
        }

        public void delete(StockIssue issue)
        {
            repo.Delete(i => i.IssueCode == issue.IssueCode);
            return;
        }

        public async Task<StockIssue> GetStockIssue(string IssueCode)
        {
            return await repo.FindOne(i => i.IssueCode == IssueCode);
        }

        public async Task<List<StockIssue>> GetStockIssueByDateBetween(DateTime fromDate, DateTime toDate)
        {
            return await repo.Find(i => i.IssueDate <= toDate && i.IssueDate >= fromDate);
        }

        public async Task<int> getNumberOfStockIssueInThisMonth()
        {
            var StockIssue = await repo.Find(i => i.IssueDate.ToString("yyyy-MM") == System.DateTime.Now.ToString("yyyy-MM"));
            return StockIssue == null ? 0 : StockIssue.Count();
        }
    }
}
