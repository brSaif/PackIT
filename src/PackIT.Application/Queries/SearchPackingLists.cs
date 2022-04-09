using PackIT.Application.DTO;
using PackIT.Domain.Entities;
using PackIT.Shared.Abstraction.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.Queries
{
    public class SearchPackingLists : IQuery<IEnumerable<PackingListDto>>
    {
        public string SearchPhrase { get; set; }
    }
}
