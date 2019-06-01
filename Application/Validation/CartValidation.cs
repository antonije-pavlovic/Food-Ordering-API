using Application.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Validation
{
    public class CartValidation: AbstractValidator<CartDTO>
    {
         public CartValidation()
         {
            RuleFor(x => x.Quantity).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x => x.DishId).NotEmpty().NotNull().GreaterThan(0);            
         }
    }
}
