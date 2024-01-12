using DMS.Core.DTO;
using DMS.Core.DTO.Outstanding;
using DMS.Core.DTO.Report;
using DMS.Core.DTO.Report.Outstanding;
using DMS.Core.Models.SalesInvoice;
using DMS.Data.Repository;
using DMS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Outstanding
{
    public class OutStandingService: IOutstandingService
    {
        //Added By Siam
        //Added on 11 JULY 2021
        private readonly OutstandingRepository repo = null;
    
        private readonly DbContext context;


        public OutStandingService(IConfiguration Config)
        {
            this.context = new InvoiceContext(Config);
            this.repo = new OutstandingRepository(this.context);
        }

        public async Task<List<TerritoryDTO>> GetAllTerritory(string areacode)
        {
            if (String.IsNullOrEmpty(areacode)) areacode = "All";
            return await repo.GetAllTerritory(areacode);
        }



        public async Task<List<LocationWiseOutstanding>> getInvoiceOutstandingLocationWise(string LocationCode, string PaymentMode, string Datefrom, string DateTo)
        {
            List<LocationWiseOutstanding> report = new List<LocationWiseOutstanding>();


            var data = await repo.getOutstandingLocationWise(LocationCode, PaymentMode, Datefrom, DateTo);

            var areas = data.GroupBy(x => x.AreaID)
                      .Select(y => new {
                          RegionID = y.First().RegionID,
                          RegionName = y.First().RegionName,
                          RegionalManagerID = y.First().RegionalManagerID,
                          RegionalManagerName = y.First().RegionalManagerName,
                          AreaID = y.First().AreaID,
                          AreaName = y.First().AreaName,
                          AreaManagerID = y.First().AreaManagerID,
                          AreaManagerName = y.First().AreaManagerName,
                          InvoiceAmount = y.Sum(x => x.InvoiceAmount),
                          PaidAmount = y.Sum(x => x.PaidAmount),
                          DueAmount = y.Sum(x => x.DueAmount),
                          DueAmountCash = y.Sum(x => x.DueAmountCash),
                          DueAmountCredit = y.Sum(x => x.DueAmountCredit),
                          OverDueAmountCash = y.Sum(x => x.OverDueAmountCash),
                          OverDueAmountCredit = y.Sum(x => x.OverDueAmountCredit),
                      });



            foreach (var area in areas)
            {
                LocationWiseOutstanding rpt = new LocationWiseOutstanding();

                rpt.RegionID = area.RegionID;
                rpt.RegionName = area.RegionName;
                rpt.RegionalManagerID = area.RegionalManagerID;
                rpt.RegionalManagerName = area.RegionalManagerName;
                rpt.AreaID = area.AreaID;
                rpt.AreaName = area.AreaName;
                rpt.AreaManagerID = area.AreaManagerID;
                rpt.AreaManagerName = area.AreaManagerName;
                rpt.InvoiceAmount = area.InvoiceAmount;
                rpt.PaidAmount = area.PaidAmount;
                rpt.DueAmount = area.DueAmount;
                rpt.DueAmountCash = area.DueAmountCash;
                rpt.DueAmountCredit = area.DueAmountCredit;
                rpt.OverDueAmountCash = area.OverDueAmountCash;
                rpt.OverDueAmountCredit = area.OverDueAmountCredit;



                // Territory Detail
                var territories = data.Where(l => l.AreaID == area.AreaID).Select(t => new LocationWiseOutstandingTerritoryDetailsDTO
                {
                    TerritoryID = t.TerritoryID,
                    TerritoryName = t.TerritoryName,
                    MPOID = t.MPOID,
                    MPOName = t.MPOName,
                    InvoiceAmount = t.InvoiceAmount,
                    PaidAmount = t.PaidAmount,
                    DueAmount = t.DueAmount,
                    DueAmountCash = t.DueAmountCash,
                    DueAmountCredit = t.DueAmountCredit,
                    OverDueAmountCash = t.OverDueAmountCash,
                    OverDueAmountCredit = t.OverDueAmountCredit,

                });


                if (!territories.Any()) continue;


                rpt.TerritoryDetail = new List<LocationWiseOutstandingTerritoryDetailsDTO>();
                rpt.TerritoryDetail.AddRange(territories);

                foreach (var territory in rpt.TerritoryDetail)
                {
                    territory.InvoiceAmount = territory.InvoiceAmount.GetValueOrDefault(); 
                    territory.PaidAmount = territory.PaidAmount.GetValueOrDefault();
                    territory.DueAmountCash = territory.DueAmountCash.GetValueOrDefault();
                    territory.DueAmountCredit = territory.DueAmountCredit.GetValueOrDefault();
                    territory.DueAmount = territory.DueAmount.GetValueOrDefault();

                    territory.OverDueAmountCash = territory.OverDueAmountCash.GetValueOrDefault();
                    territory.OverDueAmountCredit = territory.OverDueAmountCredit.GetValueOrDefault();


                }

                report.Add(rpt);
            }


            return report;
        }


        public async Task<List<LocationWiseOutstandingDTO>> getOutstandingLocationWiseForExcel(string LocationCode, string PaymentMode, string FromDate, string DateTo)
        {
                return await repo.getOutstandingLocationWise(LocationCode, PaymentMode, FromDate, DateTo);
        }



        public async Task<List<LocationWiseOutstandingDetail>> getOutstandingLocationWiseDetail(string LocationCode, string SearchByCode, string PaymentMode, string Datefrom, string DateTo)
        {
            List<LocationWiseOutstandingDetail> report = new List<LocationWiseOutstandingDetail>();


            var data = await repo.getOutstandingLocationWiseDetail(LocationCode, SearchByCode,  PaymentMode, Datefrom, DateTo);

            var territories = data.GroupBy(x => x.TerritoryCode)
                      .Select(y => new {

                          AreaCode = y.First().AreaCode,
                          AreaName = y.First().AreaName,
                          AreaManagerID = y.First().AreaManagerID,
                          AreaManagerName = y.First().AreaManagerName,
                          
                          TerritoryCode = y.First().TerritoryCode,
                          TerritoryName = y.First().TerritoryName,

                          InvoiceAmount = y.Sum(x => x.InvoiceAmount),
                          PaidAmount = y.Sum(x => x.PaidAmount),
                          DueAmount = y.Sum(x => x.DueAmount),
                      });

            
            territories = territories.Where(t => t.DueAmount>0);           
            territories = territories.OrderBy(x => x.TerritoryCode).ToList();

            foreach (var territory in territories)
            {
                LocationWiseOutstandingDetail rpt = new LocationWiseOutstandingDetail();


                rpt.TerritoryCode = territory.TerritoryCode;
                rpt.TerritoryName = territory.TerritoryName;
                rpt.AreaCode = territory.AreaCode;
                rpt.AreaName = territory.AreaName;
                rpt.AreaManagerID = territory.AreaManagerID;
                rpt.AreaManagerName = territory.AreaManagerName;

                rpt.InvoiceAmount = territory.InvoiceAmount;
                rpt.PaidAmount = territory.PaidAmount;
                rpt.DueAmount = territory.DueAmount;




                // Territory Detail
                var territoryInvoices = data.Where(l => l.TerritoryCode == territory.TerritoryCode);


                if (!territories.Any()) continue;


                rpt.TerritoryInvoices = new List<LocationWiseOutstandingDetailDto>();
                rpt.TerritoryInvoices.AddRange(territoryInvoices);

                

                report.Add(rpt);
            }


            return report;
        }

        public async Task<List<LocationWiseOutstandingDetailDto>> getLocationWiseOutstandingDetailForExcel(string LocationCode, string SearchByCode, string PaymentMode, string FromDate, string DateTo)
        {
              return await repo.getOutstandingLocationWiseDetail(LocationCode, SearchByCode, PaymentMode, FromDate, DateTo);
        }

    }
}
