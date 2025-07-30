using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheFisher.DAL.Entities;

namespace TheFisher.DAL.Configurations;

public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
{
    public void Configure(EntityTypeBuilder<Purchase> entity)
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

        entity.HasOne(d => d.Provider)
              .WithMany(p => p.Purchases)
              .HasForeignKey(d => d.ProviderId);

        entity.HasOne(d => d.Item)
              .WithMany(p => p.Purchases)
              .HasForeignKey(d => d.ItemId);
    }
} 