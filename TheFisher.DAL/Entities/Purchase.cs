using TheFisher.DAL.enums;

namespace TheFisher.DAL.Entities;

public class Purchase
{
    public Ulid Id { get; set; }
    public int DealerId { get; set; }
    public int ItemId { get; set; }
    public int Boxes { get; set; }
    public decimal? UnitPrice { get; set; }
    public decimal Units { get; set; }
    public DateTime Date { get; set; }
    public decimal? TransportationFees { get; set; }
    public decimal? Tax { get; set; }

    public virtual Dealer Dealer { get; set; } = null!;
    public virtual Item Item { get; set; } = null!;
}
