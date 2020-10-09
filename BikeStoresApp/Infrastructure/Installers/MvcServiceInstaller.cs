using BikeStoresApp.Application.Common.Brokers;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoresApp.Infrastructure.Installers
{
    public class MvcServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration config, string env)
        {
            services.AddControllers()
                .AddFluentValidation(cfg =>
                {
                    cfg.RegisterValidatorsFromAssemblyContaining<Startup>();
                });
        }
    }
}
