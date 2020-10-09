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
    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<BrandRequestDto, Brand>();
            CreateMap<CategoryRequestDto, Category>();
            CreateMap<ProductRequestDto, Product>();
            CreateMap<StoreRequestDto, Store>();
            CreateMap<StockRequestDto, Stock>();
            CreateMap<StaffRequestDto, Staff>();
        }
    }
}
