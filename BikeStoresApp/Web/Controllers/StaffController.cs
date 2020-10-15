using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeStoreEntities;
using BikeStoresApp.Application.Staffs;
using BikeStoresApp.Application.Staffs.Commands;
using BikeStoresApp.Application.Staffs.Queries;
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
    public class StaffController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StaffController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [Route("staff")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StaffResponseDto>), 200)]

        public async Task<IActionResult> GetStaffs()
        {
            return Ok(await _mediator.Send(new GetStaffQuery()));
        }

        [Route("staff")]
        [HttpPost]
        public async Task<IActionResult> CreateStaff(StaffRequestDto staffRequestDto)
        {
            return Ok(await _mediator.Send(new CreateStaffCommand
            {
                StaffRequestDto = staffRequestDto
            }));
        }

        [Route("staff")]
        [HttpPut]
        public async Task<IActionResult> UpdateStaff(StaffRequestDto staffRequestDto)
        {
            return Ok(await _mediator.Send(new UpdateStaffCommand
            {
                StaffRequestDto = staffRequestDto
            }));
        }


    }
}
