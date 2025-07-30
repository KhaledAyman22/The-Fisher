using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheFisher.DAL.Entities;

namespace TheFisher.DAL.Configurations;

public class CollectionDetailConfiguration : IEntityTypeConfiguration<CollectionDetail>
{
    public void Configure(EntityTypeBuilder<CollectionDetail> entity)
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

        entity.HasOne(d => d.Collection)
              .WithMany() // No navigation property back from Collection
              .HasForeignKey(d => d.CollectionId);
        
        entity.HasOne(d => d.Order)
              .WithMany() // No navigation property back from Order
              .HasForeignKey(d => d.OrderId);
    }
} 