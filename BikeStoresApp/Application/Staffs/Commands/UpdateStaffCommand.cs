using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoresApp.Application.Staffs.Commands
{
    public class UpdateStaffCommand : IRequest<StaffResponseDto>
    {
        public StaffRequestDto StaffRequestDto { get; set; }
    }
}
