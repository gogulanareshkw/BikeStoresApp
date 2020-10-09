using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoresApp.Application.Staffs.Queries
{
    public class GetStaffQuery : IRequest<IEnumerable<StaffResponseDto>>
    {
    }
}
