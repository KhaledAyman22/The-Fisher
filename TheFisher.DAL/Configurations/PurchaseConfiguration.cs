using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheFisher.DAL.Entities;
using TheFisher.DAL.enums;

namespace TheFisher.DAL.Configurations;

public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
{
    public void Configure(EntityTypeBuilder<Purchase> builder)
    {
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
            .HasColumnType("nvarchar(26)")
            .HasConversion(new UlidToStringConverter());
        
        builder.Property(p => p.UnitPrice)
            .HasColumnType("decimal(18,2)");
        
        builder.Property(p => p.TransportationFees)
            .HasColumnType("decimal(18,2)");
        
        builder.Property(p => p.Tax)
            .HasColumnType("decimal(18,2)");
            
        builder.Property(p => p.Units)
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue(0m)
            .IsRequired();
            
        builder.HasOne(p => p.Dealer)
            .WithMany(d => d.Purchases)
            .HasForeignKey(p => p.DealerId)
            .OnDelete(DeleteBehavior.Restrict);
            
        builder.HasOne(p => p.Item)
            .WithMany(i => i.Purchases)
            .HasForeignKey(p => p.ItemId)
            .OnDelete(DeleteBehavior.Restrict);
    }
} 