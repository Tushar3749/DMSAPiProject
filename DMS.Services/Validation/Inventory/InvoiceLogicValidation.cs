using DMS.Core.Models.SalesInvoice;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMS.Services.Validation.Inventory
{
    public class InvoiceLogicValidation
    {

        public async Task<Boolean> validateFinalInvoice(Invoice invoice, List<InvoiceDetail> detail)
        {
            decimal expectedInvoiceTotalTP = 0;
            decimal expectedInvoiceTotalVAT = 0;
            decimal expectedInvoiceNetAmount = 0;


            foreach (var product in detail)
            {
                var expectedProductTotalTP = product.InvoiceQty * product.Tp;
                var expectedProductTotalVAT = product.InvoiceQty * product.Vat;

                if (expectedProductTotalTP != product.TotalTp) throw new Exception($"Failed to save invoice. May be product price has been updated but invoice product price is different.  Product: {product.ProductCode}, TP:{product.Tp}, VAT:{product.Vat}.   Expected product total TP  : {expectedProductTotalTP} is not matched with given total TP {product.TotalTp} ");
                if (expectedProductTotalVAT != product.TotalVat) throw new Exception($"Failed to save invoice. May be product price has been updated but invoice product price is different.  Product: {product.ProductCode}, TP:{product.Tp}, VAT:{product.Vat}. Expected product total VAT  : {expectedProductTotalVAT} is not matched with given total VAT {product.TotalVat} ");

                expectedInvoiceTotalTP += expectedProductTotalTP;
                expectedInvoiceTotalVAT += expectedProductTotalVAT;
                expectedInvoiceNetAmount += product.Amount;
            }

            expectedInvoiceNetAmount = Math.Round(expectedInvoiceNetAmount);
            var difference = expectedInvoiceNetAmount - (invoice.NetAmount + invoice.CreditNoteAdjustedAmount );  



            if ((expectedInvoiceTotalTP != invoice.NetTp)) throw new Exception($"Failed to save invoice. InvoiceCode:{invoice.InvoiceCode}.  Expected invoice total TP  : {expectedInvoiceTotalTP} is not matched with given total TP {invoice.NetTp} ");
            if (expectedInvoiceTotalVAT != invoice.NetVat) throw new Exception($"Failed to save invoice. InvoiceCode:{invoice.InvoiceCode}. Expected invoice total VAT  : {expectedInvoiceTotalVAT} is not matched with given total VAT {invoice.NetVat} ");
            
            if (difference > 1 || difference < -1) throw new Exception($"Failed to save invoice. Expected invoice Net Amount: {expectedInvoiceNetAmount} is not matched with given invoice Net Amount {invoice.NetAmount} ");

            return true;
        }
    }
}
