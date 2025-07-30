namespace TheFisher.DAL.Entities;

public class Purchase
{
    public int Id { get; set; }
    public int ProviderId { get; set; }
    public Provider? Provider { get; set; }
    public int ItemId { get; set; }
    public Item? Item { get; set; }
    public int Units { get; set; }
    public decimal UnitPrice { get; set; }
    public DateTime Date { get; set; }
}