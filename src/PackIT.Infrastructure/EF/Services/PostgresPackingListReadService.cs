using Microsoft.EntityFrameworkCore;
using PackIT.Application.Services;
using PackIT.Infrastructure.EF.Contexts;
using PackIT.Infrastructure.EF.Models;

namespace PackIT.Infrastructure.EF.Services
{
    internal sealed class PostgresPackingListReadService : IPackingListReadService
    {
        private readonly DbSet<PackingListReadModel> _packingLists;

        public PostgresPackingListReadService(ReadDbContext readContext)
           => _packingLists = readContext.packingLists;

        public async Task<bool> ExistsByNameAsync(string name)
            => await _packingLists.AllAsync(pl => pl.Name == name);
    }
}
