using AxelChats.Infrastructure.Data;
using AxelChats.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AxelChats.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(x =>
                x.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            
            services.AddDbContext<IdentityDbContext>(x =>
                x.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<IdentityDbContext>();

            return services;
        }
    }
}
