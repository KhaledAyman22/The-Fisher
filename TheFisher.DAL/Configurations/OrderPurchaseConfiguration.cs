using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheFisher.DAL.Entities;

namespace TheFisher.DAL.Configurations;

public class OrderPurchaseConfiguration : IEntityTypeConfiguration<OrderPurchase>
{
    public void Configure(EntityTypeBuilder<OrderPurchase> builder)
    {
        builder.HasKey(op => new { op.OrderId, op.PurchaseId });
        
        builder.Property(op => op.OrderId)
            .HasColumnType("nvarchar(26)")
            .HasConversion(new UlidToStringConverter());
            
        builder.Property(op => op.PurchaseId)
            .HasColumnType("nvarchar(26)")
            .HasConversion(new UlidToStringConverter());
        
        builder.Property(op => op.WeightUsed)
            .HasColumnType("decimal(18,3)")
            .HasDefaultValue(0m);
            
        builder.HasOne(op => op.Order)
            .WithMany(o => o.OrderPurchases)
            .HasForeignKey(op => op.OrderId)
            .OnDelete(DeleteBehavior.Restrict);
            
        builder.HasOne(op => op.Purchase)
            .WithMany(p => p.OrderPurchases)
            .HasForeignKey(op => op.PurchaseId)
            .OnDelete(DeleteBehavior.Restrict);
    }
} 