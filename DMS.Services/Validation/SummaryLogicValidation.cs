using DMS.Core.DTO.SummaryReturn;
using DMS.Core.GlobalConstant;
using DMS.Core.Models.SummaryInvoice;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMS.Services.Validation
{
    public class SummaryLogicValidation
    {

        public Boolean validateSummaryInvoice(AllocationInvoiceForSummaryMasterDto SummaryInvoice)
        {
            SummaryInvoice.ReturnStatus = SummaryInvoice.ReturnStatus.ToUpper();
            if (SummaryInvoice.ReturnStatus != InvoiceReturnType.NONE && SummaryInvoice.ReturnAmount>0 && string.IsNullOrEmpty(SummaryInvoice.ReturnReason))
                throw new Exception($"Please enter return reason for invoice :: {SummaryInvoice.InvoiceCode}");


            return true;
        }


        public async Task<Boolean> validateFinalInvoice(SummaryInvoice invoice, List<SummaryInvoiceDetail> detail)
        {
            decimal expectedInvoiceTotalTP = 0;
            decimal expectedInvoiceTotalVAT = 0;
            decimal expectedInvoiceNetAmount = 0;


            foreach (var product in detail)
            {
                var expectedProductTotalTP = product.SoldQty * product.Tp;
                var expectedProductTotalVAT = product.SoldQty * product.Vat;

                if (expectedProductTotalTP != product.TotalTp) throw new Exception($"Failed to save invoice. May be product price has been updated but invoice product price is different. Please check invoice >> InvoiceCode:{invoice.InvoiceCode}. Product: {product.ProductCode}, TP:{product.Tp}, VAT:{product.Vat}.   Expected product total TP  : {expectedProductTotalTP} is not matched with given total TP {product.TotalTp} ");
                if (expectedProductTotalVAT != product.TotalVat) throw new Exception($"Failed to save invoice. May be product price has been updated but invoice product price is different. Please check invoice >> InvoiceCode:{invoice.InvoiceCode}. Product: {product.ProductCode}, TP:{product.Tp}, VAT:{product.Vat}.   Expected product total VAT  : {expectedProductTotalVAT} is not matched with given total VAT {product.TotalVat} ");

                expectedInvoiceTotalTP += expectedProductTotalTP;
                expectedInvoiceTotalVAT += expectedProductTotalVAT;
                expectedInvoiceNetAmount += product.Amount;
            }

            expectedInvoiceNetAmount = Math.Round(expectedInvoiceNetAmount - invoice.CreditNoteAdjustedAmount) ;
            var difference = expectedInvoiceNetAmount - invoice.NetAmount;

            if (expectedInvoiceTotalTP != invoice.NetTp) throw new Exception($"Failed to save invoice. InvoiceCode:{invoice.InvoiceCode}.  Expected invoice total TP  : {expectedInvoiceTotalTP} is not matched with given total TP {invoice.NetTp} ");
            if (expectedInvoiceTotalVAT != invoice.NetVat) throw new Exception($"Failed to save invoice. InvoiceCode:{invoice.InvoiceCode}.  Expected invoice total VAT  : {expectedInvoiceTotalVAT} is not matched with given total VAT {invoice.NetVat} ");
            if (difference>1 || difference<-1) throw new Exception($"Failed to save invoice. InvoiceCode:{invoice.InvoiceCode}.  Expected invoice Net Amount: {expectedInvoiceNetAmount} is not matched with given invoice Net Amount {invoice.NetAmount} ");

            return true;
        }

    }
}
