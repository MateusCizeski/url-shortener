using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUrlService, UrlService>();
            services.AddScoped<IRandomPathGenerator, RandomPathGenerator>();
            services.AddScoped<ICleanUpService<Url>, UrlCleanUpService>();

            return services;
        }
    }
}
