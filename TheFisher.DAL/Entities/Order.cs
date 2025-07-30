namespace TheFisher.DAL.Entities;

public class Order
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; }
    public int ItemId { get; set; }
    public Item Item { get; set; }
    public int Units { get; set; }
    public decimal UnitPrice { get; set; }
    public DateTime Date { get; set; }
    public decimal Total => Units * UnitPrice;
    public decimal Collected { get; set; }
}