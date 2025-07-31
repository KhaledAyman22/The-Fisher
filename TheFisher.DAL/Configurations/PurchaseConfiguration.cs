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
        
        builder.Property(p => p.CommissionPercent)
            .HasColumnType("decimal(18,2)");
            
        builder.Property(p => p.TotalWeight)
            .HasColumnType("decimal(18,3)")
            .HasDefaultValue(0m);
            
        builder.Property(p => p.WeightAvailable)
            .HasColumnType("decimal(18,3)")
            .HasDefaultValue(0m);
            
        builder.Property(p => p.Type)
            .HasConversion<string>()
            .HasMaxLength(20)
            .HasDefaultValue(PurchaseType.Direct);
            
        builder.HasOne(p => p.Dealer)
            .WithMany(d => d.Purchases)
            .HasForeignKey(p => p.DealerId)
            .OnDelete(DeleteBehavior.Restrict);
            
        builder.HasOne(p => p.Item)
            .WithMany(i => i.Purchases)
            .HasForeignKey(p => p.ItemId)
            .OnDelete(DeleteBehavior.Restrict);
            
        builder.HasMany(p => p.OrderPurchases)
            .WithOne(op => op.Purchase)
            .HasForeignKey(op => op.PurchaseId)
            .OnDelete(DeleteBehavior.Restrict);
    }
} 