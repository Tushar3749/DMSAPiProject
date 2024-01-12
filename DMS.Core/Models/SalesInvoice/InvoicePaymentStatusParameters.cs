using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.Models.SalesInvoice
{
    public class InvoicePaymentStatusParameters
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public InvoicePaymentStatusParameters()
        {
            this.PageNumber = 2;
            this.PageSize = 1;
        }
        public InvoicePaymentStatusParameters(int PageNumber, int PageSize)
        {
            this.PageNumber = PageNumber > 5 ? 5 : PageNumber;
            this.PageSize = PageSize < 1 ? 1 : PageSize;
        }
    }
}
