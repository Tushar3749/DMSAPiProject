using DMS.Core.DTO;
using DMS.Core.DTO.Accounts;
using DMS.Core.DTO.Allocation;
using DMS.Core.DTO.BonusAndDiscount;
using DMS.Core.DTO.Chemist;
using DMS.Core.DTO.DataValidation;
using DMS.Core.DTO.DayOperation;
using DMS.Core.DTO.DepotInventory;
using DMS.Core.DTO.Discount;
using DMS.Core.DTO.Orders;
using DMS.Core.DTO.Orders.OrderReport;
using DMS.Core.DTO.Outstanding;
using DMS.Core.DTO.Report;
using DMS.Core.DTO.Report.Outstanding;
using DMS.Core.DTO.SalesInvoice;
using DMS.Core.DTO.SalesOrder;
using DMS.Core.DTO.SummaryReturn;
using DMS.Core.Models.SystemManager;
using HODataService.Core.Dto;
using Microsoft.EntityFrameworkCore;

namespace DMS.Core.Models_StoredProcedure
{
    public abstract class InvoiceContext_SPModels : DbContext
    {
        
        public InvoiceContext_SPModels() : base()
        {
            
        }

        
        protected virtual DbSet<ProductsDto> ProductsDto { get; set; }
        protected virtual DbSet<SalesOrderReportDto> SalesOrderReportDto { get; set; }
        protected virtual DbSet<SalesOrderReportDetailDto> SalesOrderReportDetailDto { get; set; }
        protected virtual DbSet<SalesOrderReportForPrintDto> SalesOrderReportForPrintDto { get; set; }
        protected virtual DbSet<ChemistTerritoryHistoryDto> ChemistTerritoryHistoryDto { get; set; }

        /*
         *=============================================
         *Author: Md. Rahat Hossain
         *Email: rahat@labaidpharma.com
         *Created on: 09 June 2021
         *=============================================
        */
        protected virtual DbSet<CreditAvailableforInvoice> CreditAvailableforInvoice { get; set; }
        protected virtual DbSet<SalesInvoiceDateBetweenDto> SalesInvoiceDateBetweenDto {  get; set; }
        protected virtual DbSet<InvoicePendingOrdersDto> InvoicePendingOrdersDto { get; set; }
        protected virtual DbSet<InvoicePendingOrderDetail> InvoicePendingOrderDetail { get; set; }
        protected virtual DbSet<OrderProductStockStatusDto> OrderProductStockStatusDto { get; set; }
        protected virtual DbSet<CashInvoiceOutstandingDto> CashInvoiceOutstandingDto {  get; set; }
        protected virtual DbSet<ProductWiseReturnDto> ProductWiseReturnDto {  get; set; }
        protected virtual DbSet<BatchWiseReturnDto> BatchWiseReturnDto {  get; set; }
        protected virtual DbSet<AreaDto> AreaDto {  get; set; }
        protected virtual DbSet<RegionDTO> RegionDTO {  get; set; }

        protected virtual DbSet<TerritoryDTO> TerritoryDTO { get; set; }
        protected virtual DbSet<OutstandingMasterDto> OutstandingMasterDto { get; set; }
        protected virtual DbSet<ProductWiseSalesMasterDetailDTO> ProductWiseSalesMasterDetailDTO { get; set; }
        protected virtual DbSet<ProductWiseSalesDto> ProductWiseSalesDto { get; set; }
        protected virtual DbSet<LocationWiseOutstandingDTO> LocationWiseOutstandingDTO { get; set; }
        protected virtual DbSet<LocationWiseInvoiceDateBetweenDto> LocationWiseInvoiceDateBetweenDto { get; set; }

        protected virtual DbSet<Location> Location { get; set; }
        protected virtual DbSet<DAWiseReturnQuantityDto> DAWiseReturnQuantityDto { get; set; }





        /*
        *=============================================
        * END Of Author Md. Rahat Hossian
        *=============================================
        */

        /*
        *=============================================
        *Author: Shamsul Hasan Siam
        *Email: siam.it@labaidpharma.com
        *Created on: 10 JUNE 2021
        *Updated on: 
        *Last updated on:
        *Description: <>
        *=============================================
         */
        // Sales Order


