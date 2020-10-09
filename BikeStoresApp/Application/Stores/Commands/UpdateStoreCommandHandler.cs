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
    public class UpdateStoreCommandHandler : IRequestHandler<UpdateStoreCommand, StoreResponseDto>
    {
        private readonly IDataContextFactory _dataContextFactory;
        private readonly IMapper _mapper;
        public UpdateStoreCommandHandler(IDataContextFactory dataContextFactory, IMapper mapper)
        {
            _dataContextFactory = dataContextFactory ?? throw new ArgumentNullException(nameof(dataContextFactory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<StoreResponseDto> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Store>(request.StoreRequestDto);
            using var dbcontext = _dataContextFactory.SpawnDbContext();
            dbcontext.Stores.Update(entity);
            await dbcontext.SaveChangesAsync().ConfigureAwait(false);
            return _mapper.Map<StoreResponseDto>(entity);
        }
    }
}
