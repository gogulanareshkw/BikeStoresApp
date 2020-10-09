using AutoMapper;
using BikeStoresApp.Application.Common.Brokers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BikeStoresApp.Application.Products.Queries
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, IEnumerable<ProductResponseDto>>
    {
        private readonly IDataContextFactory _dataContextFactory;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IDataContextFactory dataContextFactory, IMapper mapper)
        {
            _dataContextFactory = dataContextFactory ?? throw new ArgumentNullException(nameof(dataContextFactory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<IEnumerable<ProductResponseDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            using var dbcontext = _dataContextFactory.SpawnDbContext();
            var products = await dbcontext.Products.Include(c => c.Category).Include(b => b.Brand).ToListAsync();
            return _mapper.Map<IEnumerable<ProductResponseDto>>(products);
        }
    }
}
