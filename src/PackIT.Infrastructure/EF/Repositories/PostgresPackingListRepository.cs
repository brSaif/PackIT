﻿using Microsoft.EntityFrameworkCore;
using PackIT.Domain.Entities;
using PackIT.Domain.Repositories;
using PackIT.Domain.ValueObjects;
using PackIT.Infrastructure.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Infrastructure.EF.Repositories
{
    internal sealed class PostgresPackingListRepository : IPackingListRepository
    {
        private readonly DbSet<PackingList> _packingLists;
        private readonly WriteDbContext _writeContext;

        public PostgresPackingListRepository(WriteDbContext context)
        {
            _writeContext = context;
            _packingLists = context.PackingLists;
        }

        public async Task AddAsync(PackingList packingList)
        {
            await _packingLists.AddAsync(packingList);
            await _writeContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(PackingList packingList)
        {
            _packingLists.Remove(packingList);
            await _writeContext.SaveChangesAsync();
        }

        public async Task<PackingList> GetAsync(PackingListId id)
            => await _packingLists.Include("_items")
                                  .SingleOrDefaultAsync(pl => pl.Id == id);

        public async Task UpdateAsync(PackingList packingList)
        {
            _packingLists.Update(packingList);
            await _writeContext.SaveChangesAsync();
        }
    }
}
