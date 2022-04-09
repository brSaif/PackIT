using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackIT.Application.Services;
using PackIT.Infrastructure.EF;
using PackIT.Infrastructure.Logging;
using PackIT.Infrastructure.Services;
using PackIT.Shared.Abstraction.Commands;
using PackIT.Shared.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                                                           IConfiguration config)
        {
            services.AddPostgres(config);
            services.AddQueries();
            services.AddSingleton<IWeatherService, DumbWeatherService>();

            services.TryDecorate(typeof(ICommandHandler<>), typeof(LoggingCommandHandlerDecorator<>));

            return services;
        }
    }
}
