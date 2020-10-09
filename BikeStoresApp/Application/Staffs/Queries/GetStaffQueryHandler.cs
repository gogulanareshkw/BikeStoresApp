using AutoMapper;
using BikeStoresApp.Application.Common.Brokers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BikeStoresApp.Application.Staffs.Queries
{
    public class GetStaffQueryHandler : IRequestHandler<GetStaffQuery, IEnumerable<StaffResponseDto>>
    {
        private readonly IDataContextFactory _dataContextFactory;
        private readonly IMapper _mapper;

        public GetStaffQueryHandler(IDataContextFactory dataContextFactory, IMapper mapper)
        {
            _dataContextFactory = dataContextFactory ?? throw new ArgumentNullException(nameof(dataContextFactory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<StaffResponseDto>> Handle(GetStaffQuery request, CancellationToken cancellationToken)
        {
            using var dbcontext = _dataContextFactory.SpawnDbContext();
            var staffList = await dbcontext.Staffs.ToListAsync();
            return _mapper.Map<IEnumerable<StaffResponseDto>>(staffList);
        }
    }
}
