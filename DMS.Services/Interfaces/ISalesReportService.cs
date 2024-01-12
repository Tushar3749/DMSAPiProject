using DMS.Core.DTO.Chemist;
using DMS.Core.DTO.Report;
using DMS.Core.DTO.SalesMaster;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMS.Services.Interfaces
{
    public interface ISalesReportService
    {
        Task<List<LocationWiseProductSalesReport>> getLocationWiseSalesReport(string LocationCode, string DateFrom, string DateTo, string PaymentMode);
        Task<List<ProductSalesSummaryReportDto>> getProductSalesSummaryReport(string LocationCode, string DateFrom, string DateTo, string PaymentMode);
        Task<List<OrderStatusReportDto>> getOrderStatusReport(string DateFrom, string DateTo, string SearchText);
        Task<object> getLocationSales(string ParentLocationCode, string LocationLevel);
        Task<List<SalesAndCollectionForDashboardDto>> getSalesAndCollectionForDashboard(string FromDate, string ToDate);
        Task<object> getProductWiseLocationSalesReport(string LocationCode, string LocationLevel, string DateFrom, string DateTo, string PaymentMode);
        Task<List<RMDetails>> getDepotFieldForce(string RegionCode);
        Task<List<FieldForceDto>> getDepotFieldForceForExcel(string regionCode);
        Task<List<LocationWiseSalesReportDto>> getLocationWiseSalesReportForExcel(string locationcode, string datefrom, string dateto, string paymentmode);
        Task<List<LocationWiseProductReturnDto>> getLocationWiseProductReturn(string LocationCode, string DateFrom, string DateTo, string PaymentMode);
        Task<List<ChemistWiseSalesReportDto>> getChemistWiseSalesReport(string locationcode, string datefrom, string dateto);
    }
}
