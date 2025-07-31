namespace TheFisher.DAL.Entities;

public class CollectionDetail
{
    public Ulid Id { get; set; }
    public Ulid CollectionId { get; set; }
    public Ulid OrderId { get; set; }
    public decimal Amount { get; set; }

    public virtual Collection Collection { get; set; } = null!;
    public virtual Order Order { get; set; } = null!;
}
