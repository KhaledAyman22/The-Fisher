namespace TheFisher.DAL.Entities;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public decimal InHouseStock { get; set; }

    public decimal AveragePrice { get; set; }

    public virtual ICollection<Sale> Orders { get; set; } = new List<Sale>();
    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    public virtual ICollection<DealerItem> DealerItems { get; set; } = new List<DealerItem>();
}
