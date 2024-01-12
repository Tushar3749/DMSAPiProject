using DMS.Core.Dto.User;
using DMS.Core.DTO.SalesInvoice;
using DMS.Core.Models.SalesInvoice;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMS.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task<Invoice> saveInvoice(InvoiceDto newInvoice, UserBasicInfo _SESSION_USER);

        Task<InvoiceNewDto> getOrderDetailForInvoice(string orderCode, Boolean HasCreditNoteAdjustment);

        Task<InvoiceNewDto> applyBonusAndDiscountForInvoiceDetail(List<InvoiceDetailNewDto> Invoice, string ChemistCode, string PaymentMode, Boolean HasCreditNoteAdjustment);
        Task<List<LocationWiseInvoiceDateBetweenDto>> getLocationWiseInvoiceDateBetween(string FromDate, string ToDate, string PaymentMode, string LocationCode);
    }
}
