using Microsoft.EntityFrameworkCore;
using TheFisher.DAL.Entities;
using TheFisher.DAL.Configurations;

namespace TheFisher.DAL;

public class FisherDbContext : DbContext
{
    public DbSet<Dealer> Dealers { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Collection> Collections { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<CollectionDetail> CollectionDetails { get; set; }
    public DbSet<OrderPurchase> OrderPurchases { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Remember to replace this with your actual connection string, 
        // perhaps from a configuration file.
        optionsBuilder.UseSqlServer("Server=.;Database=TheFisher;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClientConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new PurchaseConfiguration());
        modelBuilder.ApplyConfiguration(new ItemConfiguration());
        modelBuilder.ApplyConfiguration(new DealerConfiguration());
        modelBuilder.ApplyConfiguration(new CollectionConfiguration());
        modelBuilder.ApplyConfiguration(new CollectionDetailConfiguration());
        modelBuilder.ApplyConfiguration(new OrderPurchaseConfiguration());
        modelBuilder.ApplyConfiguration(new ExpenseConfiguration());
    }
}