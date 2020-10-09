using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoresApp.Application.Brands.Queries
{
    public class GetBrandQuery : IRequest<IEnumerable<BrandResponseDto>>
    {
    }
}
