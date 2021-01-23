using System.Text;
using AxelChats.Infrastructure.Auth;
using AxelChats.Infrastructure.Data;
using AxelChats.Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace AxelChats.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IHostEnvironment env)
        {
            var jwtOptions = configuration.GetSection("Auth").Get<JwtOptions>();

            services.Configure<JwtOptions>(configuration.GetSection("Auth"));

            services.AddDbContext<ApplicationDbContext>(builder =>
                builder.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<User>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = env.IsProduction(),
                        ValidateIssuer = env.IsProduction(),
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = jwtOptions.SymmetricSecurityKey
                    };
                });

            services.AddSingleton<IJwtFactory, JwtFactory>();

            return services;
        }
    }
}
