

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

using DMS.Core.Dto.SalesOrder;
using DMS.Core.Dto.User;
using DMS.Core.DTO.Orders;
using DMS.Core.DTO.Orders.OrderReport;
using DMS.Core.DTO.SalesOrder;
using DMS.Core.DTO.SalesOrder.AppOrder;
using DMS.Core.Models.SalesInvoice;
using DMS.Data.Repository;
using DMS.Services.Interfaces;
using DMS.Services.Map;
using DMS.Services.Map.SalesOrder;
using DMS.Services.Validation;
using DMS.Utility.Library;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Services
{
    public class SalesOrderService : LoggerService, ISalesOrderService
    {
        private SalesOrderRepository repo;
        private CodeGenerateRepository codeRepo;
        private DbContext context;

        private BugReportingService bugReportingService;

        public SalesOrderService(IConfiguration Config)
        {
            this.context = new InvoiceContext(Config);
            this.repo = new SalesOrderRepository(this.context);
            this.codeRepo = new CodeGenerateRepository(this.context);
            this.bugReportingService = new BugReportingService(Config);
        }

        public async Task<Order> getSalesOrder(string code)
        {
            
            return await repo.getSalesOrder(code);
            
        }

        //    public async Task<IEnumerable<ProductsDto>> getProducts()
        //    {
        //        return await pRepo.getProducts();
        //    }

        //    public async Task<IEnumerable<ChemistsDto>> getChemists(string EmployeeID)
        //    {
        //        return await cRepo.getChemists(EmployeeID);
        //    }


        //    // SAVE 
        public async Task<Order> saveSalesOrder(OrdersDto newData, UserBasicInfo _User)
        {
                // MAP
                Order newItem = new OrderMap().map(newData);
                if (newItem == null) throw new Exception("Failed to map.Please try again");


            if (string.IsNullOrEmpty(newItem.OrderCode)) newItem.OrderCode = await this.codeRepo.getGeneratedCode("SALESORDER");

                newItem.CreatedById = _User.EmployeeID;
                newItem.MachineId = "192";
                newItem.DepotCode = _User.DepotCode;

                //// VALIDATION
                ValidationResult result = new OrdersValidator().Validate(newItem);
                if (!result.IsValid) throw new Exception(result.ToString(" ~"));


                // SERIALIZATION
                JSONSerialize serialize = new JSONSerialize();
                List<OrdersDetailDto> Details = serialize.getJSON<OrdersDetailDto>(serialize.DecodeBase64(newData.Detail));
                if (Details == null) throw new Exception("Unable to load details.Failed to map details. Please try again." + serialize.Error);


                Order existingOrder = await repo.getSalesOrder(newItem.OrderCode);

                //// SAVE
                if (existingOrder == null)
                {
                    var salesOrder = await saveNewOrder(newItem, Details, _User);
                    return salesOrder;
                }
                else return await updateOrder(existingOrder, Details);

                //return null;

            
        }


        private async Task<Order> saveNewOrder(Order newOrder, List<OrdersDetailDto> Details, UserBasicInfo _User)
        {
            try
            {
                await repo.BEGIN_TRANSACTION();
                var salesOrder = await repo.saveSalesOrder(newOrder);

                foreach (OrdersDetailDto item in Details)
                {
                    OrdersDetail orderProduct = new SalesOrderProductMap().map(item);
                    orderProduct.CreatedById = _User.EmployeeID;
                    orderProduct.MachineId = "192.168.42.6";
                    if (orderProduct != null)
                    {
                        orderProduct.OrderCode = salesOrder.OrderCode;

                        await repo.saveSalesOrderProducts(orderProduct);
                    }
                }

                await repo.COMMIT();
                return salesOrder;
            }
            catch (Exception ex)
            {
                await repo.ROLL_BACK();
                logException(ex);
                return null;
            }
        }

        public async Task<Order> cancelOrder(CancelledOrderDto newData, UserBasicInfo _User)
        {
           

            Order existingOrder = await repo.getSalesOrder(newData.OrderCode);

            //// SAVE
            if (existingOrder == null) throw new Exception("No order found with order code : " + newData.OrderCode);

            existingOrder.IsCancelled = true;
            existingOrder.ReasonToCancel = newData.ReasonToCancel;
            existingOrder.CancelledOn = DateTime.Now;
            existingOrder.CancelledById = newData.CancelledByID;


            return await repo.updateSalesOrder(existingOrder.Id, existingOrder);

            //return null;


        }



        public async Task<Boolean> saveSalesOrderPrintDone(List<SalesOrderReportDto> PrintOrders)
        {
            try
            {
                await repo.BEGIN_TRANSACTION();
                

                foreach (SalesOrderReportDto item in PrintOrders)
                {
                    Order order = await repo.getSalesOrder(item.OrderCode);
                    if (order != null)
                    {
                        order.IsActive = false;

                        await repo.updateSalesOrder(order.Id, order);
                    }
                }

                await repo.COMMIT();
                return true;
            }
            catch (Exception ex)
            {
                await repo.ROLL_BACK();
                logException(ex);
                return false;
            }
        }

        private async Task<Order> updateOrder(Order ExistingOrder, List<OrdersDetailDto> Details)
        {
            return await repo.updateSalesOrder(ExistingOrder.Id, ExistingOrder);
        }

        public Task<Order> getSalesOrder(int Id)
        {
            throw new NotImplementedException();
        }


        //    // SAVE 
        public async Task<List<AppOrderReceiveAckDto>> saveSalesOrderFromApp(AppOrderReceiveDto AppOrders, UserBasicInfo _User)
        {
            string error = "";
            try
            {
                await repo.BEGIN_TRANSACTION();

                List<AppOrderReceiveAckDto> receiveAckDtos = new List<AppOrderReceiveAckDto>();

                foreach (AppSalesOrderDto appOrder in AppOrders.Orders)
                {

                    AppOrderReceiveAckDto ack = new AppOrderReceiveAckDto();
                    ack.OrderCode = appOrder.OrderCode;
                    ack.ReceivedByID = _User.EmployeeID;

                    receiveAckDtos.Add(ack);

                    var existingOrder = await repo.getSalesOrder(appOrder.OrderCode);

                    // Preventing duplicate entry
                    if(existingOrder!=null)
                    {
                        continue;
                    }


                    Order order = new AppOrderMap().map(appOrder);

                    order.OrderMedia = "App";
                    order.OrderDate = appOrder.CreatedOn.GetValueOrDefault();
                    order.CreatedById = _User.EmployeeID;
                    order.Mpocode = appOrder.OrderByID;

                    if (string.IsNullOrEmpty(order.DeliveryTime)) order.DeliveryTime = "Morning";


                    await repo.saveSalesOrder(order);

                    List<AppSalesOrderDetailDto> OrderDetails = AppOrders.OrderDetails.Where(o=> o.OrderCode == order.OrderCode).ToList();

                    foreach (AppSalesOrderDetailDto AppOrderDetail in OrderDetails)
                    {
                        OrdersDetail orderDetail = new AppOrderDetailMap().map(AppOrderDetail);
                        orderDetail.OrderCode = order.OrderCode;
                        orderDetail.MachineId = "99";
                        orderDetail.CreatedById = _User.EmployeeID;
                        orderDetail.Quantity = AppOrderDetail.OrderQuantity;

                        await repo.saveSalesOrderProducts(orderDetail);
                    }


                    
                }




                await repo.COMMIT();
                return receiveAckDtos;
            }
            catch(Exception ex)
            {
                error = getErrorMessages(ex);
                logException(ex);
                await this.bugReportingService.sendBugReport(ex);
                await repo.ROLL_BACK();
                
            }

            if (string.IsNullOrEmpty(error)) return null;
            else throw new Exception(error);

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
            return await repo.getOrdersForNewInvoice();
        }

        public async Task<List<OrderProductStockStatusDto>> getOrderProductStockStatus()
        {
            return await repo.getOrderProductStockStatus();
        }


        /*
         *=============================================
         * END Of Author Md. Rahat Hossian
         *=============================================
        */

        //private async Task<string> GenerateOrderCode(string DepotCode)
        //{
        //    try
        //    {
        //        string code = string.Empty;
        //        int orderCount = await repo.getCurrentMonthOrderNumber();

        //        if (orderCount == 0)
        //        {
        //            code = $"SOT{DateTime.Now:MM}{DateTime.Now:yy}-{DepotCode}{ "1".PadLeft(5, '0') }";
        //        }
        //        else
        //        {
        //            code = $"SOT{DateTime.Now:MM}{DateTime.Now:yy}-{DepotCode}{ (orderCount + 1).ToString().PadLeft(5, '0') }";
        //        }

        //        return code;
        //    }
        //    catch (Exception ex)
        //    {
        //        Error = ex;
        //        return null;
        //    }
        //}


        //    // CANCEL 
        //    public async Task<SalesOrder> cancelSalesOrder(SalesOrderNewDto newData)
        //    {
        //        try
        //        {
        //            SalesOrder existingOrder = await repo.getSalesOrder(newData.ID.GetValueOrDefault());

        //            //// SAVE
        //            if (existingOrder != null)
        //            {
        //                existingOrder.IsActive = false;
        //                existingOrder.UpdatedById = newData.CreatedByID;
        //                return await repo.updateSalesOrder(existingOrder.Id, existingOrder);
        //            }
        //            else throw new Exception("Invalid order ID.");
        //        }
        //        catch (Exception ex) { logException(ex); return null; }
        //    }




        //    public async Task<IEnumerable<SalesOrderDto>> getSalesOrderReport(string EmployeeID)
        //    {
        //        return await repo.getSalesOrderReport(EmployeeID);
        //    }

        //    public async Task<IEnumerable<SalesOrderProductDto>> getSalesOrderProduct(int OrderID)
        //    {
        //        return await repo.getSalesOrderProduct(OrderID);
        //    }

        //    public async Task<List<OrderTodayStatusDto>> getOrderTodayStatus(string EmployeeID)
        //    {
        //        var data = await repo.getOrderTodayStatus(EmployeeID);
        //        return data;
        //    }



        public async Task<List<ReceivedOrderDto>> getReceivedOrder(string DateFrom, string DateTo)
        {
           
                return await repo.getReceivedOrder(DateFrom, DateTo);
           
        }


        public async Task<List<TerritoryChemistDto>> getTerritoryChemist(string TerritoryID)
        {
            return await repo.getTerritoryChemist(TerritoryID);
        }

        public async Task<List<MPOByTerritoryDto>> getMPOByTerritory(string TerritoryID)
        {
            return await repo.getMPOByTerritory(TerritoryID);
        }

        public async Task<List<SalesOrderReportDto>> getSalesOrderReport(string DateFrom, string DateTo, string SearchText)
        {
            return await repo.getSalesOrderReport(DateFrom, DateTo, SearchText);
        }

        public async Task<List<SalesOrderReportDetailDto>> getSalesOrderReportDetail(string OrderCode)
        {
            return await repo.getSalesOrderReportDetail(OrderCode);
        } 
        
        public async Task<List<SalesOrderReportDto>> getSalesOrderReportForPrint(string DateFrom, string DateTo, string SearchText="0")
        {
            try
            {
                List<SalesOrderReportDto> report = new List<SalesOrderReportDto>();

                var Orders = await repo.getSalesOrderReport(DateFrom, DateTo, SearchText);
                foreach (var item in Orders)
                {

                    item.Detail = new List<SalesOrderReportDetailDto>();

                    var detail = await repo.getSalesOrderReportDetail(item.OrderCode);

                    if (detail != null) item.Detail.AddRange(detail);

                    report.Add(item);
                }

                return report;
            }
            catch (Exception ex)
            {
                logException(ex);
                return null;
            }
        }

    }
}
