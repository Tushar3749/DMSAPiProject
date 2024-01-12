using DMS.Core.Models.Inventory;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Validation.Inventory
{
    public class DepotIssueValidator : AbstractValidator<StockIssue>
    {
        public DepotIssueValidator()
        {
            RuleFor(g => g.IssueDate).NotNull().NotEmpty().NotEmpty().WithMessage("Issue Date is missing");
            RuleFor(g => g.IssueType).NotNull().NotEmpty().NotEmpty().WithMessage("Issue Type is missing");
            RuleFor(g => g.FromWarehouse).NotNull().NotEmpty().NotEmpty().WithMessage("From Warehouse is missing");
            RuleFor(g => g.ToWarehouse).NotNull().NotEmpty().NotEmpty().WithMessage("To Warehouse not found");
            RuleFor(g => g.DepotCode).NotNull().NotEmpty().NotEmpty().WithMessage("Depot not found");
            RuleFor(g => g.MachineId).NotNull().NotEmpty().NotEmpty().WithMessage("Machine Credentials not found.");
            RuleFor(g => g.CreatedById).NotNull().NotEmpty().NotEmpty().WithMessage("Created By Id not found");
            RuleFor(g => g.CreatedOn).NotNull().NotEmpty().NotEmpty().WithMessage("Create date is missing.");
        }
    }
}
