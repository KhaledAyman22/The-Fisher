namespace TheFisher.DAL.Entities;

public class Client
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal OutstandingBalance { get; set; }
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<Collection> Collections { get; set; } = new List<Collection>();
}