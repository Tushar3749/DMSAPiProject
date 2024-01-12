using DMS.Core.Dto.User;
using DMS.Core.DTO;
using DMS.Core.DTO.Chemist;
using DMS.Core.DTO.Inventory;
using DMS.Core.DTO.SalesInvoice;
using DMS.Core.DTO.SalesMaster;
using DMS.Core.Models.PartyCode;
using DMS.Core.Models.SalesInvoice;
using DMS.Core.Models.SalesMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Interfaces
{
    public interface IChemistService
    {
        Task<List<Chemist>> getLabaidEmployeeChemist(string ChemistID);
        Task<ChemistProfileReportDto> getChemistProfile(string ChemistID);
        Task<List<ChemistDueInvoiceForSummaryDto>> getChemistDueInvoiceForSummary(string ChemistCode);
        Task<List<ChemistDetailDto>> getChemistDetail(string ChemistID);
        Task<List<ChemistBusinessDateWiseDto>> getChemistBusinessDateWise(string FromDate, string ToDate, string ChemistCode);
        Task<List<ChemistCreditStatusDto>> getChemistCreditStatus(string ChemistCode);
        Task<List<ChemistType>> getChemistTypes();
        Task<List<ChemistBySearchDto>> getChemistBySearch(string LocationCode, string ChemistTypeCode, string SearchText);
       // Task<Object> saveChemist(ChemistDto chemistData, ChemistCreditDto chemistCreditData, ChemistTerritoryDto chemistTerritoryData);
        Task<List<ChemistDueInvoiceForSummaryDto>> getSummaryDueInvoiceForSummary(string SummaryCode);

        Task<List<MPODueDTO>> getAllMPODue();
        Task<List<ChemistDueInvoiceForSummaryDto>> getMPODueInvoiceForSummary(string MPOCode);
        Task<List<MarketByTerritoryDto>> getMarketByTerritory(string TerritoryCode);
        Task<Market> updateMarket(MarketDto newData);
        Task<List<TerritoryChemistSalesReportDto>> getTerritoryChemistSalesReport(string TerritoryCode, string DateFrom, string DateTo);
        Task<List<ChemistInfoDto>> getChemistInfo(string ChemistCode);

        //Task<List<InvoicePaymentStatusDto>> getInvoicePaymentStatus(string SearchText, string locationCode, string DateFrom, string DateTo, string InvoiceList, InvoicePaymentStatusParameters filter);
        Task<List<InvoicePaymentStatusDto>> getInvoicePaymentStatus(string SearchText, string locationCode, string DateFrom, string DateTo, string InvoiceList,  int pagenumber, string pagesize);
        Task<List<InvoiceCollectionStatusDTO>> getInvoiceCollectionStatus(string InvoiceCode);
        Task<List<ChemistInvoiceAllowedDuration>> UpdatePendingPartycodeToTransfer(List<ChemistInvoiceAllowedDuration> PartyCodeOpen);
    }
}
