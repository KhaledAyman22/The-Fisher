using System.ComponentModel.DataAnnotations.Schema;

namespace TheFisher.DAL.Entities;

public class Sale
{
    public Ulid Id { get; set; }
    public int ClientId { get; set; }
    public int DealerId { get; set; }
    public int ItemId { get; set; }
    public decimal Units { get; set; }
    public decimal UnitPrice { get; set; }
    public DateTime Date { get; set; }
    public decimal Tax { get; set; }
    public decimal Collected { get; set; }
    public decimal Total { get; set; }

    public decimal CommissionPercent { get; set; }
    public decimal Profit { get; set; }

    public virtual Client Client { get; set; } = null!;
    public virtual Dealer Dealer { get; set; } = null!;
    public virtual Item Item { get; set; } = null!;

    [NotMapped] public decimal Remaining => Total - Collected;
}

