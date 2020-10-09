using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeStoresApp.Application.Brands;
using BikeStoresApp.Application.Brands.Commands;
using BikeStoresApp.Application.Brands.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeStoresApp.Web.Controllers
{
    [Route("api")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        [Route("brand")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BrandResponseDto>), 200)]
        public async Task<IActionResult> GetBrands()
        {
            return Ok(await _mediator.Send(new GetBrandQuery()));
        }

        [Route("brand")]
        [HttpPost]
        public async Task<IActionResult> CreateBrand(BrandRequestDto createDto)
        {
            return Ok(await _mediator.Send(new CreateBrandCommand
            {
                BrandRequestDto = createDto
            }));
        }

        [Route("brand")]
        [HttpPut]
        public async Task<IActionResult> UpdateBrand(BrandRequestDto createDto)
        {
            return Ok(await _mediator.Send(new UpdateBrandCommand
            {
                BrandRequestDto = createDto
            }));
        }

    }

}
