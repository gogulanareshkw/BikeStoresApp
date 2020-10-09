using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoresApp.Application.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<CategoryResponseDto>
    {
        public CategoryRequestDto CategoryRequestDto { get; set; }
    }
}
