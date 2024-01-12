using DMS.Core.Models.Inventory;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Validation.Inventory
{
    public class DepotIssueDetailValidator : AbstractValidator<StockIssueDetail>
    {
        public DepotIssueDetailValidator()
        {
            RuleFor(g => g.IssueCode).NotNull().NotEmpty().WithMessage("Issue Code is missing");
            RuleFor(g => g.ProductCode).NotNull().NotEmpty().WithMessage("Product is missing");
            RuleFor(g => g.BatchNo).NotNull().NotEmpty().WithMessage("Product batch is missing");
            RuleFor(g => g.Quantity).NotNull().NotEmpty().GreaterThan(0).WithMessage("Product Quantity must be greater than zero.");
            RuleFor(g => g.MachineId).NotNull().NotEmpty().WithMessage("Machine Credentials not found.");
            RuleFor(g => g.CreatedById).NotNull().NotEmpty().WithMessage("Created By Id not found");
            RuleFor(g => g.CreatedOn).NotNull().NotEmpty().WithMessage("Create date is missing.");
        }
    }
}
