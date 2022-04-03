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
    public class RemovePackingItemHandler : ICommandHandler<RemovePackingItem>
    {
        private readonly IPackingListRepository _repository;

        public RemovePackingItemHandler(IPackingListRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(RemovePackingItem command)
        {
            var (packingListId, name) = command;

            var packingList = await _repository.GetAsync(packingListId);
            if (packingList is null)
                throw new PackingListNotFoundException(packingListId);

            packingList.RemoveItem(name);
            await _repository.UpdateAsync(packingList);
        }
    }
}
