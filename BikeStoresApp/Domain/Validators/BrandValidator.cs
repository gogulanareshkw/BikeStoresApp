using BikeStoreEntities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoresApp.Domain.Validators
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(brand => brand.BrandId).NotEmpty();
            RuleFor(brand => brand.Name).NotNull().NotEmpty();
        }
    }
}
