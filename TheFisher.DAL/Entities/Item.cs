namespace TheFisher.DAL.Entities;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}