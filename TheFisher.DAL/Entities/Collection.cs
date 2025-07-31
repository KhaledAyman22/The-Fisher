namespace TheFisher.DAL.Entities;

public class Collection
{   
    public Ulid Id { get; set; }
    public int ClientId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }

    public virtual Client Client { get; set; } = null!;
    public virtual ICollection<CollectionDetail> CollectionDetails { get; set; } = new List<CollectionDetail>();
}
