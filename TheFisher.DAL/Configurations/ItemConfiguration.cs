using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheFisher.DAL.Entities;

namespace TheFisher.DAL.Configurations;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.HasKey(i => i.Id);
        
        builder.Property(i => i.Name)
            .IsRequired()
            .HasMaxLength(100);
            
        builder.Property(i => i.InHouseStock)
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue(0)
            .IsRequired();            
        
               
        builder.Property(i => i.AveragePrice)
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue(0)
            .IsRequired();            
        
        builder.HasMany(i => i.Orders)
            .WithOne(o => o.Item)
            .HasForeignKey(o => o.ItemId)
            .OnDelete(DeleteBehavior.Restrict);
            
        builder.HasMany(i => i.Purchases)
            .WithOne(p => p.Item)
            .HasForeignKey(p => p.ItemId)
            .OnDelete(DeleteBehavior.Restrict);
    }
} 