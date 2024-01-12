using DMS.Core.DTO;
using DMS.Core.DTO.Chemist;
using DMS.Core.DTO.Discount;
using DMS.Core.DTO.SalesInvoice;
using DMS.Core.DTO.SalesMaster;
using DMS.Core.DTO.SalesOrder;
using DMS.Core.Models.PartyCode;
using DMS.Core.Models.SalesInvoice;
using DMS.Core.Models.SalesMaster;
using DMS.Data.Repository;
using DMS.Services.Interfaces;
using DMS.Services.Map;
using DMS.Services.Map.Chemist;
using DMS.Services.Map.SalesMaster;
using DMS.Utility.Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Services
{
    public class ChemistService : IChemistService
    {
        public ChemistRepository cpRepo;
        public ChemistRepository chRepo;
        private DbContext context;
        private DbContext SalesMasterContext;
        public ChemistService(IConfiguration Config)
        {
            context = new InvoiceContext(Config);           
            SalesMasterContext = new SalesMasterContext(Config);
            SalesMasterContext.ChangeTracker.LazyLoadingEnabled = false;
            cpRepo = new ChemistRepository(context);
            chRepo = new ChemistRepository(SalesMasterContext);

        }

        public async Task<List<Chemist>> getLabaidEmployeeChemist(string ChemistID)
        {

            return await chRepo.getLabaidEmployeeChemist(ChemistID);
        }

        public async Task<ChemistProfileReportDto> getChemistProfile(string ChemistID)
        {

            List<ChemistDetailDto> ChemistDetail = await cpRepo.getChemistProfile(ChemistID);
            List<ChemistDiscountDto> Discount = await cpRepo.getChemistDiscountProfile(ChemistID);
            List<ChemistBusinessProfileDto> Business = await cpRepo.getChemistBusinessProfile(ChemistID);
            List<ChemistCreditProfileDto> Credit = await cpRepo.getChemistCreditProfile(ChemistID);
            List<ChemistCreditDuesDto> CreditDues = await cpRepo.getChemistCreditDuesProfile(ChemistID);

            ChemistProfileReportDto chemistReport = new ChemistProfileReportDto();
            chemistReport.ChemistDetail = ChemistDetail;
            chemistReport.Discount = Discount;
            chemistReport.Business = Business;
            chemistReport.Credit = Credit;
            chemistReport.CreditDues = CreditDues;

            return chemistReport;
        }

        public async Task<List<ChemistDetailDto>> getChemistDetail(string ChemistID)
        {
            return await cpRepo.getChemistProfile(ChemistID);
        }

        //Added By Siam
        //Added on 10 JULY 2021
        public async Task<List<ChemistDueInvoiceForSummaryDto>> getChemistDueInvoiceForSummary(string ChemistCode)
        {
            return await cpRepo.getChemistDueInvoiceForSummary(ChemistCode);
        }
        public async Task<List<ChemistDueInvoiceForSummaryDto>> getSummaryDueInvoiceForSummary(string SummaryCode)
        {
            return await cpRepo.getSummaryDueInvoiceForSummary(SummaryCode);
        }
        public async Task<List<ChemistDueInvoiceForSummaryDto>> getMPODueInvoiceForSummary(string MPOCode)
        {
            return await cpRepo.getMPODueInvoiceForSummary(MPOCode);
        }
        public async Task<List<ChemistBusinessDateWiseDto>> getChemistBusinessDateWise(string FromDate, string ToDate, string ChemistCode)
        {

            return await cpRepo.getChemistBusinessDateWise(FromDate, ToDate, ChemistCode);

        }
        public async Task<List<MPODueDTO>> getAllMPODue()
        {

            return await cpRepo.getAllMPODue();

        }
        public async Task<List<ChemistCreditStatusDto>> getChemistCreditStatus(string ChemistCode)
        {

            return await cpRepo.getChemistCreditStatus(ChemistCode);

        }

        public async Task<List<ChemistType>> getChemistTypes()
        {

            return await chRepo.getChemistTypeNames();

        }
        public async Task<List<ChemistBySearchDto>> getChemistBySearch(string LocationCode, string ChemistTypeCode, string SearchText)
        {

            return await cpRepo.getChemistBySearch(LocationCode, ChemistTypeCode, SearchText);

        }

        // SAVE Chemist
        //public async Task<Object> saveChemist(ChemistDto chemistData,ChemistCreditDto chemistCreditData,ChemistTerritoryDto chemistTerritoryData)
        //{

        //    //chemist
        //    // MAP
        //    Chemist chemistnewItem = new ChemistMap().map(chemistData);
        //    if (chemistnewItem == null) throw new Exception("Failed to map.Please try again");
        //    //save
        //    var chemist = await chRepo.saveChemist(chemistnewItem);


        //    //Credit
        //   //Map
        //    ChemistCredit chemistCreditnewItem = new ChemistCreditMap().map(chemistCreditData);
        //    if (chemistCreditnewItem == null) throw new Exception("Failed to map.Please try again");
        //    //save
        //    var chemistCredit = await chRepo.saveChemistCredit(chemistCreditnewItem);

        //    //Territory
        //    //map
        //    ChemistTerritory chemistTerritorynewItem = new ChemistTerritoryMap().map(chemistTerritoryData);
        //    if (chemistTerritorynewItem == null) throw new Exception("Failed to map.Please try again");
        //    //Save
        //    var chemistTerritory = await chRepo.saveChemistTerritory(chemistTerritorynewItem);


        //    //Return Chemist,Credit,territory Data
        //    return new { Chemist = chemist, ChemistCredit = chemistCredit, ChemistTerritory = chemistTerritory };






        //    //END Of Author Shamsul Hasan Siam




        //}

        public async Task<List<MarketByTerritoryDto>> getMarketByTerritory(string TerritoryCode)
        {
            return await cpRepo.getMarketByTerritory(TerritoryCode);
        }

        public async Task<List<TerritoryChemistSalesReportDto>> getTerritoryChemistSalesReport(string TerritoryCode, string DateFrom, string DateTo)
        {
            return await chRepo.getTerritoryChemistSalesReport(TerritoryCode, DateFrom, DateTo);
        }

        //Update Market
        public async Task<Market> updateMarket(MarketDto newData)
        {
    
            // MAP
            Market newItem = new MarketMap().map(newData);
            if (newItem == null) throw new Exception("Failed to map.Please try again");
            Market existingMarket = await chRepo.getMarketbyCode(newItem.MarketCode);

            // VALIDATION
            //ValidationResult result = new MarketValidator().Validate(newItem);
            //if (!result.IsValid) throw new Exception(result.ToString(" ~"));


            // SAVE
            //if (newData.ID == 0) return await repo.save(newItem);


            //UPDATE
            if (existingMarket != null)
            {
                existingMarket.MarketName = newData.MarketName;
                existingMarket.UpdatedById = newData.CreatedByID;
                newItem = await chRepo.updateMarket(existingMarket.MarketCode, existingMarket);
            }
            return newItem;

        }

        //get chemist info
        public async Task<List<ChemistInfoDto>> getChemistInfo(string ChemistCode)
        {
                return await chRepo.getChemistInfo(ChemistCode);
        }

        // GET 
        public async Task<List<InvoicePaymentStatusDto>> getInvoicePaymentStatus(string SearchText, string locationCode, string DateFrom, string DateTo, string InvoiceList, int pagenumber, string pagesize)
        {
            
            return await chRepo.getInvoicePaymentStatus(SearchText, locationCode, DateFrom, DateTo,InvoiceList, pagenumber,pagesize);
            
        }  
        //public async Task<List<InvoicePaymentStatusDto>> getInvoicePaymentStatus(string SearchText, string locationCode, string DateFrom, string DateTo, string InvoiceList, InvoicePaymentStatusParameters filter)
        //{
            
        //    return await chRepo.getInvoicePaymentStatus(SearchText, locationCode, DateFrom, DateTo,InvoiceList, filter);
            
        //}

        // GET 
        public async Task<List<InvoiceCollectionStatusDTO>> getInvoiceCollectionStatus(string InvoiceCode)
        {

            return await chRepo.getInvoiceCollectionStatus(InvoiceCode);

        }
        public async Task<List<ChemistInvoiceAllowedDuration>> UpdatePendingPartycodeToTransfer(List<ChemistInvoiceAllowedDuration> PartyCodeOpen)
        {
            // GET PARTY CODE LIST              
           List<ChemistInvoiceAllowedDuration> PartyCode = new List<ChemistInvoiceAllowedDuration>();

            foreach (ChemistInvoiceAllowedDuration item in PartyCodeOpen)
            {
                if (string.IsNullOrEmpty(item.DepotCode)) continue;
                if (item.InvoiceAllowedTill >= DateTime.Now && item.IsTransferred == false)
                {
                    item.ID = 0;
                    item.IsActive = true;
                    item.CreatedOn = DateTime.Now;
                    PartyCode.Add(item);
                }
                else
                {
                    continue;
                }
            }
            await cpRepo.insertPendingPartycodeToTransfer(PartyCode);
            return PartyCodeOpen;
        }
    }

}
