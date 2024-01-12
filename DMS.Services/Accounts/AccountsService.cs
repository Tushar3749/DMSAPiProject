using DMS.Core.Dto.User;
using DMS.Core.DTO.Accounts;
using DMS.Core.DTO.Report;
using DMS.Core.Models.Accounts;
using DMS.Core.Models.SalesInvoice;
using DMS.Core.Models.SummaryInvoice;
using DMS.Core.Models.SystemManager;
using DMS.Data;
using DMS.Data.Repository;
using DMS.Services.Interfaces;
using DMS.Services.Validation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Services.Accounts
{
    public class AccountsService : LoggerService, IAccountsService
    {
        private readonly AccountsRepository repo = null;
        private readonly DbContext context;

        private readonly CodeGenerateRepository codeRepo = null;
        private readonly DbContext codeContext;

        private readonly CollectionRepository collRepo = null;
        private readonly DbContext sumContext;

        private readonly DbContext sysMContext;
        private readonly UserRepository userRepo;

        public AccountsService(IConfiguration Config)
        {
            this.context = new AccountsContext(Config);
            this.codeContext = new InvoiceContext(Config);

            this.repo = new AccountsRepository(this.context);
            this.codeRepo = new CodeGenerateRepository(this.codeContext);

            this.sumContext = new SummaryInvoiceContext(Config);
            this.collRepo = new CollectionRepository(this.sumContext);

            this.sysMContext = new SystemManagerContext(Config);
            this.userRepo = new UserRepository(this.sysMContext);
        }


        public async Task<object> saveMoneyReceipt(MoneyReceiptNewDto collection, UserBasicInfo User)
        {
            // Checking if Money Receipt is Already generated.
            List<MoneyReceipt> mrList = await repo.getMoneyReceiptByCollectionCode(collection.CollectionCode);
            if (mrList.Any()) throw new Exception("Money Receipt againest this collection is already taken.");

            // Map and Validate Money Receipt
            MoneyReceipt moneyReceipt = await mapAndValidateMoneyReceipt(collection, User);

            // Saving Money Receipt
            MoneyReceipt insertedMoneyReceipt = await repo.insertMoneyReceipt(moneyReceipt);
            if (insertedMoneyReceipt == null) throw new Exception("Failed to insert money receipt. Please try again.");


            var mrDetail = await repo.getMRByCode(insertedMoneyReceipt.MoneyReceiptCode);
            var collInvoice = await collRepo.getSumCollMoneyReceiptDetail(insertedMoneyReceipt.SummaryCollectionCode);
            var collInstrument = await collRepo.getSumCollMoneyReceiptInstrument(insertedMoneyReceipt.SummaryCollectionCode);
            var location = await userRepo.getCurrentLocation();

            return new { DepotLocation = location, MoneyReceipt = mrDetail, CollectionInvoice = collInvoice, CollectionInstrument = collInstrument };
        }


        private async Task<MoneyReceipt> mapAndValidateMoneyReceipt(MoneyReceiptNewDto collection, UserBasicInfo User)
        {
            MoneyReceipt mr = new MoneyReceipt();

            mr.MoneyReceiptDate = System.DateTime.Now;
            mr.SummaryCollectionCode = collection.CollectionCode;
            mr.CashAmount = collection.CashCollectionAmount.GetValueOrDefault();
            mr.ChequeAmount = collection.ChequeCollectionAmount.GetValueOrDefault();
            mr.Amount = collection.Amount.GetValueOrDefault();
            mr.CollectedFromCode = collection.DACode;
            mr.Remarks = collection.Remarks;
            
            mr.IsActive = true;
            mr.CreatedById = User.EmployeeID;
            mr.CreatedOn = System.DateTime.Now;
            mr.ModuleVersion = Core._MODULE_VERSION.ACCOUNT;
            mr.MachineId = "La machina";
            mr.DepotCode = User.DepotCode;

            // Checking Collection Amount
            if (collection.CashCollectionAmount.GetValueOrDefault() + collection.ChequeCollectionAmount.GetValueOrDefault() != collection.Amount.GetValueOrDefault())
                throw new Exception("Sum value of cash and cheque amount missmatch with total amount.");

            // Generating Money Receipt Code
            mr.MoneyReceiptCode = await codeRepo.getGeneratedCode("RECEIPT");

            ValidationResult result = new MoneyReceiptValidator().Validate(mr);
            if (!result.IsValid) throw new Exception(result.ToString(" ~"));

            return mr;
        }

        public async Task<object> getMoneyReceiptDetailsByMoneyReceiptCode(string MoneyReceiptCode)
        {
            var mrDetail = await repo.getMRByCode(MoneyReceiptCode);
            var collInvoice = await collRepo.getSumCollMoneyReceiptDetail(mrDetail.CollectionCode);
            var collInstrument = await collRepo.getSumCollMoneyReceiptInstrument(mrDetail.CollectionCode);
            var location = await userRepo.getCurrentLocation();

            return new { DepotLocation = location, MoneyReceipt = mrDetail, CollectionInvoice = collInvoice, CollectionInstrument = collInstrument };
        }


        public async Task<List<BankListDTO>> getbanklist()
        {
            return await repo.getbanklist();
        }

        public async Task<List<BankListDTO>> getChemistbanklist()
        {
            return await repo.getChemistbanklist();
        }

        public async Task<List<InstrumentInfoDto>> getInstrumentInfoList()
        {
            return await repo.getInstrumentInfoList();
        }

        public async Task<List<BankListDTO>> getbankinfobybankcode(string bankcode)
        {
            return await repo.getbankinfobybankcode(bankcode);
        }

        public async Task<List<SummaryPendingCollectionDto>> getSummaryPendingCollection()
        {
            return await this.repo.getSummaryPendingCollection();
        }

        public async Task<List<SummaryPendingCollectionDetailDto>> getSummaryPendingCollectionDetail(string SummaryCode)
        {
            return await this.repo.getSummaryPendingCollectionDetail(SummaryCode);
        }

        public async Task<List<DepositType>> getdeposittypelist()
        {
            return await repo.getdeposittypelist();

        }

        public async Task<IEnumerable<DepositDetailReportDTO>> getbankdepositDetail(string depositCode)
        {
            List<DepositDetailReportDTO> master = await repo.getbankdepositDetail(depositCode);

            return master;
        }

        public async Task<IEnumerable<DepositReportDTO>> getbankdepositlist(DateTime startdate, DateTime enddate)
        {
            List<DepositReportDTO> master = await repo.getbankdepositmasterlist(startdate, enddate);

            return master;
        }

        public async Task<List<DepositDetailDTO>> getbankdepositlistbyId(int Id)
        {
            List<DepositDetailDTO> detail = await repo.getbankdepositlistbyId(Id);
            foreach (var item in detail)
            {
                var master = await repo.getbankdepositmasterbyDepositCode(item.DepositCode);
                item.DepositCode = master.DepositCode;
                item.CashReceiveByCode = master.CashReceivedByCode;
                item.BankCode = master.BankCode;
                item.Remarks = master.Remarks;
                item.Branch = master.DepositBranch;

            }

            return detail;
        }

        public async Task<List<DueCollectionChemistWiseDto>> getDueCollectionChemistWise()
        {
            return await repo.getDueCollectionChemistWise();
        }

        public async Task<List<DueCollectionChemistWiseDetailDto>> getDueCollectionChemistWiseDetail(string ChemistCode)
        {
            return await repo.getDueCollectionChemistWiseDetail(ChemistCode);
        }

        public async Task<object> saveDeposit(BankDepositDto bankDepositDto, UserBasicInfo user)
        {
            Deposit newDeposit = await mapAndValidateBankDeposit(bankDepositDto.Deposit, user);

            bankDepositDto.DepositDetail.All(i =>
            {
                i.DepositCode = newDeposit.DepositCode;
                i.IsActive = true;
                i.CreatedOn = System.DateTime.Now;
                i.CreatedById = user.EmployeeID;
                i.MachineId = "La Machina";


                return true;
            });

            var insertedDeposit = await insertDeposit(newDeposit, bankDepositDto.DepositDetail);
            var insertedDetail = await repo.getDepositDetailByDepositCode(insertedDeposit.DepositCode);
            return new { Deposit = insertedDeposit, DepositDetail = insertedDetail };
        }


        private async Task<Deposit> insertDeposit(Deposit deposit, List<DepositDetail> depositDetails)
        {
            await repo.BEGIN_TRANSACTION();

            Deposit insertedDepost = await repo.saveDepost(deposit);
            if (insertedDepost == null)
            {
                await repo.ROLL_BACK();
                throw new Exception("Failed to Save Deposit.");
            }

            List<DepositDetail> details = await repo.saveDepositDetailBulk(depositDetails);
            if (!details.Any())
            {
                await repo.ROLL_BACK();
                throw new Exception("Failed to Save Deposit.");
            }

            await repo.COMMIT();

            return insertedDepost;
        }

        private async Task<Deposit> mapAndValidateBankDeposit(Deposit depositDto, UserBasicInfo User)
        {
            depositDto.DepositCode = await codeRepo.getGeneratedCode("DEPOSIT");
            if (depositDto.DepositCode == null) throw new Exception("No Deposit Code Found");
            //depositDto.DepositByCode = User.EmployeeID;

            depositDto.IsActive = true;
            depositDto.CreatedOn = System.DateTime.Now;
            depositDto.CreatedById = User.EmployeeID;
            depositDto.MachineId = "La Machina";
            depositDto.DepotCode = User.DepotCode;

            return depositDto;
        }


        public async Task<DepositDetail> getLatestDeposit()
        {
            return await repo.getLatestDeposit();
        }

        public async Task<List<MoneyReceiptDateWiseDto>> getMoneyReceipt(string FromDate, string ToDate)
        {
            return await repo.getMoneyReceiptDateWise(FromDate, ToDate);
        }

        // GET 
        public async Task<List<MoneyReceiptDAWiseDto>> getMoneyReceiptDAWise(string FromDate, string ToDate, string DACode)
        {
            return await repo.getMoneyReceiptDAWise(FromDate, ToDate, DACode);
        }

        // GET 
        public async Task<List<MoneyReceiptByCodeDto>> getMoneyReceiptByCode(string MRCode)
        {
            return await repo.getMoneyReceiptByCode(MRCode);
        }

        public async Task<object> saveBankInfo(List<Bank> bankDepositDto)
        {

            bankDepositDto.All(i =>
            {
                i.IsActive = true;
                i.IsLabaidAccount = false;

                return true;
            });

            foreach (var item in bankDepositDto)
            {
                if (String.IsNullOrEmpty(item.BankName) || String.IsNullOrEmpty(item.BranchName)) 
                {
                    return false;
                }
                if ( String.IsNullOrEmpty(item.BankCode) || item.BankCode == "NEW" )
                {
                    item.BankCode = await repo.GenerateBankCode();
                    var insertedbank = await repo.saveBank(item);

                }
                else
                {
                    var updatedbank = await repo.updateBank(item);

                }
            }

            return new { Deposit = "" };
        }
        public async Task<object> InactiveBank(Bank bank)
        {
            return await repo.InactiveBank(bank);
        }
        public async Task<object> ActiveBank(Bank bank)
        {
            return await repo.ActiveBank(bank);
        }

        public async Task<List<LocationWiseCollectionReport>> getLocationWiseCollectionReport(string LocationCode, string DateFrom, string DateTo, string PaymentMode)
        {

            List<LocationWiseCollectionReport> report = new List<LocationWiseCollectionReport>();


            var data = await repo.getLocationWiseCollectionReport(LocationCode, DateFrom, DateTo, PaymentMode);

            //var areas = data.GroupBy(l => l.AreaID).Select(l => l.First() ).ToList();
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
                          CashCollectionAmount = y.Sum(x => x.CashCollectionAmount),
                          ChequeCollectionAmount = y.Sum(x => x.ChequeCollectionAmount),
                          TotalCollection = y.Sum(x => x.TotalCollection),
                          CashInvoiceCollection = y.Sum(x => x.CashInvoiceCollection),
                          CreditInvoiceCollection = y.Sum(x => x.CreditInvoiceCollection),
                      });



            foreach (var area in areas)
            {
                LocationWiseCollectionReport rpt = new LocationWiseCollectionReport();

                rpt.RegionID = area.RegionID;
                rpt.RegionName = area.RegionName;
                rpt.RegionalManagerID = area.RegionalManagerID;
                rpt.RegionalManagerName = area.RegionalManagerName;

                rpt.AreaID = area.AreaID;
                rpt.AreaName = area.AreaName;
                rpt.AreaManagerID = area.AreaManagerID;
                rpt.AreaManagerName = area.AreaManagerName;

                rpt.TotalCollection = area.TotalCollection;
                rpt.CashCollectionAmount = area.CashCollectionAmount;
                rpt.ChequeCollectionAmount = area.ChequeCollectionAmount;


                rpt.CashInvoiceCollection = area.CashInvoiceCollection;
                rpt.CreditInvoiceCollection = area.CreditInvoiceCollection;


                // Territory Detail
                var territories = data.Where(l => l.AreaID == area.AreaID).Select(t => new LocationWiseCollectionTerritoryDetailsDto
                {
                    TerritoryID = t.TerritoryID,
                    TerritoryName = t.TerritoryName,
                    MPOID = t.MPOID,
                    MPOName = t.MPOName,
                    CashCollectionAmount = t.CashCollectionAmount,
                    ChequeCollectionAmount = t.ChequeCollectionAmount,
                    TotalCollection = t.TotalCollection,
                    CashInvoiceCollection = t.CashInvoiceCollection,
                    CreditInvoiceCollection = t.CreditInvoiceCollection

                });


                if (!territories.Any()) continue;


                rpt.TerritoryDetail = new List<LocationWiseCollectionTerritoryDetailsDto>();
                rpt.TerritoryDetail.AddRange(territories);

                foreach (var territory in rpt.TerritoryDetail)
                {
                    territory.CashCollectionAmount = territory.CashCollectionAmount.GetValueOrDefault();
                    territory.ChequeCollectionAmount = territory.ChequeCollectionAmount.GetValueOrDefault();
                    territory.TotalCollection = territory.TotalCollection.GetValueOrDefault();
                    territory.CashInvoiceCollection = territory.CashInvoiceCollection.GetValueOrDefault();
                    territory.CreditInvoiceCollection = territory.CreditInvoiceCollection.GetValueOrDefault();
                }

                report.Add(rpt);
            }


            return report;
        }
    }
}
