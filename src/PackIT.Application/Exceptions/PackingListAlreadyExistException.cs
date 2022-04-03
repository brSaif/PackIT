using PackIT.Shared.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.Exceptions
{
    public class PackingListAlreadyExistException : PackITException
    {
        private string Name { get; }
        public PackingListAlreadyExistException(string name) 
            : base($"Packing list with name '{name}' already exists")
        {
            Name = name;
        }
    }
}
