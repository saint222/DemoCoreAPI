using DemoCoreAPI.Data.SQLServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCoreAPI.Web.DIServices
{
    public static class ServiceConfiguration
    {
        public static void RegisterServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MainContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
