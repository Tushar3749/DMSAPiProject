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
using DMS.Core.DTO;
using DMS.Core.DTO.BonusAndDiscount;
using DMS.Core.DTO.Discount;
using DMS.Core.DTO.SalesInvoice;
using DMS.Core.Models.SalesInvoice;
using DMS.Data.Repositories.GenericRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DMS.Data.Repository
{
    public class InvoiceRepository : Repository
    {
        private GenericRepository<Invoice> repo = null;
        private DbContext context = null;

        public InvoiceRepository(DbContext context): base(context)
        {
            this.context = context;
            this.context.Database.SetCommandTimeout(180000);
            this.repo = new GenericRepository<Invoice>(this.context);
        }

        public async Task<Invoice> save(Invoice invoice)
        {
            return await repo.Insert(invoice);
        }

        public async Task<Invoice> update(Invoice invoice)
        {
            return await repo.Update(invoice, i => i.InvoiceCode == invoice.InvoiceCode);
        }

        public void delete(Invoice invoice)
        {
            repo.Delete(i => i.InvoiceCode == invoice.InvoiceCode);
            return;
        }

        public async Task<Invoice> GetInvoice(string invoiceCode)
        {
            return await repo.FindOne(i => i.InvoiceCode == invoiceCode);
        }

        public async Task<List<OrdersDetail>> GetOrderDetailsByOrderCode(string orderCode)
        {
            return await new GenericRepository<OrdersDetail>(this.context).Find(I => I.OrderCode == orderCode);
        }

        public async Task<List<InvoiceDetail>> getInvoiceDetail(string invoiceCode)
        {
            return await new GenericRepository<InvoiceDetail>(this.context).Find(I => I.InvoiceCode == invoiceCode);
        }

        public async Task<Invoice> getInvoice(Expression<Func<Invoice, bool>> predicate)
        {
            return await repo.FindOne(predicate);
        }

        public async Task<Invoice> getInvoiceByOrderCode(string OrderCode)
        {
            return await repo.FindOne(i => i.OrderCode == OrderCode);
        }

        public async Task<List<Invoice>> GetInvoiceByDateBetween(DateTime fromDate, DateTime toDate)
        {
            return await repo.Find(i => i.InvoiceDate <= toDate && i.InvoiceDate >= fromDate);
        }

        public async Task<int> getNumberOfInvoiceInThisMonth()
        {
            var invoice = await repo.Find(i => i.InvoiceDate.ToString("yyyy-MM") == System.DateTime.Now.ToString("yyyy-MM"));
            return invoice == null ? 0 : invoice.Count();
        }

        public async Task<List<ChemistDiscountAndBonusDto>> applyChemistDiscountAndBonus(string ChemistCode, string ProductCode, string PaymentMode, int Quantity, DateTime InvoiceDate)
        {
            var data = await this.context.Set<ChemistDiscountAndBonusDto>().FromSqlRaw("applyChemistDiscountAndBonus @ChemistCode, @ProductCode, @PaymentMode, @Quantity, @InvoiceDate",
                new SqlParameter("@ChemistCode", ChemistCode), new SqlParameter("@ProductCode", ProductCode), 
                new SqlParameter("@PaymentMode", PaymentMode), new SqlParameter("@Quantity", Quantity),
                new SqlParameter("@InvoiceDate", InvoiceDate.ToString("yyyy-MM-dd"))).ToListAsync();
            return data;
        }

        public async Task<bool> updateDepotInvoiceAvailableStock()
        {
            return await new GenericRepository<Invoice>(this.context).ExecuteCommand("EXEC Inventory_DMS.dbo.updateDepotInvoiceQuantityToAvailableStock");
        }

        public async Task<Invoice> getInvoiceByChemistCodeAndInvoiceDate(string chemistCode, DateTime invoiceDate)
        {
            return await new GenericRepository<Invoice>(this.context).FindOne(i => i.ChemistCode == chemistCode && i.InvoiceDate == invoiceDate && i.IsActive==true);
        }

        public async Task<CreditAvailableforInvoice> checkIfCreditAvailableforInvoice(Invoice invoice)
        {
            var data = await this.context.Set<CreditAvailableforInvoice>().FromSqlRaw("checkCreditAvailableForNewInvoice @ChemistCode, @NetAmount", new SqlParameter("@ChemistCode", invoice.ChemistCode), new SqlParameter("@NetAmount", invoice.NetAmount)).ToListAsync();
            return data == null ? null : data.FirstOrDefault();
        }

        //Prevent duplicate invoice in same day
        public async Task<List<ValidateCurrentDateInvoiceDto>> validateCurrentDateInvoice(string ChemistCode, string InvoiceDate, string PaymentMode)
        {
            var data = await this.context.Set<ValidateCurrentDateInvoiceDto>().FromSqlRaw("validateNewInvoice @ChemistCode, @InvoiceDate, @PaymentMode",
                new SqlParameter("@ChemistCode", ChemistCode), new SqlParameter("@InvoiceDate", InvoiceDate), new SqlParameter("@PaymentMode", PaymentMode)).ToListAsync();
            return data;
        }
        public async Task<List<LocationWiseInvoiceDateBetweenDto>> getLocationWiseInvoiceDateBetween(string FromDate, string ToDate, string PaymentMode, string LocationCode)
        {
            var data = await this.context.Set<LocationWiseInvoiceDateBetweenDto>().FromSqlRaw("getLocationWiseInvoiceDateBetween @FromDate, @ToDate, @PaymentMode, @LocationCode",
                new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate), new SqlParameter("@PaymentMode", PaymentMode), new SqlParameter("@LocationCode", LocationCode)).ToListAsync();
            return data;
        }

    }
}
