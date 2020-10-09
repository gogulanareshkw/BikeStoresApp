using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoresApp.Application.Brands.Commands
{
    public class UpdateBrandCommand : IRequest<BrandResponseDto>
    {
        public BrandRequestDto BrandRequestDto { get; set; }
    }
}
