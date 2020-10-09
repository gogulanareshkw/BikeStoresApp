using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoresApp.Application.Stocks.Commands
{
    public class CreateStockCommand : IRequest<StockResponseDto>
    {
        public StockRequestDto StockRequestDto { get; set; }
    }
}
