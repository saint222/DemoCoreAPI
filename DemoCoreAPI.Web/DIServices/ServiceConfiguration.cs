using DemoCoreAPI.BusinessLogic.Handlers;
using DemoCoreAPI.BusinessLogic.Implementation;
using DemoCoreAPI.BusinessLogic.Interfaces;
using DemoCoreAPI.Data;
using DemoCoreAPI.Data.SQLServer;
using DemoCoreAPI.DomainModels.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DemoCoreAPI.Web.DIServices
{
    public static class ServiceConfiguration
    {
        public static void RegisterServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApiContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IRepository<User>, SqlServRepository<User>>();
            services.AddMediatR(typeof(RegisterHandler)); // add handlers as params: one, two, tree...
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAdminService, AdminService>();
        }
    }
}
