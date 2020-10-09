using BikeStoreEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoresApp.Application.Common.Brokers
{
    public interface IDataContext : IDisposable
    {
        DbSet<Product> Products { get; set; }
        DbSet<Brand> Brands { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Stock> Stocks { get; set; }
        DbSet<Staff> Staffs { get; set; }
        DbSet<Store> Stores { get; set; }

        DatabaseFacade Database { get; }

        Task SaveChangesAsync();
    }
}
