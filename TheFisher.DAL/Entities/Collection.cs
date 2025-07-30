namespace TheFisher.DAL.Entities;

public class Collection
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public Client? Client { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
}