using BikeStoreEntities;
using BikeStoresApp.Application.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoresApp.Domain.Validators
{
    public class ProductValidator : AbstractValidator<ProductRequestDto>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Name).NotNull().NotEmpty();
            RuleFor(product => product.ModelYear).NotEmpty().NotNull();
            RuleFor(product => product.ListPrice).NotEmpty().NotNull().ScalePrecision(2,8);
            RuleFor(product => product.BrandId).NotEmpty().NotNull();
            RuleFor(product => product.CategoryId).NotEmpty().NotNull();
        }
    }
}
