using DMS.Core.Models.Inventory;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Validation.Inventory
{
    public class DepotReceiveValidator : AbstractValidator<StockReceive>
    {
        public DepotReceiveValidator()
        {
            RuleFor(g => g.ReceiveCode).NotNull().WithMessage("Receive Code is missing");
            RuleFor(g => g.ReceiveDate).NotNull().WithMessage("Receive Date is missing");
            RuleFor(g => g.FromWarehouse).NotNull().WithMessage("From Warehouse is missing");
            RuleFor(g => g.ToWarehouse).NotNull().WithMessage("To Warehouse not found");
            RuleFor(g => g.DepotCode).NotNull().WithMessage("Depot not found");
            RuleFor(g => g.MachineId).NotNull().WithMessage("Machine Credentials not found.");
            RuleFor(g => g.CreatedById).NotNull().WithMessage("Created By Id not found");
            RuleFor(g => g.CreatedOn).NotNull().WithMessage("Create date is missing.");
        }
    }
}
