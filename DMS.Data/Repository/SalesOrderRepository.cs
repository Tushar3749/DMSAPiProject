
/*
 *=============================================
 *Author: Shamsul Hasan Siam
 *Email: siam.it@labaidpharma.com
 *Created on: 7 june 2020
 *Updated on: 
 *Last updated on:
 *Description: <>
 *=============================================
*/

using DMS.Core.DTO.Orders;
using DMS.Core.DTO.Orders.OrderReport;
using DMS.Core.Models.SalesInvoice;
using DMS.Data.Repositories.GenericRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMS.Data.Repository
{
    public class SalesOrderRepository : Repository
    {

        private GenericRepository<Order> salesOrder = null;
        private DbContext context = null;

        public SalesOrderRepository(DbContext context) : base(context)
        {
            this.context = context;
            this.context.Database.SetCommandTimeout(180000);
            this.salesOrder = new GenericRepository<Order>(context);
        }

        public async Task<Order> getOrders(int ID)
        {
            return await new GenericRepository<Order>(this.context).FindOne(O => O.Id == ID && O.IsActive == true);
        }

        public async Task<Order> getSalesOrder(string OrderCode)
        {
            return await new GenericRepository<Order>(this.context).FindOne(S => S.OrderCode == OrderCode);
        }


        //public async Task<IEnumerable<OrdersDto>> getSalesOrderReport(string EmployeeID)
        //{
        //    var result = await this.context.Set<SalesOrderDto>().FromSqlRaw("exec getSalesOrder @EmployeeID",
        //        new SqlParameter("@EmployeeID", EmployeeID)).ToListAsync();
        //    return result;
        //}

        //public async Task<IEnumerable<SalesOrderProductDto>> getSalesOrderProduct(int OrderID)
        //{
        //    var result = await this.context.Set<SalesOrderProductDto>().FromSqlRaw("exec getSalesOrderProduct @OrderID",
        //        new SqlParameter("@OrderID", OrderID)).ToListAsync();
        //    return result;
        //}

        //public async Task<List<OrderTodayStatusDto>> getOrderTodayStatus(string EmployeeID)
        //{
        //    var result = await this.context.Set<OrderTodayStatusDto>().FromSqlRaw("exec getOrderTodayStatus @EmployeeID",
        //        new SqlParameter("@EmployeeID", EmployeeID)).ToListAsync();
        //    return result;
        //}

        //// Find One
        //public async Task<SalesOrder> getSalesOrder(string OrderCode)
        //{
        //    return await new GenericRepository<SalesOrder>(this.context).FindOne(S => S.OrderCode == OrderCode && S.IsActive == true);
        //}

        //// Find One

        //// SAVE
        public async Task<Order> saveSalesOrder(Order Entity)
        {
            Entity.IsActive = true;
            Entity.CreatedOn = DateTime.Now;
            Entity.MachineId = "192.168.42.6";
            return await new GenericRepository<Order>(this.context).Insert(Entity);
        }



        //// UPDATE
        public async Task<Order> updateSalesOrder(int ID, Order Entity)
        {
            Entity.UpdatedOn = DateTime.Now;
            return await new GenericRepository<Order>(this.context).Update(Entity, S => S.Id == ID);
        }


        //// SAVE
        public async Task<OrdersDetail> saveSalesOrderProducts(OrdersDetail Entity)
        {
            return await new GenericRepository<OrdersDetail>(this.context).Insert(Entity);
        }


        //// UPDATE
        public async Task<OrdersDetail> updateSalesOrderProducts(string OrderCode, OrdersDetail Entity)
        {
            return await new GenericRepository<OrdersDetail>(this.context).Update(Entity, S => S.OrderCode == OrderCode);
        }

        //public async Task<int> getCurrentMonthOrderNumber()
        //{
        //    var order =  await salesOrder.Find(i => i.OrderDate.ToString("yyyy-MM") == System.DateTime.Now.ToString("yyyy-MM"));
        //    return order.Count();
        //}
        public async Task<List<TerritoryChemistDto>> getTerritoryChemist(string TerritoryID)
        {
            var result = await this.context.Set<TerritoryChemistDto>().FromSqlRaw("exec getTerritoryChemist @TerritoryID",
                new SqlParameter("@TerritoryID", TerritoryID)).ToListAsync();
            return result;
        }

        public async Task<List<MPOByTerritoryDto>> getMPOByTerritory(string TerritoryID)
        {
            var result = await this.context.Set<MPOByTerritoryDto>().FromSqlRaw("exec getMPOByTerritory  @TerritoryID",
                new SqlParameter("@TerritoryID", TerritoryID)).ToListAsync();
            return result;
        }


        public async Task<List<SalesOrderReportDto>> getSalesOrderReport(string DateFrom, string DateTo, string SearchText)
        {
            if (string.IsNullOrEmpty(SearchText)) SearchText = "0";

            var result = await this.context.Set<SalesOrderReportDto>().FromSqlRaw("getSalesOrderReport @DateFrom, @DateTo, @SearchText",
                new SqlParameter("@DateFrom", DateFrom), new SqlParameter("@DateTo", DateTo), new SqlParameter("@SearchText", SearchText)).ToListAsync();

            return result;
        }

        public async Task<List<SalesOrderReportDetailDto>> getSalesOrderReportDetail(string OrderCode)
        {
            var result = await this.context.Set<SalesOrderReportDetailDto>().FromSqlRaw("getSalesOrderDetail @OrderCode",
                new SqlParameter("@OrderCode", OrderCode)).ToListAsync();

            return result;
        }


        public async Task<List<SalesOrderReportForPrintDto>> getSalesOrderReportForPrint(string DateFrom, string DateTo)
        {
            string SearchText = "REPORT";

            var result = await this.context.Set<SalesOrderReportForPrintDto>().FromSqlRaw("getSalesOrderReport @DateFrom, @DateTo, @SearchText",
                new SqlParameter("@DateFrom", DateFrom), new SqlParameter("@DateTo", DateTo), new SqlParameter("@SearchText", SearchText)).ToListAsync();

            return result;
        }

        /*
         *=============================================
         *Author: Md. Rahat Hossain
         *Email: rahat@labaidpharma.com
         *Created on: 09 June 2021=
         *=============================================
        */

        public async Task<List<InvoicePendingOrdersDto>> getOrdersForNewInvoice()
        {
            return await this.context.Set<InvoicePendingOrdersDto>().FromSqlRaw("exec dbo.getOrdersForNewInvoice").ToListAsync();
        }

        public async Task<List<InvoicePendingOrderDetail>> getOrderDetailForInvoice(string orderCode)
        {
            return await this.context.Set<InvoicePendingOrderDetail>().FromSqlRaw("exec dbo.getOrdersForNewInvoiceDetail @OrderCode",
                new SqlParameter("@OrderCode", orderCode)).ToListAsync();
        }

        public async Task<List<OrderProductStockStatusDto>> getOrderProductStockStatus()
        {
            return await this.context.Set<OrderProductStockStatusDto>().FromSqlRaw("exec dbo.getOrderProductStockStatus").ToListAsync();
        }

        /*
        *=============================================
        * END Of Author Md. Rahat Hossian
        *=============================================
       */

        public async Task<List<ReceivedOrderDto>> getReceivedOrder(string DateFrom, string DateTo)
        {
            return await this.context.Set<ReceivedOrderDto>().FromSqlRaw("getReceivedOrder @DateFrom, @DateTo",
                new SqlParameter("@DateFrom", DateFrom), new SqlParameter("@DateTo", DateTo)).ToListAsync();
        }

    }
}
