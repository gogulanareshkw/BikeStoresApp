using BikeStoreEntities;
using BikeStoresApp.Application.Stocks;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoresApp.Domain.Validators
{
    public class StockValidator : AbstractValidator<StockRequestDto>
    {
        public StockValidator()
        {
            RuleFor(s => s.StoreId).NotEmpty().NotNull();
            RuleFor(s => s.ProductId).NotEmpty().NotNull();
            RuleFor(s => s.Quantity).NotEmpty().NotNull();
        }
    }
}
