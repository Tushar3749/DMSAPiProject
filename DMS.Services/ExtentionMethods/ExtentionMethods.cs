using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
*=============================================
*Author: Shafiqul Bari Sadman
*Email: sadman.it@labaidpharma.com
*Created on: 7 - sep - 2021
*Updated on: 7 - sep - 2021
*Last updated on:
*Description: <>
*=============================================
*/



namespace DMS.Services.ExtentionMethods
{
   public static class ExtentionMethods
   {
        public static DateTime SetMaxDatetime(this DateTime EndDate)
        {
            return EndDate.AddHours(23).AddMinutes(59).AddSeconds(59);
        }
   }
}
