using BikeStoreEntities;
using BikeStoreEntities.Specifications;
using BikeStoresApp.Application.Common.Brokers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoresApp.Infrastructure.Persistent
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Store> Stores { get; set; }

        public Task SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(b => b.Configure());
            modelBuilder.Entity<Product>(p => p.Configure());
            modelBuilder.Entity<Stock>(b => b.Configure());
            modelBuilder.Entity<Category>(c => c.Configure());
            modelBuilder.Entity<Category>(c => c.Configure());
            modelBuilder.Entity<Staff>(b => b.Configure());
            modelBuilder.Entity<Store>(b => b.Configure());
        }

    }
}
