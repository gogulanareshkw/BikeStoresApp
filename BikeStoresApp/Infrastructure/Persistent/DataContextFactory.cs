﻿using Autofac;
using BikeStoresApp.Application.Common.Brokers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoresApp.Infrastructure.Persistent
{
    public class DataContextFactory : IDataContextFactory
    {
        private readonly IComponentContext _context;

        public DataContextFactory(IComponentContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public IDataContext SpawnDbContext()
        {
            return _context.Resolve<IDataContext>();
        }
    }
}
