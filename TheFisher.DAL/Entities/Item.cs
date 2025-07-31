namespace TheFisher.DAL.Entities;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Stock { get; set; }
    public decimal CommissionedStock { get; set; }
    public decimal AvgPricePerKg { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
