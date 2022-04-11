using PackIT.Domain.Const;
using PackIT.Shared.Abstraction.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.Commands
{
    public record CreatePackingListWithItems (Guid Id, string Name, ushort Days, Gender Gender,LocalizationWriteModel Localisation) : ICommand;

    public record LocalizationWriteModel (string City, string Country);
}
