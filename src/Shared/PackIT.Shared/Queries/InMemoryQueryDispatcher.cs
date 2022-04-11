using Microsoft.Extensions.DependencyInjection;
using PackIT.Shared.Abstraction.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Shared.Queries
{
    internal sealed class InMemoryQueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _service;

        public InMemoryQueryDispatcher(IServiceProvider service)
            => _service = service;

        public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
        {
            using var scope = _service.CreateScope();
            var handleType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
            var handler = scope.ServiceProvider.GetRequiredService(handleType);

            return await (Task<TResult>) handleType.GetMethod(nameof(IQueryHandler<IQuery<TResult>, TResult>.HandleAsync))?.Invoke(handler, new[] { query });
        }
    }
}
