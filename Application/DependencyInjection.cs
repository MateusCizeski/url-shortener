using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection service)
        {
            service.AddScoped<IUrlService, UrlService>();
            service.AddScoped<IRandomPathGenerator, RandomPathGenerator>();
            service.AddScoped<ICleanUpService<Url>, ICleanUpService>();

            return service;
        }
    }
}
