namespace TheFisher.BLL.DTOs;

public class PurchaseDto
{
    public int Id { get; set; }
    public required string ProviderName { get; set; }
    public required string ItemName { get; set; }
    public int Units { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Total { get; set; }
    public DateTime Date { get; set; }
}

public class CreatePurchaseDto
{
    public int ProviderId { get; set; }
    public int ItemId { get; set; }
    public int Units { get; set; }
    public decimal UnitPrice { get; set; }
}