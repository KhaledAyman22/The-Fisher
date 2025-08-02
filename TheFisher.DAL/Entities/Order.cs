using System.ComponentModel.DataAnnotations.Schema;

namespace TheFisher.DAL.Entities;

public class    Order
{
    public Ulid Id { get; set; }
    public int ClientId { get; set; }
    public int ItemId { get; set; }
    public decimal Weight { get; set; }
    public decimal KiloPrice { get; set; }
    public DateTime Date { get; set; }
    public decimal Tax { get; set; }
    public decimal Collected { get; set; }
    public decimal Total { get; set; }
    public virtual Client Client { get; set; } = null!;
    public virtual Item Item { get; set; } = null!;
    public virtual ICollection<CollectionDetail> CollectionDetails { get; set; } = new List<CollectionDetail>();
    public virtual ICollection<OrderPurchase> OrderPurchases { get; set; } = new List<OrderPurchase>();

    [NotMapped] public decimal Remaining => Total - Collected;
}

