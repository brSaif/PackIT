using PackIT.Domain.Entities;
using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstraction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Events
{
    public record PackedItemRemoved (PackingList PackingList, PackingItem PackingItem) : IDomainEvent;
}
