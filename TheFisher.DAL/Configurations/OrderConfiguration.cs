using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheFisher.DAL.Entities;

namespace TheFisher.DAL.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);
        
        builder.Property(o => o.Id)
            .HasColumnType("nvarchar(26)")
            .HasConversion(new UlidToStringConverter());
        
        builder.Property(o => o.Weight)
            .HasColumnType("decimal(18,3)")
            .HasDefaultValue(0m);
            
        builder.Property(o => o.KiloPrice)
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue(0m);
            
        builder.Property(o => o.Total)
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue(0m);
            
        builder.Property(o => o.Collected)
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue(0m);
            
        builder.HasOne(o => o.Client)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.ClientId)
            .OnDelete(DeleteBehavior.Restrict);
            
        builder.HasOne(o => o.Item)
            .WithMany(i => i.Orders)
            .HasForeignKey(o => o.ItemId)
            .OnDelete(DeleteBehavior.Restrict);
            
        builder.HasMany(o => o.CollectionDetails)
            .WithOne(cd => cd.Order)
            .HasForeignKey(cd => cd.OrderId)
            .OnDelete(DeleteBehavior.Restrict);
            
        builder.HasMany(o => o.OrderPurchases)
            .WithOne(op => op.Order)
            .HasForeignKey(op => op.OrderId)
            .OnDelete(DeleteBehavior.Restrict);
    }
} 