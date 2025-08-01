namespace TheFisher.BLL.DTOs;

public record OrderCreateDto(
    int ClientId,
    int ItemId,
    decimal Weight,
    decimal KiloPrice,
    DateTime Date,
    decimal Tax);

public record OrderPaymentDto(Ulid OrderId, decimal Amount);