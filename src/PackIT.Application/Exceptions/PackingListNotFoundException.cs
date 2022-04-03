using PackIT.Shared.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.Exceptions
{
    public class PackingListNotFoundException : PackITException
    {
        public Guid PackingListId { get; }

        public PackingListNotFoundException(Guid PackingListId) : 
            base($"No PackingList with id '{PackingListId}' was found.")
        {
            this.PackingListId = PackingListId;
        }

    }
}

