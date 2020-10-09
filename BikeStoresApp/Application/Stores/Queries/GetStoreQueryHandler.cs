using AutoMapper;
using BikeStoresApp.Application.Common.Brokers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BikeStoresApp.Application.Stores.Queries
{
    public class GetStoreQueryHandler : IRequestHandler<GetStoreQuery, IEnumerable<StoreResponseDto>>
    {
        private readonly IDataContextFactory _dataContextFactory;
        private readonly IMapper _mapper;
        public GetStoreQueryHandler(IDataContextFactory dataContextFactory, IMapper mapper)
        {
            _dataContextFactory = dataContextFactory ?? throw new ArgumentNullException(nameof(dataContextFactory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<IEnumerable<StoreResponseDto>> Handle(GetStoreQuery request, CancellationToken cancellationToken)
        {
            using var dbcontext = _dataContextFactory.SpawnDbContext();
            var storeList = await dbcontext.Stores.ToListAsync();
            return _mapper.Map<IEnumerable<StoreResponseDto>>(storeList);

        }
    }
}
