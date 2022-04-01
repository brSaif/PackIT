using PackIT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Entities
{
    public class PackingList
    {
        public Guid Id { get; private set; }
        private PackingListName _name;
        private Localization _localization;

        internal PackingList(Guid id, PackingListName name, Localization localization)
        {
            Id = id;
            _name = name;
            _localization = localization;
        }
    }
}
