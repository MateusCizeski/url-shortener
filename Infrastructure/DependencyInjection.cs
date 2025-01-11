using Domain.Interfaces;
using Infrastructure.Common.Interfaces;
using Infrastructure.Common;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("SqliteConnectionString")!;

            services.AddDbContext<ApplicationDbContext>(opts =>
            {
                opts.UseSqlite(connectionString,
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

            services.AddScoped<IUrlRepository, UrlRepository>();
            services.AddTransient<ISystemTime, Clock>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddHostedService<CleanupService>();

            return services;
        }
    }
}
