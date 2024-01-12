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
   public class InvoiceAllocationDetailRepository
    {
        private GenericRepository<InvoiceAllocationDetail> repo = null;
        private DbContext context = null;
        public InvoiceAllocationDetailRepository(DbContext context)
        {
            this.context = context;
            this.repo = new GenericRepository<InvoiceAllocationDetail>(context);
        }

        public async Task<InvoiceAllocationDetail> save(InvoiceAllocationDetail detail)
        {
            return await repo.Insert(detail);
        }

        public async Task<List<InvoiceAllocationDetail>> saveBulk(List<InvoiceAllocationDetail> detail)
        {
            try
            {
                return await repo.InsertBulk(detail);

            }
            catch(Exception e)
            {
                return null;
            }
        }


        public async Task<InvoiceAllocationDetail> update(InvoiceAllocationDetail detail)
        {
            return await repo.Update(detail, i => i.InvoiceCode == detail.InvoiceCode && i.AllocationCode == detail.AllocationCode);
        }

        public void delete(InvoiceAllocationDetail detail)
        {
            repo.Delete(i => i.InvoiceCode == detail.InvoiceCode && i.AllocationCode == detail.AllocationCode);
            return;
        }

    }


}
