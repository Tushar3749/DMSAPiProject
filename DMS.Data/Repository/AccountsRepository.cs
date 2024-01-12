using DMS.Core.DTO;
using DMS.Core.DTO.Accounts;
using DMS.Core.DTO.SalesInvoice;
using DMS.Core.Models.Accounts;
using DMS.Data.Repositories.GenericRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Data.Repository
{
    public class AccountsRepository : Repository
    {
        private DbContext context = null;
        //public IDbContextTransaction transaction = null;

        public AccountsRepository(DbContext context) : base(context)
        {
            this.context = context;
        }

        //public async Task<Boolean> BEGIN_TRANSACTION()
        //{
        //    this.transaction = await this.context.Database.BeginTransactionAsync();
        //    return true;
        //}

        //public async Task<Boolean> COMMIT()
        //{
        //    if (this.transaction != null) await this.transaction.CommitAsync();
        //    return true;
        //}

        //public async Task<Boolean> ROLL_BACK()
        //{
        //    if (this.transaction != null) await this.transaction.RollbackAsync();
        //    return true;
        //}

        public async Task<List<BankListDTO>> getbanklist()
        {
            return await this.context.Set<BankListDTO>().FromSqlRaw("exec getbanklist").ToListAsync();
        }
        public async Task<List<BankListDTO>> getChemistbanklist()
        {
            return await this.context.Set<BankListDTO>().FromSqlRaw("exec getChemistbanklist").ToListAsync();
        }
        public async Task<List<InstrumentInfoDto>> getInstrumentInfoList()
        {
            return await this.context.Set<InstrumentInfoDto>().FromSqlRaw("exec getchecknolist").ToListAsync();
        }

        public async Task<List<BankListDTO>> getbankinfobybankcode(string bankcode)
        {
            SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@bankcode", bankcode) };
            return await new GenericRepository<BankListDTO>(context).FindUsingSPAsync("exec getbankinfobybankcode @bankcode", sqlParams);
        }

        public async Task<List<SummaryPendingCollectionDto>> getSummaryPendingCollection()
        {
            return await this.context.Set<SummaryPendingCollectionDto>().FromSqlRaw("exec getSummaryPendingCollection").ToListAsync();
        }

        public async Task<List<SummaryPendingCollectionDetailDto>> getSummaryPendingCollectionDetail(string SummaryCode)
        {
            return await this.context.Set<SummaryPendingCollectionDetailDto>().FromSqlRaw("exec getSummaryPendingCollectionDetail @SummaryCode", new SqlParameter("@SummaryCode", SummaryCode)).ToListAsync();
        }

        public async Task<List<DepositType>> getdeposittypelist()
        {
            return await new GenericRepository<DepositType>(context).GetAll();
        }

        public async Task<List<DepositDetailDTO>> getbankdepositlistbyId(int Id)
        {
            var result = await new GenericRepository<DepositDetail>(this.context).Find(i => i.IsActive == true && i.Id == Id);


            return result.Select(x => new DepositDetailDTO
            {
                Id = x.Id,
                DepositType = x.DepositTypeCode,
                DepositTypeName = x.DepositTypeCode,
                DepositTypeCode = x.DepositTypeCode,
                DepositAmount = x.DepositAmount,
                InstrumentNumber = x.InstrumentNumber,
                ChequeDate = x.InstrumentDate,
                ChequeBank = x.InstrumentBank,
                CashReceiveByCode = x.CashReceiveByCode,
                MachineId = x.MachineId,
                IsActive = x.IsActive,
                CreatedById = x.CreatedById,
                CreatedOn = x.CreatedOn,
                UpdatedById = x.UpdatedById,
                UpdatedOn = x.UpdatedOn,
                ChequeNumber = x.InstrumentNumber,
                DepositCode = x.DepositCode,
                CashReceiveByDate = x.CashReceiveByDate

            }).ToList();
        }

       
        public async Task<List<DepositDetailReportDTO>> getbankdepositDetail(string depositCode)
        {
            return await this.context.Set<DepositDetailReportDTO>().FromSqlRaw("exec rptDepositReport @depositCode", new SqlParameter("@depositCode", depositCode)).ToListAsync();
        }

        public async Task<List<DepositReportDTO>> getbankdepositmasterlist(DateTime startdate, DateTime enddate)
        {
            enddate = enddate.AddHours(23).AddMinutes(59).AddSeconds(59);
            return await this.context.Set<DepositReportDTO>().FromSqlRaw("exec getBankDepositMasterList @FromDate,@ToDate", new SqlParameter("@FromDate", startdate), new SqlParameter("@ToDate", enddate)).ToListAsync();
        }

        public async Task<Deposit> getbankdepositmasterbyDepositCode(string DepositCode)
        {

            return await new GenericRepository<Deposit>(this.context).FindOne(i => i.IsActive == true && i.DepositCode == DepositCode);
        }


        public async Task<Deposit> saveDepost(Deposit detail)
        {
            return await new GenericRepository<Deposit>(this.context).Insert(detail);
        }

        public async Task<List<DepositDetail>> saveDepositDetailBulk(List<DepositDetail> detail)
        {
            return await new GenericRepository<DepositDetail>(this.context).InsertBulk(detail);
        }

        public async Task<List<MoneyReceipt>> getMoneyReceiptByCollectionCode(string CollectionCode)
        {
            return await new GenericRepository<MoneyReceipt>(this.context).Find(i => i.SummaryCollectionCode == CollectionCode && i.IsActive == true);
        }

        
        public async Task<List<DepositDetail>> getDepositDetailByDepositCode(string DepositCode)
        {
            return await new GenericRepository<DepositDetail>(this.context).Find(i => i.DepositCode == DepositCode && i.IsActive == true);
        }

        public async Task<MoneyReceipt> insertMoneyReceipt(MoneyReceipt entity)
        {
            return await new GenericRepository<MoneyReceipt>(this.context).Insert(entity);
        }

        public async Task<List<DueCollectionChemistWiseDto>> getDueCollectionChemistWise()
        {
            return await this.context.Set<DueCollectionChemistWiseDto>().FromSqlRaw("exec getInvoiceDueChemistWise").ToListAsync();
        }

        public async Task<List<DueCollectionChemistWiseDetailDto>> getDueCollectionChemistWiseDetail(string ChemistCode)
        {
            return await this.context.Set<DueCollectionChemistWiseDetailDto>().FromSqlRaw("exec getInvoiceDueChemistWiseDetail @ChemistCode", new SqlParameter("@ChemistCode", ChemistCode)).ToListAsync();
        }

        public async Task<List<MoneyReceiptDateWiseDto>> getMoneyReceiptDateWise(string FromDate, string ToDate)
        {
            return await this.context.Set<MoneyReceiptDateWiseDto>().FromSqlRaw("exec getMoneyReceiptDateWise @FromDate, @ToDate",
                new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate)).ToListAsync();
        }

        public async Task<MoneyReceiptDateWiseDto> getMRByCode(string mrCode)
        {
            var data = await this.context.Set<MoneyReceiptDateWiseDto>().FromSqlRaw("exec getMoneyReceipt @MoneyReceiptCode", new SqlParameter("@MoneyReceiptCode", mrCode)).ToListAsync();
            return data.FirstOrDefault();
        }
        
        public async Task<DepositDetail> getLatestDeposit()
        {
            var res =  await new GenericRepository<DepositDetail>(this.context).GetAll();
            return res.LastOrDefault();

        }

        public async Task<List<MoneyReceiptDAWiseDto>> getMoneyReceiptDAWise(string FromDate, string ToDate, string DACode)
        {
            return await this.context.Set<MoneyReceiptDAWiseDto>().FromSqlRaw("exec getMoneyReceiptDAWise @FromDate, @ToDate, @DACode",
                 new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate), new SqlParameter("@DACode", DACode)).ToListAsync();
        }

        public async Task<List<MoneyReceiptByCodeDto>> getMoneyReceiptByCode( string MRCode)
        {
            return await this.context.Set<MoneyReceiptByCodeDto>().FromSqlRaw("getMoneyReceiptByCode  @MRCode"
                ,new SqlParameter("@MRCode", MRCode)).ToListAsync();
        }
        public async Task<string> GenerateBankCode()
        {
            var code = await this.context.Set<GenerateCodeDTO>().FromSqlRaw("exec GenerateBankCode").ToListAsync();

            return code.FirstOrDefault().Code;

        }
        public async Task<Bank> saveBank(Bank info)
        {
            return await new GenericRepository<Bank>(this.context).Insert(info);
        }
        public async Task<Bank> updateBank(Bank info)
        {
            return await new GenericRepository<Bank>(this.context).Update(info, i => i.BankCode == info.BankCode);

        }
        public async Task<bool> InactiveBank(Bank info)
        {
            info.IsActive = false;
            var res = await new GenericRepository<Bank>(this.context).Update(info, i => i.BankCode == info.BankCode);
            return true;
        }
        public async Task<bool> ActiveBank(Bank info)
        {
            info.IsActive = true;
            var res = await new GenericRepository<Bank>(this.context).Update(info, i => i.BankCode == info.BankCode);
            return true;
        }
        public async Task<List<LocationWiseCollectionReportDTO>> getLocationWiseCollectionReport(string LocationCode, string DateFrom, string DateTo, string PaymentMode)
        {
            this.context.Database.SetCommandTimeout(600);
            var data = await this.context.Set<LocationWiseCollectionReportDTO>().FromSqlRaw("getLocationWiseCollectionReport @LocationCode, @DateFrom, @DateTo, @PaymentMode",
                new SqlParameter("@LocationCode", LocationCode),
                new SqlParameter("@DateFrom", DateFrom),
                new SqlParameter("@DateTo", DateTo),
                new SqlParameter("@PaymentMode", PaymentMode)
                ).ToListAsync();
            return data;
        }
    }
}
