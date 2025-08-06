namespace TheFisher.DAL.Entities;

public class Client
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal OutstandingBalance { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
    public virtual ICollection<Collection> Collections { get; set; } = new List<Collection>();
}