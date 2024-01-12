using DMS.Core.Models.SalesInvoice;
using FluentValidation;

namespace DMS.Services.Validation
{

    public class SalesOrderValidator : AbstractValidator<Order>
	{
		public SalesOrderValidator()
		{
			RuleFor(g => g.OrderCode).NotNull().NotEmpty().WithMessage("Order Code is missing");
			RuleFor(g => g.ChemistCode).NotNull().NotEmpty().WithMessage("Chemist Code is missing");
			RuleFor(g => g.TerritoryCode).NotNull().NotEmpty().WithMessage("Territory Code is missing");
			RuleFor(g => g.DepotCode).NotNull().NotEmpty().WithMessage("Depot Code is missing");
			RuleFor(g => g.PaymentMode).NotNull().NotEmpty().WithMessage("Payment mode is missing");
		}
	}
}
