
/*
 *=============================================
 *Author: Shamsul Hasan Siam
 *Email: siam.it@labaidpharma.com
 *Created on: 7 june 2020
 *Updated on: 
 *Last updated on:
 *Description: <>
 *=============================================
*/


using DMS.Core.DTO.Orders;
using DMS.Core.Models.SalesInvoice;
using FluentValidation;

namespace DMS.Services.Validation
{


    public class OrdersValidator : AbstractValidator<Order>
	{
		public OrdersValidator()
		{
			RuleFor(e => e.OrderCode).NotNull().NotEmpty().WithMessage("OrderCode is missing");
			RuleFor(e => e.TerritoryCode).NotNull().NotEmpty().WithMessage("TerritoryCode is missing");
			RuleFor(e => e.ChemistCode).NotNull().NotEmpty().WithMessage("ChemistCode is missing");
			RuleFor(e => e.DepotCode).NotNull().NotEmpty().WithMessage("DepotCode is missing");
			RuleFor(e => e.DeliveryDate).NotNull().NotEmpty().WithMessage("DeliveryDate is missing");
			RuleFor(e => e.DeliveryTime).NotNull().NotEmpty().WithMessage("DeliveryTime is missing");
			RuleFor(e => e.PaymentMode).NotNull().NotEmpty().WithMessage("PaymentMode is missing");
			RuleFor(e => e.OrderMedia).NotNull().NotEmpty().WithMessage("OrderMedia is missing");
			RuleFor(e => e.MachineId).NotNull().NotEmpty().WithMessage("MachineID is missing");
			RuleFor(e => e.CreatedById).NotNull().NotEmpty().WithMessage("CreatedByID is missing");
		}
	}

}
