using AutoMapper;
using BikeStoreEntities;
using BikeStoresApp.Application.Common.Brokers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BikeStoresApp.Application.Stores.Commands
{
    public class CreateStoreCommandHandler : IRequestHandler<CreateStoreCommand, StoreResponseDto>
    {
        private readonly IDataContextFactory _dataContextFactory;
        private readonly IMapper _mapper;
        public CreateStoreCommandHandler(IDataContextFactory dataContextFactory, IMapper mapper)
        {
            _dataContextFactory = dataContextFactory ?? throw new ArgumentNullException(nameof(dataContextFactory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<StoreResponseDto> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Store>(request.StoreRequestDto);
            using var dbcontext = _dataContextFactory.SpawnDbContext();
            dbcontext.Stores.Add(entity);
            await dbcontext.SaveChangesAsync().ConfigureAwait(false);
            return _mapper.Map<StoreResponseDto>(entity);
        }
    }
}
