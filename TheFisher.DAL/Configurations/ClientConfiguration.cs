using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheFisher.DAL.Entities;

namespace TheFisher.DAL.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);
            
        builder.Property(c => c.OutstandingBalance)
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue(0m);
            
        builder.HasMany(c => c.Orders)
            .WithOne(o => o.Client)
            .HasForeignKey(o => o.ClientId)
            .OnDelete(DeleteBehavior.Restrict);
            
        builder.HasMany(c => c.Collections)
            .WithOne(col => col.Client)
            .HasForeignKey(col => col.ClientId)
            .OnDelete(DeleteBehavior.Restrict);
    }
} 