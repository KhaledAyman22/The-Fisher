namespace TheFisher.BLL.Dtos;

public record ItemDropDownDto(int Id, string Name);
public record ItemDto(int Id, string Name, decimal Stock, decimal CommissionedStock, decimal AvgPricePerKg);