using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoresApp.Application.Products.Commands
{
    public class CreateProductCommand : IRequest<ProductResponseDto>
    {
        public ProductRequestDto ProductRequestDto { get; set; }
    }
}
