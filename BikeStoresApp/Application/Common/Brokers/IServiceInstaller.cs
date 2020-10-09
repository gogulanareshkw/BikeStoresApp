using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoresApp.Application.Common.Brokers
{
    public interface IServiceInstaller
    {
        void Install(IServiceCollection services, IConfiguration config, string env);
    }
}
