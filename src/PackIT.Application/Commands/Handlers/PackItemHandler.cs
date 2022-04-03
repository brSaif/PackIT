using PackIT.Application.Exceptions;
using PackIT.Domain.Repositories;
using PackIT.Shared.Abstraction.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.Commands.Handlers
{
    internal sealed class PackItemHandler : ICommandHandler<PackItem>
    {
        private readonly IPackingListRepository _repository;

        public async Task HandleAsync(PackItem command)
        {
            var (packingListId, name) = command;

            var packingList = await _repository.GetAsync(packingListId);

            if (packingList is null)
                throw new PackingListNotFoundException(packingListId);

            packingList.PackItem(name);

            await _repository.UpdateAsync(packingList);
        }
    }
}
