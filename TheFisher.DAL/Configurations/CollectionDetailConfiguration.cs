using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheFisher.DAL.Entities;

namespace TheFisher.DAL.Configurations;

public class CollectionDetailConfiguration : IEntityTypeConfiguration<CollectionDetail>
{
    public void Configure(EntityTypeBuilder<CollectionDetail> builder)
    {
        builder.HasKey(cd => cd.Id);
        
        builder.Property(cd => cd.Id)
            .HasColumnType("nvarchar(26)")
            .HasConversion(new UlidToStringConverter());
            
        builder.Property(cd => cd.CollectionId)
            .HasColumnType("nvarchar(26)")
            .IsRequired()
            .HasConversion(new UlidToStringConverter());
            
        builder.Property(cd => cd.OrderId)
            .HasColumnType("nvarchar(26)")
            .HasConversion(new UlidToStringConverter());
        
        builder.Property(cd => cd.Amount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
            
        builder.Property(c => c.Profit)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
        
        builder.HasOne(cd => cd.Collection)
            .WithMany(c => c.CollectionDetails)
            .HasForeignKey(cd => cd.CollectionId)
            .OnDelete(DeleteBehavior.Restrict);
            
        builder.HasOne(cd => cd.Order)
            .WithMany(o => o.CollectionDetails)
            .HasForeignKey(cd => cd.OrderId)
            .OnDelete(DeleteBehavior.Restrict);
    }
} 