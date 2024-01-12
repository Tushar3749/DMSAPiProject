using System;
using System.Collections.Generic;

namespace DMS.Core.DTO.SummaryReturn
{
    public class SummaryCollectionNewDto
    {
        public string ChemistCode { get; set; }
        public string ChemistName { get; set; }
        public Boolean HasChequePayment { get; set; }
        public string ChequeNumber { get; set; }
        public string ChequeBankName { get; set; }
        public string ChequeBankBranch { get; set; }
        public string ChequeDate { get; set; }
        public Nullable<decimal> ChequeAmount { get; set; }
        public List<SummaryCollectionDetailNew> CollectionDetail { get; set; }
        public Boolean HasError { get; set; }
        public string InstrumentBank { get; set; }

    }
}
