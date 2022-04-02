using PackIT.Domain.Entities;
using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstraction.Domain;

namespace PackIT.Domain.Events
{
    public record PackedItemPacked (PackingList PackingList, PackingItem PackingItem) : IDomainEvent;
}
