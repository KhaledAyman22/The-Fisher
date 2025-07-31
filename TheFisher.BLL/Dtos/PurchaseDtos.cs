using TheFisher.DAL.enums;

namespace TheFisher.BLL.DTOs;

public record PurchaseCreateDto(
    int DealerId,
    int ItemId,
    int TotalUnits,
    decimal? KiloPrice,
    decimal TotalWeight,
    PurchaseType Type,
    DateTime Date
);