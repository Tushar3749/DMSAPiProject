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
    public class StockIssueDetailRepository
    {
        private GenericRepository<StockIssueDetail> repo = null;
        private DbContext context = null;

        public StockIssueDetailRepository(DbContext context)
        {
            this.context = context;
            this.repo = new GenericRepository<StockIssueDetail>(this.context);
        }

        public async Task<StockIssueDetail> save(StockIssueDetail detail)
        {
            return await repo.Insert(detail);
        }

        public async Task<List<StockIssueDetail>> saveBulk(List<StockIssueDetail> detail)
        {
            return await repo.InsertBulk(detail);
        }

       
        public async Task<StockIssueDetail> update(StockIssueDetail detail)
        {
            return await repo.Update(detail, i => i.IssueCode == detail.IssueCode && i.ProductCode == detail.ProductCode);
        }

        public void delete(StockIssueDetail detail)
        {
            repo.Delete(i => i.IssueCode == detail.IssueCode && i.ProductCode == detail.ProductCode);
            return;
        }

        public async Task<List<StockIssueDetail>> GetInvoiceByDateBetween(string issueCode)        {
            return await repo.Find(i => i.IssueCode == issueCode);
        }
    }
}
