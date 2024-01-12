using DMS.Core.DTO;
using DMS.Core.DTO.Chemist;
using DMS.Core.DTO.Discount;
using DMS.Core.DTO.SalesInvoice;
using DMS.Core.Models.SystemManager;
using Microsoft.EntityFrameworkCore;

namespace DMS.Core.Models_StoredProcedure
{
    public abstract class SalesMasterContext_ModelClasses: DbContext
    {
        public SalesMasterContext_ModelClasses() : base()
        {

        }

        protected virtual DbSet<ChemistDto> ChemistDto { get; set; }
        protected virtual DbSet<ChemistCreditDto> ChemistCreditDto { get; set; }
        protected virtual DbSet<ChemistTerritoryDto> ChemistTerritoryDto { get; set; }
        protected virtual DbSet<Location> Location { get; set; }
        protected virtual DbSet<TerritoryChemistSalesReportDto> TerritoryChemistSalesReportDto { get; set; }
        protected virtual DbSet<ChemistInfoDto> ChemistInfoDto { get; set; }
        protected virtual DbSet<InvoicePaymentStatusDto> InvoicePaymentStatusDto { get; set; }
        protected virtual DbSet<MPODueDTO> MPODueDTO { get; set; }
        protected virtual DbSet<ChemistDueInvoiceForSummaryDto> ChemistDueInvoiceForSummaryDto { get; set; }
        protected virtual DbSet<ChemistDetailDto> ChemistDetailDto { get; set; }
        protected virtual DbSet<ChemistBySearchDto> ChemistBySearchDto { get; set; }
        protected virtual DbSet<ChemistDiscountDto> ChemistDiscountDto { get; set; }
        protected virtual DbSet<ChemistBusinessProfileDto> ChemistBusinessProfileDto { get; set; }
        protected virtual DbSet<InvoiceCollectionStatusDTO> InvoiceCollectionStatusDTO { get; set; }
       

    }
}
