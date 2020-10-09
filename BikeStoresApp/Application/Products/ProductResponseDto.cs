using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoresApp.Application.Products
{
    public class ProductResponseDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int ModelYear { get; set; }
        public decimal ListPrice { get; set; }

        public string BrandName { get; set; }
        public string CategoryName { get; set; }

    }
}
