using DMS.Core.Dto.User;
using DMS.Core.DTO;
using DMS.Core.DTO.Outstanding;
using DMS.Core.DTO.SalesInvoice;
using DMS.Core.DTO.SummaryReturn;
using DMS.Core.Models.HRMS;
using DMS.Core.Models.SummaryInvoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Interfaces
{
    public interface ISummaryService
    {
        Task<List<AllocationInvoiceForSummaryMasterDto>> getAllocationInvoiceForSummary(string AllocationCode);
        Task<AllocationInvoiceForSummaryMasterDto> updateSummaryInvoiceForNewSummary(AllocationInvoiceForSummaryMasterDto SummaryInvoice);
        Task<List<InvoiceReturnTypeDto>> getInvoiceReturnType();
        Task<string> saveSummaryReturnCollection(SummaryReturnNewDto SummaryNewDto, UserBasicInfo _User);
        Task<string> saveSummaryCollection(SummaryDueCollectionDto SummaryCollectionDto, UserBasicInfo _User);
        Task<List<SalesInvoiceDateBetweenDto>> getSalesInvoiceDateBetween(string FromDate, string ToDate, string PaymentMode,string Status);
        Task<List<SalesInvoiceDateBetweenDto>> getSalesDateBetween(string FromDate, string ToDate, string PaymentMode);
        Task<List<SalesInvoiceDateBetweenDto>> getSalesInvoiceByTerritoryORMpo(string FromDate, string ToDate, string Code, string PaymentMode);
        Task<List<SalesInvoiceDateBetweenDto>> getSalesInvoiceByCode(string Code);
        Task<List<SalesInvoiceDateBetweenDto>> getSalesByMPOTerritory(string FromDate, string ToDate, string Code, string PaymentMode);
        Task<List<SalesInvoiceDateBetweenDto>> getSalesByCode(string Code);
        Task<List<SalesInvoiceDateBetweenDto>> getSalesByArea(string FromDate, string ToDate, string AreaID, string PaymentMode);
        Task<List<AreaDto>> getArea();
        Task<List<RegionDTO>> getRegionList();
        Task<List<BatchWiseReturnDto>> getBatchWiseReturn(string FromDate, string ToDate);
        Task<List<ProductWiseReturnDto>> getProductWiseReturn(string FromDate, string ToDate);

        Task<List<ProductWiseSalesDto>> getTerritoryWiseAllProductSales(string FromDate, string ToDate, string RegionCode);
        Task<List<RegionDTO>> getAllAreaCodeByRegion(string RegionCode);
        Task<List<TerritoryDTO>> getAllTerritoryCodeByArea(string AreaCode);

        Task<List<ProductWiseSalesMasterDetailDTO>> getProductWiseSales(string FromDate, string ToDate, string AreaCode);

        Task<List<MasterSalesTerritoryDto>> getSalesByTerritory(OutstandingDto outstandingDto);
        Task<List<UnadjustedCreditNoteListDto>> getUnadjustedCreditNoteList();

    }
}
