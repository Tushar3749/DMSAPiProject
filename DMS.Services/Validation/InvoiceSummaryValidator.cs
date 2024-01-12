using DMS.Core.Models.SummaryInvoice;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Validation
{
    public class InvoiceSummaryValidator : AbstractValidator<SummaryInvoice>
    {
        public InvoiceSummaryValidator()
        {
            RuleFor(g => g.InvoiceCode).NotNull().NotEmpty().WithMessage("Invoice code is missing");
            RuleFor(g => g.NetTp).NotNull().GreaterThanOrEqualTo(0).WithMessage("Net TP can not be null or empty.");
            RuleFor(g => g.NetVat).NotNull().GreaterThanOrEqualTo(0).WithMessage("Net Vat can not be null or empty.");
            RuleFor(g => g.NetProductDiscount).NotNull().GreaterThanOrEqualTo(0).WithMessage("Product Discount can not be less than zero or null.");
            RuleFor(g => g.NetAmountDiscount).NotNull().GreaterThanOrEqualTo(0).WithMessage("Amount Discount can not be less than zero or null.");
            RuleFor(g => g.NetAmount).NotNull().GreaterThanOrEqualTo(0).WithMessage("Amount must be less than zero or null.");
            RuleFor(g => g.MachineId).NotNull().NotEmpty().WithMessage("Machine Credentials not found.");
            RuleFor(g => g.CreatedById).NotNull().NotEmpty().WithMessage("Created By Id can not be empty or null.");
            RuleFor(g => g.CreatedOn).NotNull().NotEmpty().WithMessage("Created on can not be empty or null.");
        }
    }
}
