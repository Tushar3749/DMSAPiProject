using DMS.Core.DTO.DataValidation;
using HODataService.Core.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMS.Services.Interfaces
{
    public interface IDataValidationService
    {

        Task<List<validateDepotWiseSalesDto>> getValidateDepotWiseSales(string DateFrom, string DateTo);
        Task<List<DataValidationInvoiceWiseSalesDto>> dataValidation_InvoiceWiseSales(string DateFrom, string DateTo);
        Task<List<DataValidationTerritoryWiseSalesDto>> dataValidation_TerritoryWiseInvoice(string DateFrom, string DateTo);
        Task<List<DataValidationAreaWiseSalesDto>> dataValidation_AreaWiseInvoice(string DateFrom, string DateTo);
        Task<List<DataValidationRegionWiseSalesDto>> dataValidation_RegionWiseInvoice(string DateFrom, string DateTo);

        Task<List<DataValidationInvoiceWiseCollectionDto>> dataValidation_InvoiceWiseCollection(string DateFrom, string DateTo);
        Task<List<DataValidationTerritoryWiseCollectionDto>> dataValidation_TerritoryWiseCollection(string DateFrom, string DateTo);
        Task<List<DataValidationAreaWiseCollectionDto>> dataValidation_AreaWiseCollection(string DateFrom, string DateTo);
        Task<List<DataValidationRegionWiseCollectionDto>> dataValidation_RegionWiseCollection(string DateFrom, string DateTo);

        Task<List<DataValidationInvoiceWiseOutstandingDto>> dataValidation_InvoiceWiseOutstanding(string DateFrom, string DateTo);
        Task<List<DataValidationTerritoryWiseOutstandingDto>> dataValidation_TerritoryWiseOutstanding(string DateFrom, string DateTo);
        Task<List<DataValidationAreaWiseOutstandingDto>> dataValidation_AreaWiseOutstanding(string DateFrom, string DateTo);
        Task<List<DataValidationRegionWiseOutstandingDto>> dataValidation_RegionWiseOutstanding(string DateFrom, string DateTo);

    }
}
