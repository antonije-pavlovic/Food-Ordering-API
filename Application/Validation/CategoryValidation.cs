using Application.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Validation
{
    class CategoryValidation : AbstractValidator<CategoryDTO>
    {
        public CategoryValidation()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
        }
    }
}
