using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoresApp.Application.Stocks.Commands
{
    public class UpdateStockCommand : IRequest<StockResponseDto>
    {
        public StockRequestDto StockRequestDto { get; set; }
    }

}
