

using TheFisher.BLL.DTOs;

public record CollectionCreateDto(int ClientId, decimal Amount, DateTime Date, List<OrderPaymentDto> OrderPayments);
public record ClientDropDownDto(int Id, string Name);

public record ClientDto (int Id, string Name, decimal OutstandingBalance);