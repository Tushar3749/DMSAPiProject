using DMS.Core.DTO.DataValidation;
using HODataService.Core.Dto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMS.Data.Repository
{
    public class DataValidationRepository
    {
        private DbContext context = null;

        public DataValidationRepository(DbContext context)
        {
            this.context = context;

        }

        // GET
        public async Task<List<validateDepotWiseSalesDto>> validateDepotWiseSales(string DateFrom, string DateTo)
        {
            return await this.context.Set<validateDepotWiseSalesDto>().FromSqlRaw("validateDepotWiseSales @DateFrom, @DateTo",
                new SqlParameter("@DateFrom", DateFrom), new SqlParameter("@DateTo", DateTo)).ToListAsync();
        }

        // GET ::  INVOICE
        public async Task<List<DataValidationInvoiceWiseSalesDto>> dataValidation_InvoiceWiseSales(string FromDate, string ToDate)
        {
            var data = await this.context.Set<DataValidationInvoiceWiseSalesDto>().FromSqlRaw("dataValidation_InvoiceWiseSales @FromDate, @ToDate",
                new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate)).ToListAsync();
            return data;
        }

        public async Task<List<DataValidationTerritoryWiseSalesDto>> dataValidation_TerritoryWiseInvoice(string FromDate, string ToDate)
        {
            var data = await this.context.Set<DataValidationTerritoryWiseSalesDto>().FromSqlRaw("dataValidation_TerritoryWiseInvoice @FromDate, @ToDate",
                new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate)).ToListAsync();
            return data;
        }
        public async Task<List<DataValidationAreaWiseSalesDto>> dataValidation_AreaWiseInvoice(string FromDate, string ToDate)
        {
            var data = await this.context.Set<DataValidationAreaWiseSalesDto>().FromSqlRaw("dataValidation_AreaWiseInvoice @FromDate, @ToDate",
                new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate)).ToListAsync();
            return data;
        }
        public async Task<List<DataValidationRegionWiseSalesDto>> dataValidation_RegionWiseInvoice(string FromDate, string ToDate)
        {
            var data = await this.context.Set<DataValidationRegionWiseSalesDto>().FromSqlRaw("dataValidation_RegionWiseInvoice @FromDate, @ToDate",
                new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate)).ToListAsync();
            return data;
        }


        // GET ::  COLLECTION
        public async Task<List<DataValidationInvoiceWiseCollectionDto>> dataValidation_InvoiceWiseCollection(string FromDate, string ToDate)
        {
            var data = await this.context.Set<DataValidationInvoiceWiseCollectionDto>().FromSqlRaw("dataValidation_InvoiceWiseCollection @FromDate, @ToDate",
                new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate)).ToListAsync();
            return data;
        }

        public async Task<List<DataValidationTerritoryWiseCollectionDto>> dataValidation_TerritoryWiseCollection(string FromDate, string ToDate)
        {
            var data = await this.context.Set<DataValidationTerritoryWiseCollectionDto>().FromSqlRaw("dataValidation_TerritoryWiseCollection @FromDate, @ToDate",
                new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate)).ToListAsync();
            return data;
        }
        public async Task<List<DataValidationAreaWiseCollectionDto>> dataValidation_AreaWiseCollection(string FromDate, string ToDate)
        {
            var data = await this.context.Set<DataValidationAreaWiseCollectionDto>().FromSqlRaw("dataValidation_AreaWiseCollection @FromDate, @ToDate",
                new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate)).ToListAsync();
            return data;
        }
        public async Task<List<DataValidationRegionWiseCollectionDto>> dataValidation_RegionWiseCollection(string FromDate, string ToDate)
        {
            var data = await this.context.Set<DataValidationRegionWiseCollectionDto>().FromSqlRaw("dataValidation_RegionWiseCollection @FromDate, @ToDate",
                new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate)).ToListAsync();
            return data;
        }

        // GET ::  OUTSTANDING
        public async Task<List<DataValidationInvoiceWiseOutstandingDto>> dataValidation_InvoiceWiseOutstanding(string FromDate, string ToDate)
        {
            var data = await this.context.Set<DataValidationInvoiceWiseOutstandingDto>().FromSqlRaw("dataValidation_InvoiceWiseOutstanding @FromDate, @ToDate",
                new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate)).ToListAsync();
            return data;
        }

        public async Task<List<DataValidationTerritoryWiseOutstandingDto>> dataValidation_TerritoryWiseOutstanding(string FromDate, string ToDate)
        {
            var data = await this.context.Set<DataValidationTerritoryWiseOutstandingDto>().FromSqlRaw("dataValidation_TerritoryWiseOutstanding @FromDate, @ToDate",
                new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate)).ToListAsync();
            return data;
        }
        public async Task<List<DataValidationAreaWiseOutstandingDto>> dataValidation_AreaWiseOutstanding(string FromDate, string ToDate)
        {
            var data = await this.context.Set<DataValidationAreaWiseOutstandingDto>().FromSqlRaw("dataValidation_AreaWiseOutstanding @FromDate, @ToDate",
                new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate)).ToListAsync();
            return data;
        }
        public async Task<List<DataValidationRegionWiseOutstandingDto>> dataValidation_RegionWiseOutstanding(string FromDate, string ToDate)
        {
            var data = await this.context.Set<DataValidationRegionWiseOutstandingDto>().FromSqlRaw("dataValidation_RegionWiseOutstanding @FromDate, @ToDate",
                new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate)).ToListAsync();
            return data;
        }


    }
}
