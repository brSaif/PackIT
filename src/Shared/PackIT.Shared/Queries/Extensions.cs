using Microsoft.Extensions.DependencyInjection;
using PackIT.Shared.Abstraction.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Shared.Queries
{
    public static class Extensions
    {
        public static IServiceCollection AddQueries(this IServiceCollection _service)
        {
            _service.AddSingleton<IQueryDispatcher, InMemoryQueryDispatcher>();

            var assembly = Assembly.GetCallingAssembly();
            _service.Scan(s => s.FromAssemblies(assembly)
                .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return _service;
        }
    }
}
