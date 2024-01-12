using DMS.Core.DTO.Chemist;
using DMS.Core.DTO.Discount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Interfaces
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
    public interface IDiscountService
    {
        Task<List<DiscountBySearchDto>> getDiscountBySearch(string LocationCode, string ProductCode, string SearchText);

        Task<DiscountDto> getDiscountReport(string DiscountID);

        Task<List<DiscountDetailDto>> getDiscountDetail(string DiscountID);
    }


    /*
     *=============================================
     * END Of Author Shamsul Hasan Siam
     *=============================================
    */
}
