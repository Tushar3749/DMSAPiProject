using DMS.Core.Models.SummaryInvoice;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Validation
{
    public class InvoiceDetailSummaryValidator : AbstractValidator<SummaryInvoiceDetail>
    {
        public InvoiceDetailSummaryValidator()
        {
            RuleFor(g => g.InvoiceCode).NotNull().NotEmpty().WithMessage("Invoice code is missing");
            RuleFor(g => g.ProductCode).NotNull().NotEmpty().WithMessage("Product code is missing");
            RuleFor(g => g.SalesCode).NotNull().NotEmpty().WithMessage("Sales code is missing");
            RuleFor(g => g.PackSize).NotNull().NotEmpty().WithMessage("Pack size is missing");
            RuleFor(g => g.Sps).NotNull().GreaterThanOrEqualTo(0).WithMessage("SPS must be greater than zero");
            RuleFor(g => g.Tp).NotNull().GreaterThan(0).WithMessage("Product trade price value must be greater than zero.");
            //RuleFor(g => g.Vat).NotNull().GreaterThan(0).WithMessage("Product vat must be greater than zero.");
            RuleFor(g => g.SoldQty).NotNull().GreaterThanOrEqualTo(0).WithMessage("Sold quantity can not be null or empty.");
            RuleFor(g => g.BonusQty).NotNull().GreaterThanOrEqualTo(0).WithMessage("Bonus quantity can not be null or empty.");
            RuleFor(g => g.TotalTp).NotNull().GreaterThanOrEqualTo(0).WithMessage("Total Trade Price can not be less than zero or null.");
            //RuleFor(g => g.TotalVat).NotNull().GreaterThanOrEqualTo(0).WithMessage("Total vat amount can not be less than zero or null.");
            RuleFor(g => g.TotalAmountDiscount).NotNull().GreaterThanOrEqualTo(0).WithMessage("Total amount discount can not be less than zero or null.");
            RuleFor(g => g.TotalProductDiscount).NotNull().GreaterThanOrEqualTo(0).WithMessage("Total product discount can not be less than zero or null.");
            RuleFor(g => g.Amount).NotNull().GreaterThanOrEqualTo(0).WithMessage("Amount can not be less than zero or null.");
            RuleFor(g => g.MachineId).NotNull().WithMessage("Machine Credentials not found.");
            RuleFor(g => g.CreatedById).NotNull().WithMessage("Created By Id can not be empty or null.");
            RuleFor(g => g.CreatedOn).NotNull().WithMessage("Created on can not be empty or null.");
        }
    }
}
