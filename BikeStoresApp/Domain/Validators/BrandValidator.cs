using BikeStoreEntities;
using BikeStoresApp.Application.Brands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoresApp.Domain.Validators
{
    public class BrandValidator : AbstractValidator<BrandRequestDto>
    {
        public BrandValidator()
        {
            RuleFor(brand => brand.Name).NotNull().NotEmpty();
        }
    }
}
