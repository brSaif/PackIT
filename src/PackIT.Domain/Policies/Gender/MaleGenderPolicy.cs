using PackIT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Policies.Gender
{
    internal sealed class MaleGenderPolicy : IPackingItemPolicy
    {
        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
            => new List<PackingItem>
            {
                new ("Laptop", 1),
                new ("Drinks", 7),
                new ("Books", (uint) Math.Ceiling(data.TravelDays / 7m))
            };

        public bool IsApplicable(PolicyData data)
            => data.Gender is Const.Gender.Male;

    }
}
