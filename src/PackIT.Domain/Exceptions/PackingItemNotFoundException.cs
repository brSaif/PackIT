using PackIT.Shared.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Exceptions
{
    public class PackingItemNotFoundException : PackITException
    {

        public string ItemName { get; }

        public PackingItemNotFoundException(string itemName) : base("Packing item 'itemName' not found")
        {
            ItemName = itemName;
        }
    }
}
