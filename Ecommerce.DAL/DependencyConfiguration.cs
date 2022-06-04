﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.DAL
{
    public static class DependencyConfiguration
    {
        public static IServiceCollection ConfigureDalDependencies(this IServiceCollection services)
        {
            return services;
        }

        public static void ConfigureDalDbContexts(this IServiceCollection services, string connectionString, bool asNoTracking)
        {
            services.AddDbContextPool<EcomerceDbContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServer(connectionString, options =>
                {
                    options.EnableRetryOnFailure();
                });
                optionsBuilder.UseQueryTrackingBehavior(asNoTracking ? QueryTrackingBehavior.NoTracking : QueryTrackingBehavior.TrackAll);
            });
        }
    }
}
