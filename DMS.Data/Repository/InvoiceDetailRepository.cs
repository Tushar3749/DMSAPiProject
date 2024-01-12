/*
 *=============================================
 *Author: Md. Rahat Hossain 
 *Email: rahat@labaidpharma.com
 *Created on: 7 June, 2021
 *Updated on:
 *Last updated on:
 *Description:
 *=============================================
*/

using DMS.Core.DTO.DepotInventory;
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
    public class InvoiceDetailRepository
    {
        private GenericRepository<InvoiceDetail> repo = null;
        private DbContext context = null;

        public InvoiceDetailRepository(DbContext context)
        {
            this.context = context;
            this.repo = new GenericRepository<InvoiceDetail>(this.context);
        }

        public async Task<InvoiceDetail> save(InvoiceDetail detail)
        {
            return await repo.Insert(detail);
        }

        public async Task<List<InvoiceDetail>> saveBulk(List<InvoiceDetail> detail)
        {
            return await repo.InsertBulk(detail);
        }


        public async Task<InvoiceDetail> update(InvoiceDetail detail)
        {
            return await repo.Update(detail, i => i.InvoiceCode == detail.InvoiceCode && i.ProductCode == detail.ProductCode);
        }

        public void delete(InvoiceDetail detail)
        {
            repo.Delete(i => i.InvoiceCode == detail.InvoiceCode && i.ProductCode == detail.ProductCode);
            return;
        }

        public async Task<List<InvoiceDetail>> GetInvoiceByDateBetween(string invoiceCode)
        {
            return await repo.Find(i => i.InvoiceCode == invoiceCode);
        }
    }
}
