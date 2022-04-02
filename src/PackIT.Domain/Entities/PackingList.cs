using PackIT.Domain.Events;
using PackIT.Domain.Exceptions;
using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstraction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Entities
{
    public class PackingList : AggregateRoot<Guid>
    {
        public PackingListId Id { get; private set; }
        
        private PackingListName _name;
        private Localization _localization;

        private readonly LinkedList<PackingItem> _items;

        private PackingList()
        {
            // required by EF
        }

        internal PackingList(PackingListId id, PackingListName name, Localization localization)
        {
            Id = id;
            _name = name;
            _localization = localization;
        }

        internal PackingList(PackingListId id, PackingListName name, 
            Localization localization, LinkedList<PackingItem> items) : this(id, name, localization )
        {
            _items = items;
        }


        public void AddItem(PackingItem item)
        {
            var alreadyExists = _items.Any(i => i.Name == item.Name);
            if (alreadyExists)
                throw new PackingListItemAlreadyExist(_name, item.Name);

            _items.AddLast(item);
            AddEvent(new PackingItemAdded(this, item));
        }

        public void AddItems(IEnumerable<PackingItem> items)
        {
            foreach (var item in items)
                AddItem(item);
        }

        public void PackItem(string itemName)
        {
            var item = GetItem(itemName);
            var packedItem = item with { IsPacked = true };
        }

        private PackingItem GetItem(string itemName)
        {
            var item = _items.SingleOrDefault(i => i.Name == itemName);

            if (item is null)
                throw new PackingItemNotFoundException(itemName);

            return item;
        }
    }
}
