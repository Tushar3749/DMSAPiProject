using DMS.Core.Models.SalesInvoice;
using HODataService.Core.Dto;
using DMS.Data.Repository;
using DMS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using DMS.Core.DTO.DataValidation;

namespace DMS.Services
{
    public class DataValidationService: IDataValidationService
	{
		private readonly DbContext context;


		private readonly DataValidationRepository repo = null;

        public DataValidationService(IConfiguration Config)
        {
            this.context = new InvoiceContext(Config);
            this.repo = new DataValidationRepository(this.context);

        }
        public async Task<List<validateDepotWiseSalesDto>> getValidateDepotWiseSales(string DateFrom, string DateTo)
		{
			 return await repo.validateDepotWiseSales(DateFrom, DateTo);
		}

        public async Task<List<DataValidationInvoiceWiseSalesDto>> dataValidation_InvoiceWiseSales(string DateFrom, string DateTo)
        {
            return await repo.dataValidation_InvoiceWiseSales(DateFrom, DateTo);
        }
        
        public async Task<List<DataValidationTerritoryWiseSalesDto>> dataValidation_TerritoryWiseInvoice(string DateFrom, string DateTo)
        {
            return await repo.dataValidation_TerritoryWiseInvoice(DateFrom, DateTo);
        }        
        public async Task<List<DataValidationAreaWiseSalesDto>> dataValidation_AreaWiseInvoice(string DateFrom, string DateTo)
        {
            return await repo.dataValidation_AreaWiseInvoice(DateFrom, DateTo);
        }        
        public async Task<List<DataValidationRegionWiseSalesDto>> dataValidation_RegionWiseInvoice(string DateFrom, string DateTo)
        {
            return await repo.dataValidation_RegionWiseInvoice(DateFrom, DateTo);
        }



        public async Task<List<DataValidationInvoiceWiseCollectionDto>> dataValidation_InvoiceWiseCollection(string DateFrom, string DateTo)
        {
            return await repo.dataValidation_InvoiceWiseCollection(DateFrom, DateTo);
        }
        public async Task<List<DataValidationTerritoryWiseCollectionDto>> dataValidation_TerritoryWiseCollection(string DateFrom, string DateTo)
        {
            return await repo.dataValidation_TerritoryWiseCollection(DateFrom, DateTo);
        }
        public async Task<List<DataValidationAreaWiseCollectionDto>> dataValidation_AreaWiseCollection(string DateFrom, string DateTo)
        {
            return await repo.dataValidation_AreaWiseCollection(DateFrom, DateTo);
        }
        public async Task<List<DataValidationRegionWiseCollectionDto>> dataValidation_RegionWiseCollection(string DateFrom, string DateTo)
        {
            return await repo.dataValidation_RegionWiseCollection(DateFrom, DateTo);
        }



        public async Task<List<DataValidationInvoiceWiseOutstandingDto>> dataValidation_InvoiceWiseOutstanding(string DateFrom, string DateTo)
        {
            return await repo.dataValidation_InvoiceWiseOutstanding(DateFrom, DateTo);
        }
        public async Task<List<DataValidationTerritoryWiseOutstandingDto>> dataValidation_TerritoryWiseOutstanding(string DateFrom, string DateTo)
        {
            return await repo.dataValidation_TerritoryWiseOutstanding(DateFrom, DateTo);
        }
        public async Task<List<DataValidationAreaWiseOutstandingDto>> dataValidation_AreaWiseOutstanding(string DateFrom, string DateTo)
        {
            return await repo.dataValidation_AreaWiseOutstanding(DateFrom, DateTo);
        }
        public async Task<List<DataValidationRegionWiseOutstandingDto>> dataValidation_RegionWiseOutstanding(string DateFrom, string DateTo)
        {
            return await repo.dataValidation_RegionWiseOutstanding(DateFrom, DateTo);
        }

    }
}
