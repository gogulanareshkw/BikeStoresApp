using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoresApp.Application.Products.Queries
{
    public class GetProductQuery: IRequest<IEnumerable<ProductResponseDto>>
    {
    }
}
