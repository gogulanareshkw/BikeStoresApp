using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeStoresApp.Application.Stores;
using BikeStoresApp.Application.Stores.Commands;
using BikeStoresApp.Application.Stores.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeStoresApp.Web.Controllers
{
    [Route("api")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StoreController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [Route("store")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StoreResponseDto>), 200)]
        public async Task<IActionResult> GetStores()
        {
            return Ok(await _mediator.Send(new GetStoreQuery()));
        }

        [Route("store")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct(StoreRequestDto storeRequestDto)
        {
            return Ok(await _mediator.Send(new CreateStoreCommand
            {
                StoreRequestDto = storeRequestDto
            }));
        }

        [Route("store")]
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(StoreRequestDto storeRequestDto)
        {
            return Ok(await _mediator.Send(new UpdateStoreCommand
            {
                StoreRequestDto = storeRequestDto
            }));
        }



    }
}
