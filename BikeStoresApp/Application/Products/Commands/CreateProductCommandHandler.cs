using AutoMapper;
using BikeStoreEntities;
using BikeStoresApp.Application.Common.Brokers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BikeStoresApp.Application.Products.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductResponseDto>
    {
        private readonly IDataContextFactory _dataContextFactory;
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(IDataContextFactory dataContextFactory, IMapper mapper)
        {
            _dataContextFactory = dataContextFactory ?? throw new ArgumentNullException(nameof(dataContextFactory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<ProductResponseDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Product>(request.ProductRequestDto);
            using var dbcontext = _dataContextFactory.SpawnDbContext();
            dbcontext.Products.Add(entity);
            await dbcontext.SaveChangesAsync().ConfigureAwait(false);
            return _mapper.Map<ProductResponseDto>(entity);
        }
    }
}
