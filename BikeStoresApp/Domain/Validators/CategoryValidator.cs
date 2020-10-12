using BikeStoreEntities;
using BikeStoresApp.Application.Categories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoresApp.Domain.Validators
{
    public class CategoryValidator : AbstractValidator<CategoryRequestDto>
    {
        public CategoryValidator()
        {
            RuleFor(cat => cat.Name).NotNull().NotEmpty();
        }
    }
}
