using DemoCoreAPI.BusinessLogic.Implementation;
using DemoCoreAPI.BusinessLogic.Interfaces;
using DemoCoreAPI.Data;
using DemoCoreAPI.Data.SQLServer;
using DemoCoreAPI.DomainModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
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
            services.AddDbContext<APIContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IRepository<UserDb>, SqlServRepository<UserDb>>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
