
using DMS.Core.Models.SalesInvoice;
using FluentValidation;

namespace DMS.Services.Validation
{
    public class InvoiceValidator : AbstractValidator<Invoice>
    {
        public InvoiceValidator()
        {
            RuleFor(g => g.InvoiceCode).NotNull().NotEmpty().WithMessage("Invoice Code is missing");
            RuleFor(g => g.InvoiceDate).NotNull().NotEmpty().WithMessage("Invoice Date is missing");
            RuleFor(g => g.OrderCode).NotNull().NotEmpty().WithMessage("Order Code is missing");
            RuleFor(g => g.ChemistCode).NotNull().NotEmpty().WithMessage("Chemist Code is missing");
            RuleFor(g => g.Mpocode).NotNull().NotEmpty().WithMessage("MPO not found");
            RuleFor(g => g.DepotCode).NotNull().NotEmpty().WithMessage("Depot not found");
            RuleFor(g => g.TerritoryCode).NotNull().NotEmpty().WithMessage("Territory Code is missing");
            RuleFor(g => g.PaymentMode).NotNull().NotEmpty().WithMessage("Payment mode is missing");
            RuleFor(g => g.NetTp).NotNull().GreaterThan(0).WithMessage("Total TP must be greater than 0.");
            //RuleFor(g => g.NetVat).NotNull().GreaterThan(0).WithMessage("Total Vat must be greater than 0.");
            RuleFor(g => g.NetProductDiscount).NotNull().GreaterThanOrEqualTo(0).WithMessage("Product Discount can not be less than 0.");
            RuleFor(g => g.NetAmountDiscount).NotNull().GreaterThanOrEqualTo(0).WithMessage("Amount Discount can not be less than 0.");
            RuleFor(g => g.NetAmount).NotNull().GreaterThan(0).WithMessage("Net Amount can not be less than 0.");
            //RuleFor(g => g.MachineId).NotNull().NotEmpty().WithMessage("Machine Credentials not found.");
            RuleFor(g => g.CreatedById).NotNull().NotEmpty().WithMessage("Created By Id not found");
            RuleFor(g => g.CreatedOn).NotNull().NotEmpty().WithMessage("Create date is missing.");
        }
    }
}
