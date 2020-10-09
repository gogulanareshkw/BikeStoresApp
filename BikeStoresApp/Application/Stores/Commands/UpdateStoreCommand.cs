using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoresApp.Application.Stores.Commands
{
    public class UpdateStoreCommand : IRequest<StoreResponseDto>
    {
        public StoreRequestDto StoreRequestDto { get; set; }
    }
}
