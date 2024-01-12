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
using Microsoft.EntityFrameworkCore;

namespace DMS.Core.DTO.Orders
{
    [Keyless]
    public class MPOByTerritoryDto 
    {
        
        public string MPOID { get; set; }

        public string MPOName { get; set; }

    }

}
