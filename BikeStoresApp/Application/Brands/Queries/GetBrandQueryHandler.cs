using AutoMapper;
using BikeStoresApp.Application.Common.Brokers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BikeStoresApp.Application.Brands.Queries
{
    public class GetBrandQueryHandler : IRequestHandler<GetBrandQuery, IEnumerable<BrandResponseDto>>
    {
        private readonly IDataContextFactory _dataContextFactory;
        private readonly IMapper _mapper;

        public GetBrandQueryHandler(IDataContextFactory dataContextFactory, IMapper mapper)
        {
            _dataContextFactory = dataContextFactory ?? throw new ArgumentNullException(nameof(dataContextFactory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<BrandResponseDto>> Handle(GetBrandQuery request, CancellationToken cancellationToken)
        {
            using var dbContext = _dataContextFactory.SpawnDbContext();
            var brands = await dbContext.Brands.ToListAsync(cancellationToken);
            return _mapper.Map<IEnumerable<BrandResponseDto>>(brands);
        }

    }
}
