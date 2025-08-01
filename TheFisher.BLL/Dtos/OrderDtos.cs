namespace TheFisher.BLL.Dtos;

public record OrderCreateDto(
    int ClientId,
    int ItemId,
    decimal Weight,
    decimal KiloPrice,
    DateTime Date,
    decimal Tax);

public record OrderPaymentDto(Ulid OrderId, decimal Amount);

public record GetOrderDto(
    Ulid Id,
    string ClientName,
    string ItemName,
    decimal Weight,
    decimal KiloPrice,
    DateTime Date,
    decimal Tax);