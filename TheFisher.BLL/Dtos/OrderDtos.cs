namespace TheFisher.BLL.Dtos;

public record SalesDto
{
    public Ulid Id { get; set; }
    public int ClientId { get; set; }
    public int ItemId { get; set; }
    public string ItemName { get; set; }
    public decimal Units { get; set; }
    public decimal UnitPrice { get; set; }
    public DateTime Date { get; set; }
    public decimal Tax { get; set; }
    public decimal? CommissionPercent { get; set; }

    
}

public record OrderPaymentDto(Ulid OrderId, decimal Amount);

public record GetOrderDto(
    Ulid Id,
    string ClientName,
    string ItemName,
    decimal Weight,
    decimal KiloPrice,
    DateTime Date,
    decimal Tax,
    decimal Total);