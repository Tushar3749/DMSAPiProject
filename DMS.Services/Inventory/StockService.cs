/*
*=============================================
*Author: Shafiqul Bari Sadman
*Email: sadman.it@labaidpharma.com
*Created on: 7 - jun - 2021
*Updated on: 7 - jun - 2021
*Last updated on:
*Description: <>
*=============================================
*/
using DMS.Core.DTO.Inventory;
using DMS.Core.Models.Inventory;
using DMS.Data.Repository;
using DMS.Services.Interfaces;
using DMS.Services.Map.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMS.Services.Inventory
{
    public class StockService : LoggerService, IstockService
    {
        private readonly StockReceiveRepository repo = null;
        private readonly StockReceiveDetailsRepository StockReceiveDetailsRepo = null;
        private readonly CodeGenerateRepository codeRepo = null;


        private readonly DbContext context;

        public StockService(IConfiguration Config)
        {
            this.context = new InventoryContext(Config);
            this.repo = new StockReceiveRepository(this.context);
            this.StockReceiveDetailsRepo = new StockReceiveDetailsRepository(this.context);
            this.codeRepo = new CodeGenerateRepository(this.context);
        }

        public async Task<List<StockReceiveDTO>> getPendingApprovalChallanReceive()
        {
           
                return await repo.getPendingApprovalChallanReceive();

        }


        public async Task<List<StockReceiveDTO>> getApprovedChallanReceive()
        {
            return await repo.getApprovedChallanReceive();
        }

        public async Task<StockReceive> UpdateReceivedChallan(StockReceive receive, string user)
        {
            try
            {
                await this.repo.BEGIN_TRANSACTION();

                receive = await repo.findOneChallanReceive(receive.Id);
                if (receive == null) throw new Exception($"Couldn't find Challan Receive using receive id: {receive.Id}. Please refresh and try again");

                receive.IsReceived = true;
                receive.ReceivedDate = DateTime.Now;
                receive.ReceivedByCode = user;

                await repo.update(receive);

                await this.repo.COMMIT();
                return receive;
            }
            catch (Exception ex)
            {
                await this.repo.ROLL_BACK();
                logException(ex);
                return null;
            }
        }

        public async Task<StockReceive> UpdateApprovedChallanList(List<StockReceiveDTO> details, string user)
        {
            StockReceive receivenew = new StockReceive();

            foreach (var item in details)
            {
                StockReceive newItem = new StockReceiveMap().map(item);
                receivenew = await UpdateApprovedChallan(newItem, user);
            }



            return receivenew;

        }
        
        public async Task<StockReceive> UpdateReceivedChallanList(List<StockReceiveDTO> details, string user)
        {
            StockReceive receivenew = new StockReceive();

            foreach (var item in details)
            {
                StockReceive newItem = new StockReceiveMap().map(item);
                receivenew = await UpdateReceivedChallan(newItem, user);
            }

            await repo.updateDepotReceiveAvailableStock();

            return receivenew;
        }

        public async Task<StockReceive> UpdateApprovedChallan(StockReceive receive, string user)
        {
            try
            {
                await this.repo.BEGIN_TRANSACTION();

                receive = await repo.findOneChallanReceive(receive.Id);
                if (receive == null) throw new Exception($"Couldn't find Challan Receive using receive id: {receive.Id}. Please refresh and try again"); 

                receive.IsApproved = true;
                receive.ApprovedDate = DateTime.Now;
                receive.ApprovedByCode = user;

                await repo.update(receive);           

                await this.repo.COMMIT();
                return receive;
            }
            catch (Exception ex)
            {
                await this.repo.ROLL_BACK();
                logException(ex);
                return null;
            }
        }
      
    }
}
