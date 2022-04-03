using PackIT.Domain.Const;
using PackIT.Shared.Abstraction.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.Commands
{
    public record CreatingPackingListWithItems (Guid Id, string Name, ushort Days, Gender Gender,LocalisationWriteModel Localisation) : ICommand;

    public record LocalisationWriteModel (string City, string Country);
}
