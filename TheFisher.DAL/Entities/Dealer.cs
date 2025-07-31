namespace TheFisher.DAL.Entities;

public class Dealer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal OutstandingBalance { get; set; }

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}