using AutoMapper;
using BikeStoreEntities;
using BikeStoresApp.Application.Brands;
using BikeStoresApp.Application.Categories;
using BikeStoresApp.Application.Products;
using BikeStoresApp.Application.Staffs;
using BikeStoresApp.Application.Stocks;
using BikeStoresApp.Application.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoresApp.Application.Automapper
{
    public class DtoProfile : Profile
    {
        public DtoProfile()
        {
            CreateMap<Brand, BrandResponseDto>();
            CreateMap<Category, CategoryResponseDto>();
            CreateMap<Product, ProductResponseDto>();
            CreateMap<Store, StoreResponseDto>();
            CreateMap<Stock, StockResponseDto>();
            CreateMap<Staff, StaffResponseDto>();
        }
    }
}
