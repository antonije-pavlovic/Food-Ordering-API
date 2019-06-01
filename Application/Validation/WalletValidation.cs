using Application.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Validation
{
    public class WalletValidation: AbstractValidator<WalletDTO>
    {

        public WalletValidation()
        {
            RuleFor(x => x.Balance).NotEmpty().NotNull().GreaterThan(500).LessThan(5000);            
        }
    }
}
