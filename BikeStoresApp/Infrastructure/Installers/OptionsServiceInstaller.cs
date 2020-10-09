using BikeStoresApp.Application.Common.Brokers;
using BikeStoresApp.Application.Common.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoresApp.Infrastructure.Installers
{
    public class OptionsServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration config, string env)
        {
            services.AddOptions();
            services.Configure<DbConnectionSettings>(config.GetSection("DbConnectionSettings"));
        }
    }
}
