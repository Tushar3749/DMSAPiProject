
using DMS.Core.DTO.Chemist;
using DMS.Core.DTO.Discount;
using DMS.Core.Models.SalesInvoice;
using DMS.Data.Repository;
using DMS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMS.Services.Discount
{
    public class DiscountService : IDiscountService
    {
         /*
         *=============================================
         *Author: Shamsul Hasan Siam
         *Email: siam.it@labaidpharma.com
         *Created on: 21 JUNE 2021
         *Updated on: 
         *Last updated on:
         *Description: <>
         *=============================================
         */


        private DiscountRepository repo;
        
        private DbContext context;

        public DiscountService(IConfiguration Config)
        {
            this.context = new InvoiceContext(Config);
            this.repo = new DiscountRepository(this.context);

        }

        // GET discount by search

        public async Task<List<DiscountBySearchDto>> getDiscountBySearch(string LocationCode, string ProductCode, string SearchText)
        {
                return await repo.getDiscountBySearch(LocationCode, ProductCode, SearchText);    
        }


        public async Task<DiscountDto> getDiscountReport(string DiscountID)
        {

            DiscountReportDto Discount = await repo.getDiscountReportMaster(DiscountID);
            List<DiscountDetailDto> DiscountDetails = await repo.getDiscountReportDetails(DiscountID);

            return new DiscountDto { DiscountDetails = DiscountDetails, Discount = Discount };

        }


        public async Task<List<DiscountDetailDto>> getDiscountDetail(string DiscountID)
        {
           return await repo.getDiscountReportDetails(DiscountID);
        }
    }
}
