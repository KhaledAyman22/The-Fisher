using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheFisher.DAL.Entities;

namespace TheFisher.DAL.Configurations;

public class DealerItemConfiguration : IEntityTypeConfiguration<DealerItem>
{
    public void Configure(EntityTypeBuilder<DealerItem> builder)
    {
        builder.HasKey(cd => new{cd.DealerId, cd.ItemId});
        
        builder.Property(i => i.Stock)
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue(0m);
            
        // builder.Property(i => i.AvgPricePerKg)
        //     .HasColumnType("decimal(18,2)")
        //     .HasDefaultValue(0m);
        
        builder.Property(i => i.CommissionedStock)
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue(0m);

        
        builder.HasOne(c => c.Dealer)
            .WithMany(cd => cd.DealerItems)
            .HasForeignKey(cd => cd.DealerId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        
        builder.HasOne(c => c.Item)
            .WithMany(cd => cd.DealerItems)
            .HasForeignKey(cd => cd.ItemId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
} 