        protected virtual DbSet<TerritoryChemistDto> TerritoryChemistDto { get; set; }
        protected virtual DbSet<MPOByTerritoryDto> MPOByTerritoryDto { get; set; }

        protected virtual DbSet<ChemistDetailDto> ChemistProfileDto { get; set; }
        protected virtual DbSet<ChemistDiscountDto> ChemistDiscountDto { get; set; }
        protected virtual DbSet<ChemistBusinessDateWiseDto> CheChemistBusinessDateWiseDtomistDiscountDto { get; set; }
        protected virtual DbSet<validateDepotWiseSalesDto> validateDepotWiseSalesDto { get; set; }
        
        protected virtual DbSet<DiscountBySearchDto> DiscountBySearchDto { get; set; }
        protected virtual DbSet<InvoiceReturnTypeDto> InvoiceReturnTypeDto { get; set; }
        protected virtual DbSet<ChemistDueInvoiceForSummaryDto> ChemistDueInvoiceForSummaryDto { get; set; }
        protected virtual DbSet<CashInvoiceDueForSummaryDto> CashInvoiceDueForSummaryDto { get; set; }
        protected virtual DbSet<ReceivedOrderDto> ReceivedOrderDto { get; set; }
        protected virtual DbSet<MoneyReceiptDateWiseDto> MoneyReceiptDateWiseDto { get; set; }
        protected virtual DbSet<ChemistCreditStatusDto> ChemistCreditStatusDto { get; set; }
        protected virtual DbSet<ChemistBusinessProfileDto> ChemistBusinessProfileDto { get; set; }
        protected virtual DbSet<ChemistCreditDuesDto> ChemistCreditDuesDto { get; set; }
        protected virtual DbSet<ChemistCreditProfileDto> ChemistCreditProfileDto { get; set; }
        protected virtual DbSet<ChemistBySearchDto> ChemistBySearchDto { get; set; }
        protected virtual DbSet<MarketByTerritoryDto> MarketByTerritoryDto { get; set; }


        /*
        *=============================================
        * END Of Author Shamsul Hasan Siam
        *=============================================
        */


        /*
       *=============================================
       *Author: Shafiqul Bari Sadman
       *Email: sadman.it@labaidpharma.com
       *Created on: 7 JUNE 2021
       *Updated on: 
       *Last updated on:
       *Description: <>
       *=============================================
        */

        protected virtual DbSet<PendingInvoiceAllocationDTO> PendingInvoiceAllocationDTO { get; set; }
        protected virtual DbSet<DAListDTO> DAListDTO { get; set; }

        protected virtual DbSet<InvoiceAllocationDispatchDTO> InvoiceAllocationDispatchDTO { get; set; }

        protected virtual DbSet<PendingAllocationDispatchDTO> PendingAllocationDispatchDTO { get; set; }

        protected virtual DbSet<InvoiceAllocationDispatchMasterDTO> InvoiceAllocationDispatchMasterDTO { get; set; }
        protected virtual DbSet<ProductReturnReportDTO> ProductReturnReportDTO { get; set; }
        protected virtual DbSet<InvoiceNewDTO> InvoiceNewDTO { get; set; }
        protected virtual DbSet<InvoiceAllocationDetailsDTO> InvoiceAllocationDetailsDTO { get; set; }
        protected virtual DbSet<InvoiceAllocationDetailNewDTO> InvoiceAllocationDetailNewDTO { get; set; }
        protected virtual DbSet<AllocationInvoiceStatementDTO> AllocationInvoiceStatementDTO { get; set; }
        protected virtual DbSet<SummaryStatementDTO> SummaryStatementDTO { get; set; }
        protected virtual DbSet<MasterSalesTerritoryDto> MasterSalesTerritoryDto { get; set; }
        protected virtual DbSet<SalesInvoiceNewDateBetwwen> SalesInvoiceNewDateBetwwen { get; set; }

