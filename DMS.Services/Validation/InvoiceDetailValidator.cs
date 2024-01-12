/*
 *=============================================
 *Author: Md. Rahat Hossain 
 *Email: rahat@labaidpharma.com
 *Created on: 7 June, 2021
 *Updated on:
 *Last updated on:
 *Description:
 *=============================================
*/
using DMS.Core.Models.SalesInvoice;
using FluentValidation;

namespace DMS.Services.Validation
{
    public class InvoiceDetailValidator : AbstractValidator<InvoiceDetail>
    {
        public InvoiceDetailValidator()
        {
            RuleFor(g => g.ProductCode).NotNull().NotEmpty().WithMessage("Product is missing");
            RuleFor(g => g.PackSize).NotNull().NotEmpty().WithMessage("Pack size is missing");
            RuleFor(g => g.DiscountCode).NotNull().NotEmpty().WithMessage("No discount code found. At least trade discount should be there.");

            RuleFor(g => g.Sps).NotNull().NotEmpty().GreaterThan(0).WithMessage("Pack size can not be less than or equal to zero.");
            RuleFor(g => g.Tp).NotNull().NotEmpty().GreaterThan(0).WithMessage("Tp can not be less than or equal to zero.");
            //RuleFor(g => g.Vat).NotNull().NotEmpty().GreaterThan(0).WithMessage("Vat can not be less than or equal to zero.");
            RuleFor(g => g.InvoiceQty).NotNull().NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Invoice Qty can not be greater than zero.");
            RuleFor(g => g.BonusQty).NotNull().GreaterThanOrEqualTo(0).WithMessage("Bonus Qty must be greater than or equal to zero.");
            RuleFor(g => g.ProductDiscount).NotNull().GreaterThanOrEqualTo(0).WithMessage("Product discount must be greater than or equal to zero.");
            RuleFor(g => g.TotalTp).NotNull().GreaterThan(0).WithMessage("Total TP must be greater than 0.");
            //RuleFor(g => g.TotalVat).NotNull().GreaterThan(0).WithMessage("Total Vat must be greater than 0.");
            RuleFor(g => g.Amount).NotNull().NotEmpty().GreaterThan(0).WithMessage("Product Amount must be greater than 0.");
            RuleFor(g => g.MachineId).NotNull().NotEmpty().WithMessage("Machine Credentials not found.");
        }
    }
}
