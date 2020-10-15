using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeStoreEntities;
using BikeStoresApp.Application.Categories;
using BikeStoresApp.Application.Categories.Commands;
using BikeStoresApp.Application.Categories.Queries;
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
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [Route("category")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CategoryResponseDto>), 200)]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _mediator.Send(new GetCategoryQuery()));
        }

        [Route("category")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryRequestDto categoryRequestDto)
        {
            return Ok(await _mediator.Send(new CreateCategoryCommand
            {
                CategoryRequestDto = categoryRequestDto
            })) ;
        }

        [Route("category")]
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(CategoryRequestDto categoryRequestDto)
        {
            return Ok(await _mediator.Send(new UpdateCategoryCommand
            {
                CategoryRequestDto = categoryRequestDto
            }));
        }




    }
}
