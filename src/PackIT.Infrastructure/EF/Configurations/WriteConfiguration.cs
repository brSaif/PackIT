using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PackIT.Domain.Entities;
using PackIT.Domain.ValueObjects;
using PackIT.Infrastructure.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Infrastructure.EF.Configurations
{
    internal sealed class WriteConfiguration : IEntityTypeConfiguration<PackingItem>, IEntityTypeConfiguration<PackingList>
    {
        public void Configure(EntityTypeBuilder<PackingItem> builder)
        {
            builder.Property<Guid>("Id");
            builder.Property(p => p.Name);
            builder.Property(p => p.Quantity);
            builder.Property(p => p.IsPacked);
            builder.ToTable("PackingItems");
        }

        public void Configure(EntityTypeBuilder<PackingList> builder)
        {
            var localizationConverter = new ValueConverter<Localization, string>(l => l.ToString(),
                l => Localization.Create(l));

            var PackingListNameConverter = new ValueConverter<PackingListName, string>(pln => pln.Value,
                pln => new PackingListName(pln));

            builder.Property(pl => pl.Id)
                .HasConversion(pl => pl.Value, pl => new PackingListId(pl));

            builder.Property(typeof(Localization), "_localization")
                .HasConversion(localizationConverter)
                .HasColumnName("Localization");

            builder.Property(typeof(PackingListName), "_name")
                .HasConversion(PackingListNameConverter)
                .HasColumnName("Name");

            builder.HasMany(typeof(PackingItem), "_items");

            builder.ToTable("PackingLists");
        }
    }
}
