using Microsoft.EntityFrameworkCore;
using TheFisher.DAL.Entities;

namespace TheFisher.DAL;

public class FisherDbContext : DbContext
{
    public DbSet<Provider> Providers { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Collection> Collections { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<CollectionDetail> CollectionDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Remember to replace this with your actual connection string, 
        // perhaps from a configuration file.
        optionsBuilder.UseSqlServer("Server=.;Database=TheFisher;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}