using AutoMapper;
using BikeStoresApp.Application.Common.Brokers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BikeStoresApp.Application.Categories.Queries
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, IEnumerable<CategoryResponseDto>>
    {
        private readonly IDataContextFactory _dataContextFactory;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(IDataContextFactory dataContextFactory, IMapper mapper)
        {
            _dataContextFactory = dataContextFactory ?? throw new ArgumentNullException(nameof(dataContextFactory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<CategoryResponseDto>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            using var dbcontext = _dataContextFactory.SpawnDbContext();
            var categories = await dbcontext.Categories.ToListAsync();
            return _mapper.Map<IEnumerable<CategoryResponseDto>>(categories);
        }
    }
}
