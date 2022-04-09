using Microsoft.EntityFrameworkCore;
using PackIT.Infrastructure.EF.Configurations;
using PackIT.Infrastructure.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Infrastructure.EF.Contexts
{
    internal sealed class ReadDbContext : DbContext
    {
        public DbSet<PackingListReadModel> packingLists { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Packing");

            var config = new ReadConfigurations();
            modelBuilder.ApplyConfiguration<PackingItemReadModel>(config);
            modelBuilder.ApplyConfiguration<PackingListReadModel>(config);

        }
    }
}
