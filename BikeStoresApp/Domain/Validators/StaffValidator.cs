using BikeStoreEntities;
using BikeStoresApp.Application.Staffs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoresApp.Domain.Validators
{
    public class StaffValidator : AbstractValidator<StaffRequestDto>
    {
        public StaffValidator()
        {
            RuleFor(s => s.FirstName).NotEmpty().NotNull();
            RuleFor(s => s.LastName).NotEmpty().NotNull();
            RuleFor(s => s.Phone).NotEmpty().NotNull().Length(10);
            RuleFor(s => s.Email).EmailAddress();
            RuleFor(s => s.Active).NotNull();
            RuleFor(s => s.StoreId).NotEmpty().NotNull();
        }
    }
}
