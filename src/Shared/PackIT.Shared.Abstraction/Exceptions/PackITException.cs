using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Shared.Abstraction.Exceptions
{
    public abstract class PackITException : Exception
    {
        protected PackITException(string exception) : base(exception) { }
    }
}
