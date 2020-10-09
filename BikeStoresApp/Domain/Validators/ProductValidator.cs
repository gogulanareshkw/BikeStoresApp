using BikeStoreEntities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoresApp.Domain.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.ProductId).NotEmpty();
            RuleFor(product => product.Name).NotNull().NotEmpty();
            RuleFor(product => product.ModelYear).NotEmpty().NotNull();
            RuleFor(product => product.ListPrice).NotEmpty().NotNull().ScalePrecision(2,4);
            RuleFor(product => product.BrandId).NotEmpty().NotNull();
            RuleFor(product => product.ProductId).NotEmpty().NotNull();
            
        }
    }
}
