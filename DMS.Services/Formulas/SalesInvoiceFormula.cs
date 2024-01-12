using System;

namespace DMS.Services.Formulas
{
    public class SalesInvoiceFormula
    {

        public decimal getTotalTP(int Quantity, decimal TradePrice)
        {
            return Quantity * TradePrice;
        }

        public decimal getTotalVAT(int Quantity, decimal VAT)
        {
            return Quantity * VAT;
        }

        public decimal getNetAmount(decimal TotalTP, decimal TotalVAT, decimal ProductDiscount, decimal AmountDiscount)
        {
            return (TotalTP - (ProductDiscount + AmountDiscount)) + TotalVAT;
        }
        public decimal getNetAmountWithoutAdjustment(decimal TotalTP, decimal TotalVAT, decimal ProductDiscount, decimal AmountDiscount)
        {
            return (TotalTP - (ProductDiscount + AmountDiscount)) + TotalVAT;
        }

        public decimal getNetAmount(decimal TotalTP, decimal TotalVAT, decimal ProductDiscount, decimal AmountDiscount, decimal AdjustedAmount)
        {
            return (TotalTP - (ProductDiscount + AmountDiscount + AdjustedAmount)) + TotalVAT;
        }

        public decimal getPercent(decimal Value1, decimal Value2)
        {
            if(Value1 > 0) return (Value2 / Value1) * 100;
            return 0;
        }

        public Boolean hasStockShort(int StockQuantity, int OrderQuantity, int BonusQuantity)
        {
            if ((OrderQuantity + BonusQuantity) > StockQuantity) return true;
            else return false;
        }



    }
}
