using AutoMapper;
using BikeStoresApp.Application.Automapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoresApp.Infrastructure.Automapper
{
    public static class AutoMapperExports
    {
        public static void ConfigureProfiles(this IMapperConfigurationExpression cfg)
        {
            cfg.AddProfile<DtoProfile>();
            cfg.AddProfile<EntityProfile>();
        }
    }
}
