using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoresApp.Application.Stocks.Queries
{
    public class GetStockQuery : IRequest<IEnumerable<StockResponseDto>>
    {
    }
}
