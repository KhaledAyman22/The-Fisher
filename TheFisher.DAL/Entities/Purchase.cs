using TheFisher.DAL.enums;

namespace TheFisher.DAL.Entities;

public class Purchase
{
    public Ulid Id { get; set; }
    public int DealerId { get; set; }
    public int ItemId { get; set; }
    public int TotalUnits { get; set; }
    public decimal? UnitPrice { get; set; }
    public decimal TotalWeight { get; set; }
    public decimal WeightAvailable { get; set; }
    public PurchaseType Type { get; set; } = PurchaseType.Direct; // Direct or Commission
    public DateTime Date { get; set; }
    public decimal CommissionPercent { get; set; }

    public virtual Dealer Dealer { get; set; } = null!;
    public virtual Item Item { get; set; } = null!;
    public virtual ICollection<OrderPurchase> OrderPurchases { get; set; } = new List<OrderPurchase>();
}
