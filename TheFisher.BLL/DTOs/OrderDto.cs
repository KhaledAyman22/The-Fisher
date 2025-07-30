namespace TheFisher.BLL.DTOs;

public class OrderDto
{
    public int Id { get; set; }
    public string ClientName { get; set; }
    public string ItemName { get; set; }
    public int Units { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Total { get; set; }
    public decimal Collected { get; set; }
    public DateTime Date { get; set; }
}

public class CreateOrderDto
{
    public int ClientId { get; set; }
    public int ItemId { get; set; }
    public int Units { get; set; }
    public decimal UnitPrice { get; set; }
}