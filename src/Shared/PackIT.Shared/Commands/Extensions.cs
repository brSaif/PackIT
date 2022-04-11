using Microsoft.Extensions.DependencyInjection;
using PackIT.Shared.Abstraction.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Shared.Commands
{
    public static class Extensions
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            var assemblies = Assembly.GetCallingAssembly();
            services.AddSingleton<ICommandDispatcher, InMemoryCommandDispatcher>();

            services.Scan(d => d.FromAssemblies(assemblies)
                .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }
    }
}
