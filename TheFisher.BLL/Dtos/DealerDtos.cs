namespace TheFisher.BLL.Dtos;

public record DealerDropDownDto(int Id, string Name);
public record DealerDto(int Id, string Name, decimal OutstandingBalance);