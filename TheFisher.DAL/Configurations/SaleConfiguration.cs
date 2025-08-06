using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheFisher.DAL.Entities;

namespace TheFisher.DAL.Configurations;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.HasKey(o => o.Id);
        
        builder.Property(o => o.Id)
            .HasColumnType("nvarchar(26)")
            .HasConversion(new UlidToStringConverter());
        
        builder.Property(o => o.Units)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
        
        builder.Property(o => o.Total)
            .HasComputedColumnSql($"[{nameof(Sale.UnitPrice)}] * [{nameof(Sale.Units)}] + [{nameof(Sale.Tax)}]", stored: false);
            
        builder.Property(o => o.UnitPrice)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
        
        builder.Property(o => o.Tax)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
            
        builder.Property(o => o.Collected)
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue(0m);
        
        builder.Property(o => o.Profit)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

            
        builder.HasOne(o => o.Client)
            .WithMany(c => c.Sales)
            .HasForeignKey(o => o.ClientId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(o => o.Dealer)
            .WithMany(c => c.Sales)
            .HasForeignKey(o => o.DealerId)
            .OnDelete(DeleteBehavior.Restrict);
            
        builder.HasOne(o => o.Item)
            .WithMany(i => i.Orders)
            .HasForeignKey(o => o.ItemId)
            .OnDelete(DeleteBehavior.Restrict);
    }
} 