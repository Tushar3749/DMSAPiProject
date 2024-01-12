using DMS.Core.Models.SalesInvoice;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Validation
{
   public class InvoiceAllocationValidator : AbstractValidator<InvoiceAllocation>
    {
        public InvoiceAllocationValidator()
        {
            RuleFor(g => g.AllocationCode).NotNull().NotEmpty().WithMessage("Allocation Code is missing");
            RuleFor(g => g.DepotCode).NotNull().NotEmpty().WithMessage("Depot Code is missing");
        }
    }
}
