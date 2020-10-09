using BikeStoreEntities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoresApp.Domain.Validators
{
    public class StoreValidator : AbstractValidator<Store>
    {
        public StoreValidator()
        {
            RuleFor(s => s.StoreId).NotEmpty().NotNull();
            RuleFor(s => s.Name).NotEmpty().NotNull();
            RuleFor(s => s.Phone).NotEmpty().NotNull().Length(10);
            RuleFor(s => s.Email).EmailAddress();
            RuleFor(s => s.City).NotEmpty().NotNull();
            RuleFor(s => s.State).NotEmpty().NotNull();
            RuleFor(s => s.ZipCode).NotEmpty().NotNull().Length(6);
        }
    }
}
