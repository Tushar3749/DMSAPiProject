/*
 *=============================================
 *Author: Md. Rahat Hossain 
 *Email: rahat@labaidpharma.com
 *Created on: 7 June, 2021
 *Updated on:
 *Last updated on:
 *Description:
 *=============================================
*/

using Microsoft.EntityFrameworkCore;

namespace DMS.Core.DTO.DepotInventory
{
    [Keyless]
    public class ProductBatchStockForInvoice
    {
        public string ProductCode { get; set; }
        public string BatchNo { get; set; }
        public int StockQty { get; set; }
    }
}
