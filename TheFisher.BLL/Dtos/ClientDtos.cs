namespace TheFisher.BLL.Dtos;


public record ClientDropDownDto(int Id, string Name);

public record ClientDto (int Id, string Name, decimal OutstandingBalance);

public record ClientBalanceDto(string Name, decimal OutstandingBalance, decimal Total);