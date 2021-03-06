﻿using AutoMapper;
using BikeStoreEntities;
using BikeStoresApp.Application.Common.Brokers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BikeStoresApp.Application.Stocks.Commands
{
    public class UpdateStockCommandHandler : IRequestHandler<UpdateStockCommand, StockResponseDto>
    {
        private readonly IDataContextFactory _dataContextFactory;
        private readonly IMapper _mapper;
        public UpdateStockCommandHandler(IDataContextFactory dataContextFactory, IMapper mapper)
        {
            _dataContextFactory = dataContextFactory ?? throw new ArgumentNullException(nameof(dataContextFactory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<StockResponseDto> Handle(UpdateStockCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Stock>(request.StockRequestDto);
            using var dbcontext = _dataContextFactory.SpawnDbContext();
            dbcontext.Stocks.Update(entity);
            await dbcontext.SaveChangesAsync().ConfigureAwait(false);
            return _mapper.Map<StockResponseDto>(entity);
        }
    }
}
