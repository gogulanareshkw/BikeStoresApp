using BikeStoreEntities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoresApp.Domain.Validators
{
    public class StaffValidator : AbstractValidator<Staff>
    {
        public StaffValidator()
        {
            RuleFor(s => s.StaffId).NotEmpty().NotNull();
            RuleFor(s => s.FirstName).NotEmpty().NotNull();
            RuleFor(s => s.Phone).NotEmpty().NotNull().Length(10);
            RuleFor(s => s.Email).EmailAddress();
            RuleFor(s => s.Active).NotNull();
            RuleFor(s => s.StoreId).NotEmpty().NotNull();
        }
    }
}
