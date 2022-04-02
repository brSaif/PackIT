using PackIT.Shared.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Exceptions
{
    public class PackingListItemAlreadyExist : PackITException
    {
        public string ListName { get; }
        public string ItemName { get; }

        public PackingListItemAlreadyExist(string listName, string itemName) 
            : base($"Packing List: '{listName}' already defined item '{itemName}'")
        {
            ListName = listName;
            ItemName = itemName;
        }
    }
}
