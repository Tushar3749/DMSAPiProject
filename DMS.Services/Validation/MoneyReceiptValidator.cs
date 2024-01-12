using DMS.Core.Models.Accounts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Validation
{
    public class MoneyReceiptValidator : AbstractValidator<MoneyReceipt>
    {
        public MoneyReceiptValidator()
        { 
            RuleFor(g => g.MoneyReceiptCode).NotNull().NotEmpty().WithMessage("Money Receipt Code not found.");
            RuleFor(g => g.MoneyReceiptDate).NotNull().NotEmpty().WithMessage("Money Receipt date not found."); 
            RuleFor(g => g.SummaryCollectionCode).NotNull().NotEmpty().WithMessage("Collection code not found.");
            RuleFor(g => g.Amount).NotNull().NotEmpty().GreaterThan(0).WithMessage("Amount must be greater than 0.");
            RuleFor(g => g.CollectedFromCode).NotNull().NotEmpty().WithMessage("Amount must be greater than 0.");
            RuleFor(g => g.CreatedById).NotNull().NotEmpty().WithMessage("User not found.");
            RuleFor(g => g.CreatedOn).NotNull().NotEmpty().WithMessage("Create date not found.");
        }
    }
}
