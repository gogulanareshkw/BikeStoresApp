using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoresApp.Application.Products
{
    public class ProductRequestDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int ModelYear { get; set; }
        public decimal ListPrice { get; set; }

        public int BrandId { get; set; }
        public int CategoryId { get; set; }


    }
}
