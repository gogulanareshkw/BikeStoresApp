using BikeStoreEntities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoresApp.Domain.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(cat => cat.CategoryId).NotEmpty();
            RuleFor(cat => cat.Name).NotNull().NotEmpty();
        }
    }
}
