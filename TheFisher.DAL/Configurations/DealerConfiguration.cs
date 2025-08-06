using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheFisher.DAL.Entities;

namespace TheFisher.DAL.Configurations;

public class DealerConfiguration : IEntityTypeConfiguration<Dealer>
{
    public void Configure(EntityTypeBuilder<Dealer> builder)
    {
        builder.HasKey(d => d.Id);
        
        builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(d => d.Type)
            .HasConversion<string>()
            .HasMaxLength(20)
            .IsRequired();
        
        builder.Property(d => d.OutstandingBalance)
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue(0m);
            
        builder.HasMany(d => d.Purchases)
            .WithOne(p => p.Dealer)
            .HasForeignKey(p => p.DealerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
} 