using DMS.Core.Models.SalesInvoice;
using DMS.Data.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Data.Repository
{
    public class InvoiceProductBatchWiseRepository
    {
        private GenericRepository<InvoiceProductBatchWise> repo = null;
        private DbContext context = null;

        public InvoiceProductBatchWiseRepository(DbContext context)
        {
            this.context = context;
            this.repo = new GenericRepository<InvoiceProductBatchWise>(this.context);
        }

        public async Task<InvoiceProductBatchWise> save(InvoiceProductBatchWise detail)
        {
            return await repo.Insert(detail);
        }

        public async Task<List<InvoiceProductBatchWise>> saveBulk(List<InvoiceProductBatchWise> details)
        {
            return await repo.InsertBulk(details);
        }

        public async Task<List<InvoiceProductBatchWise>> getByInvioceCode(string invoiceCode)
        {
            return await repo.Find(i => i.InvoiceCode == invoiceCode);
        }
    }
}
