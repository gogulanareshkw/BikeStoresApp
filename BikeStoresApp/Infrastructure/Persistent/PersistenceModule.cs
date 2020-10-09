using Autofac;
using BikeStoresApp.Application.Common.Brokers;
using BikeStoresApp.Application.Common.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoresApp.Infrastructure.Persistent
{
    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var options = c.Resolve<IOptions<DbConnectionSettings>>();
                var dbConnectionSettings = options.Value;
                var dbContextOptionsBuilder = new DbContextOptionsBuilder<DataContext>()
                    .UseSqlServer(dbConnectionSettings.BikeStoreDbContext);

                return new DataContext(dbContextOptionsBuilder.Options);
            }).As<IDataContext>().InstancePerDependency().ExternallyOwned();

            builder.RegisterType<DataContextFactory>().As<IDataContextFactory>()
                .InstancePerLifetimeScope();
        }
    }
}
