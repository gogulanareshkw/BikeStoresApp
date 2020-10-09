using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeStoresApp.Application.Stocks;
using BikeStoresApp.Application.Stocks.Commands;
using BikeStoresApp.Application.Stocks.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeStoresApp.Web.Controllers
{
    [Route("api")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StockController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [Route("stock")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StockResponseDto>), 200)]
        public async Task<IActionResult> GetStock()
        {
            return Ok(await _mediator.Send(new GetStockQuery()));
        }

        [Route("stock")]
        [HttpPost]
        public async Task<IActionResult> AddStock(StockRequestDto stockRequestDto)
        {
            return Ok(await _mediator.Send(new CreateStockCommand
            {
                StockRequestDto = stockRequestDto
            }));
        }

        [Route("stock")]
        [HttpPut]
        public async Task<IActionResult> UpdateStock(StockRequestDto stockRequestDto)
        {
            return Ok(await _mediator.Send(new UpdateStockCommand
            {
                StockRequestDto = stockRequestDto
            }));
        }

    }
}
