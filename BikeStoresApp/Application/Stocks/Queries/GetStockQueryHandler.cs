using AutoMapper;
using BikeStoresApp.Application.Common.Brokers;
using BikeStoresApp.Application.Products.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BikeStoresApp.Application.Stocks.Queries
{
    public class GetStockQueryHandler : IRequestHandler<GetStockQuery, IEnumerable<StockResponseDto>>
    {
        private readonly IDataContextFactory _dataContextFactory;
        private readonly IMapper _mapper;

        public GetStockQueryHandler(IDataContextFactory dataContextFactory, IMapper mapper)
        {
            _dataContextFactory = dataContextFactory ?? throw new ArgumentNullException(nameof(dataContextFactory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<StockResponseDto>> Handle(GetStockQuery request, CancellationToken cancellationToken)
        {
            using var dbcontext = _dataContextFactory.SpawnDbContext();
            var stock = await dbcontext.Stocks.ToListAsync();
            return _mapper.Map<IEnumerable<StockResponseDto>>(stock);
        }
    }
}
