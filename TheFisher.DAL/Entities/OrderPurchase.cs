namespace TheFisher.DAL.Entities;

public class OrderPurchase
{
    public Ulid OrderId { get; set; }
    public Ulid PurchaseId { get; set; }
    public decimal WeightUsed { get; set; }
    public decimal OrderShare { get; set; }
    public decimal SettledAmount { get; set; }

    public virtual Order Order { get; set; } = null!;
    public virtual Purchase Purchase { get; set; } = null!;
}