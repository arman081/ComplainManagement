using ComplainManagement.API.ViewModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplainManagement.API.Validators
{
    public class LoginValidator : AbstractValidator<LoginVm>
    {
        public LoginValidator()
        {            
            RuleFor(p => p.UserName).NotEmpty().NotNull().WithMessage("User Name can't be empty.");
            RuleFor(p => p.Password).NotEmpty().NotNull().MinimumLength(8).WithMessage("Password can't be empty.");
        }
    }
}
