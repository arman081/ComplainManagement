using ComplainManagement.API.ViewModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplainManagement.API.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterVm>
    {
        public RegisterValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().NotNull().WithMessage("First Name can't be empty.");
            RuleFor(p => p.LastName).NotEmpty().NotNull().WithMessage("Last Name can't be empty.");
            RuleFor(p => p.UserEmail).NotEmpty().NotNull().WithMessage("Email can't be empty.");
            RuleFor(p => p.UserName).NotEmpty().NotNull().WithMessage("User Name can't be empty.");
            RuleFor(p => p.Password).NotEmpty().NotNull().MinimumLength(8).WithMessage("Password should be at least 8 characters long.");
        }
    }
}
