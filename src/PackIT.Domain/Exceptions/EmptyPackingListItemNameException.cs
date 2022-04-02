using PackIT.Shared.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Exceptions
{
    public class EmptyPackingListItemNameException : PackITException
    {
        public EmptyPackingListItemNameException() : base("Packing List item cannot be empty")
        {
        }
    }
}
