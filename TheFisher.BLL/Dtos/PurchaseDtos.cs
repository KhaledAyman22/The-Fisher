using TheFisher.DAL.enums;

namespace TheFisher.BLL.Dtos;

public record PurchaseCreateDto(
    int DealerId,
    int ItemId,
    int TotalUnits,
    decimal? KiloPrice,
    decimal TotalWeight,
    PurchaseType Type,
    DateTime Date,
    decimal TransportationFees,
    decimal? Tax
);

public record GetPurchaseDto(
    Ulid Id,
    string DealerName,
    string ItemName,
    int TotalUnits,
    decimal? KiloPrice,
    decimal TotalWeight,
    PurchaseType Type,
    DateTime Date,
    decimal TransportationFees,
    decimal? Tax
);

