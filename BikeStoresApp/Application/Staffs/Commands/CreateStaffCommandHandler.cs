﻿using AutoMapper;
using BikeStoreEntities;
using BikeStoresApp.Application.Common.Brokers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BikeStoresApp.Application.Staffs.Commands
{
    public class CreateStaffCommandHandler : IRequestHandler<CreateStaffCommand, StaffResponseDto>
    {
        private readonly IDataContextFactory _dataContextFactory;
        private readonly IMapper _mapper;
        public CreateStaffCommandHandler(IDataContextFactory dataContextFactory, IMapper mapper)
        {
            _dataContextFactory = dataContextFactory ?? throw new ArgumentNullException(nameof(dataContextFactory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<StaffResponseDto> Handle(CreateStaffCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Staff>(request.StaffRequestDto);
            using var dbcontext = _dataContextFactory.SpawnDbContext();
            dbcontext.Staffs.Add(entity);
            await dbcontext.SaveChangesAsync().ConfigureAwait(false);
            return _mapper.Map<StaffResponseDto>(entity);
        }
    }
}
