using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheFisher.DAL.Entities;

namespace TheFisher.DAL.Configurations;

public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .HasColumnType("nvarchar(26)")
            .HasConversion(new UlidToStringConverter());
        
        builder.Property(e => e.Description)
            .HasMaxLength(100);
            
        builder.Property(e => e.Amount)
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue(0m);
    }
} 