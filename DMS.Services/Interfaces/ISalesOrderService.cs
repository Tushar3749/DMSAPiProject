using DMS.Core.Dto.User;
using DMS.Core.DTO.Orders;
using DMS.Core.DTO.Orders.OrderReport;
using DMS.Core.DTO.SalesOrder;
using DMS.Core.DTO.SalesOrder.AppOrder;
using DMS.Core.Models.SalesInvoice;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMS.Services.Interfaces
{
    public interface ISalesOrderService
    {
        //Task<IEnumerable<ProductsDto>> getProducts();
        //Task<IEnumerable<ChemistsDto>> getChemists(string EmployeeID);
        Task<Order> saveSalesOrder(OrdersDto newData, UserBasicInfo _User);
        //Task<IEnumerable<SalesOrderDto>> getSalesOrderReport(string EmployeeID);;
        //Task<IEnumerable<SalesOrderProductDto>> getSalesOrderProduct(int OrderID);
        //Task<SalesOrder> cancelSalesOrder(SalesOrderNewDto newData);
        //Task<List<OrderTodayStatusDto>> getOrderTodayStatus(string EmployeeID);
        Task<Order> getSalesOrder(int Id);
        Task<List<TerritoryChemistDto>> getTerritoryChemist(string TerritoryID);
        Task<List<MPOByTerritoryDto>> getMPOByTerritory(string TerritoryID);
        Task<List<AppOrderReceiveAckDto>> saveSalesOrderFromApp(AppOrderReceiveDto AppOrders, UserBasicInfo _User);

        Task<List<SalesOrderReportDto>> getSalesOrderReport(string DateFrom, string DateTo, string SearchText);
        Task<List<SalesOrderReportDetailDto>> getSalesOrderReportDetail(string OrderCode);
        Task<List<SalesOrderReportDto>> getSalesOrderReportForPrint(string DateFrom, string DateTo, string SearchText);
        Task<Boolean> saveSalesOrderPrintDone(List<SalesOrderReportDto> PrintOrders);
        Task<List<ReceivedOrderDto>> getReceivedOrder(string DateFrom, string DateTo);
        Task<Order> cancelOrder(CancelledOrderDto newData, UserBasicInfo _User);


        /*
         *=============================================
         *Author: Md. Rahat Hossain
         *Email: rahat@labaidpharma.com
         *Created on: 09 June 2021=
         *=============================================
        */
        Task<List<InvoicePendingOrdersDto>> getOrdersForNewInvoice();
        Task<List<OrderProductStockStatusDto>> getOrderProductStockStatus();

        /*
        *=============================================
        * END Of Author Md. Rahat Hossian
        *=============================================
       */

    }
}