        protected virtual DbSet<CancelSummaryDTO> CancelSummaryDTO { get; set; }
        protected virtual DbSet<MPODueDTO> MPODueDTOS { get; set; }
        protected virtual DbSet<SummaryCollectionCancelDTO> SummaryCollectionCancelDTO { get; set; }
        protected virtual DbSet<SummaryInvoiceCancelDTO> SummaryInvoiceCancelDTO { get; set; }
        protected virtual DbSet<InvoicePaymentStatusDto> InvoicePaymentStatusDto { get; set; }
        protected virtual DbSet<InvoiceCollectionStatusDTO> InvoiceCollectionStatusDto { get; set; }

        














        protected virtual DbSet<GeneratedCode> GeneratedCode { get; set; }

        /*
        *=============================================
        * END Of Author Shafiqul Bari Sadman
        *=============================================
        */ 
        
        
        /*
       *=============================================
       *Author: MEHEDI
       *Email: mehedi@labaidpharma.com
       *Created on: 19 JUNE 2021
       *Updated on: 
       *Last updated on:
       *Description: <>
       *=============================================
        */

        protected virtual DbSet<ChemistDiscountAndBonusDto> ChemistDiscountAndBonusDto { get; set; }
        protected virtual DbSet<DiscountDetailForInvoiceGeneralDto> DiscountDetailForInvoiceGeneralDto { get; set; }
        protected virtual DbSet<DiscountReportDto> DiscountReportDto { get; set; }
        protected virtual DbSet<DiscountDetailDto> DiscountDetailDto { get; set; }

        protected virtual DbSet<AllocationInvoiceForSummaryDto> AllocationInvoiceForSummaryDto { get; set; }
        protected virtual DbSet<SummaryInvoiceDetailNewDto> SummaryInvoiceDetailNewDto { get; set; }

        protected virtual DbSet<DepotDayOperationStatusDto> DayOperationStatus { get; set; }

        protected virtual DbSet<LocationWiseOutstandingDetailDto> LocationWiseOutstandingDetailDto { get; set; }

        /*
        *=============================================
        * END Of Author
        *=============================================
        */

        protected virtual DbSet<DataValidationInvoiceWiseSalesDto> DataValidationInvoiceWiseSalesDto { get; set; }
        protected virtual DbSet<DataValidationTerritoryWiseSalesDto> DataValidationTerritoryWiseSalesDto { get; set; }
        protected virtual DbSet<DataValidationRegionWiseSalesDto> DataValidationRegionWiseSalesDto { get; set; }
        protected virtual DbSet<DataValidationAreaWiseSalesDto> DataValidationAreaWiseSalesDto { get; set; }

        protected virtual DbSet<DataValidationInvoiceWiseCollectionDto> DataValidationInvoiceWiseCollectionDto { get; set; }
        protected virtual DbSet<DataValidationTerritoryWiseCollectionDto> DataValidationTerritoryWiseCollectionDto { get; set; }
        protected virtual DbSet<DataValidationAreaWiseCollectionDto> DataValidationAreaWiseCollectionDto { get; set; }
        protected virtual DbSet<DataValidationRegionWiseCollectionDto> DataValidationRegionWiseCollectionDto { get; set; }

        protected virtual DbSet<DataValidationInvoiceWiseOutstandingDto> DataValidationInvoiceWiseOutstandingDto { get; set; }
        protected virtual DbSet<DataValidationTerritoryWiseOutstandingDto> DataValidationTerritoryWiseOutstandingDto { get; set; }
        protected virtual DbSet<DataValidationAreaWiseOutstandingDto> DataValidationAreaWiseOutstandingDto { get; set; }
        protected virtual DbSet<DataValidationRegionWiseOutstandingDto> DataValidationRegionWiseOutstandingDto { get; set; }


        /*
        *=============================================
        *Author: Md Monir Uddin
        *Email: monir@labaidpharma.com
        *Created on: 29 Aug 2022
        *=============================================
        */

         protected virtual DbSet<DepoInfoDto> DepoInfoDto { get; set; }

        /*
        *=============================================
        * END Of Author Md Monir Uddin
        *=============================================
        */
    

}
}
