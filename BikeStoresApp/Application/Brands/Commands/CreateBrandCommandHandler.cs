using AutoMapper;
using BikeStoreEntities;
using BikeStoresApp.Application.Common.Brokers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BikeStoresApp.Application.Brands.Commands
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, BrandResponseDto>
    {
        private readonly IDataContextFactory _dataContextFactory;
        private readonly IMapper _mapper;
        public CreateBrandCommandHandler(IDataContextFactory dataContextFactory, IMapper mapper)
        {
            _dataContextFactory = dataContextFactory ?? throw new ArgumentNullException(nameof(dataContextFactory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public async Task<BrandResponseDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Brand>(request.BrandRequestDto);
            using var dbContext = _dataContextFactory.SpawnDbContext();
            dbContext.Brands.Add(entity);
            await dbContext.SaveChangesAsync().ConfigureAwait(false);
            return _mapper.Map<BrandResponseDto>(entity);
        }


    }
}
