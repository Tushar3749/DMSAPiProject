using DMS.Core.Dto.User;
using DMS.Core.DTO.Accounts;
using DMS.Core.DTO.Report;
using DMS.Core.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMS.Services.Interfaces
{
    public interface IAccountsService 
    {
       
        Task<List<BankListDTO>> getbanklist();
        Task<List<BankListDTO>> getChemistbanklist();

        Task<List<InstrumentInfoDto>> getInstrumentInfoList();

        Task<List<BankListDTO>> getbankinfobybankcode(string bankcode);
        Task<List<SummaryPendingCollectionDto>> getSummaryPendingCollection();
        Task<List<SummaryPendingCollectionDetailDto>> getSummaryPendingCollectionDetail(string SummaryCode);
        Task<List<DepositType>> getdeposittypelist();
        Task<List<DueCollectionChemistWiseDto>> getDueCollectionChemistWise();
        Task<List<DueCollectionChemistWiseDetailDto>> getDueCollectionChemistWiseDetail(string ChemistCode);
        Task<IEnumerable<DepositDetailReportDTO>> getbankdepositDetail(string depositcode);
        //   Task<Deposit> Savedeposit(List<DepositDTO> newData);

        Task<object> saveDeposit(BankDepositDto bankDepositDto, UserBasicInfo user);

        Task<IEnumerable<DepositReportDTO>> getbankdepositlist(DateTime startdate, DateTime enddate);

        Task<List<DepositDetailDTO>> getbankdepositlistbyId(int Id);
        Task<DepositDetail> getLatestDeposit();
        Task<List<MoneyReceiptDateWiseDto>> getMoneyReceipt(string FromDate, string ToDate);

        Task<object> saveMoneyReceipt(MoneyReceiptNewDto collection, UserBasicInfo User);

        Task<object> getMoneyReceiptDetailsByMoneyReceiptCode(string MoneyReceiptCode);
        Task<List<MoneyReceiptDAWiseDto>> getMoneyReceiptDAWise(string FromDate, string ToDate, string DACode);
        Task<List<MoneyReceiptByCodeDto>> getMoneyReceiptByCode(string MRCode);
        Task<object> saveBankInfo(List<Bank> bankDepositDto);
        Task<object> InactiveBank(Bank bank);
        Task<object> ActiveBank(Bank bank);

        Task<List<LocationWiseCollectionReport>> getLocationWiseCollectionReport(string LocationCode, string DateFrom, string DateTo, string PaymentMode);
        
    }
}
