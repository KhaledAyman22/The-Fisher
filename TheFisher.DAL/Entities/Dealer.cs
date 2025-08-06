using TheFisher.DAL.enums;

namespace TheFisher.DAL.Entities;

public class Dealer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal OutstandingBalance { get; set; }

    public PurchaseType Type { get; set; }
    
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    public virtual ICollection<DealerItem> DealerItems { get; set; } = new List<DealerItem>();
}