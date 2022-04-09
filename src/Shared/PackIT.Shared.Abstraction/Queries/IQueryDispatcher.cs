using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Shared.Abstraction.Queries
{
    public interface IQueryDispatcher
    {
        Task<TResult> QueryDispatcher<TResult>(IQuery<TResult> query);
    }
}
