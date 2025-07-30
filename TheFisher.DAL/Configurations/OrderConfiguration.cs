using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheFisher.DAL.Entities;

namespace TheFisher.DAL.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> entity)
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");
        entity.Property(e => e.Collected).HasColumnType("decimal(18, 2)");
        entity.Ignore(e => e.Total); // Calculated property, not stored in DB

        // Relationship: An Order has one Client, a Client has many Orders
        entity.HasOne(d => d.Client)
              .WithMany(p => p.Orders)
              .HasForeignKey(d => d.ClientId);

        // Relationship: An Order has one Item, an Item has many Orders
        entity.HasOne(d => d.Item)
              .WithMany(p => p.Orders)
              .HasForeignKey(d => d.ItemId);
    }
} 