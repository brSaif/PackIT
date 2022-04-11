using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PackIT.Shared.Exceptions;
using PackIT.Shared.Services;

namespace PackIT.Shared
{
    public static class Extensions
    {
        public static IServiceCollection AddShared(this IServiceCollection _services)
        {
            _services.AddHostedService<AppInitializer>();
            _services.AddScoped<ExceptionMiddleware>();
            return _services;
        }

        public static IApplicationBuilder UseShared(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            return app;
        }
    }
}
