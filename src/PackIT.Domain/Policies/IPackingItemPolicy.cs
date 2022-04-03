using PackIT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Policies
{
    public interface IPackingItemPolicy
    {
        bool IsApplicable(PolicyData data);
        IEnumerable<PackingItem> GenerateItems(PolicyData data); 
    }
}
