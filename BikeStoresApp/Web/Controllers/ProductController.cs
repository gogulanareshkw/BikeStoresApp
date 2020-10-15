using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeStoresApp.Application.Products;
using BikeStoresApp.Application.Products.Commands;
using BikeStoresApp.Application.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeStoresApp.Web.Controllers
{
    [Route("api")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [Route("product")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductResponseDto>), 200)]

        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _mediator.Send(new GetProductQuery()));
        }

        [Route("product")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductRequestDto productRequestDto)
        {
            return Ok(await _mediator.Send(new CreateProductCommand
            {
                ProductRequestDto = productRequestDto
            }));
        }

        [Route("product")]
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductRequestDto productRequestDto)
        {
            return Ok(await _mediator.Send(new UpdateProductCommand
            {
                ProductRequestDto = productRequestDto
            }));
        }


    }
}
