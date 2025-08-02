namespace TheFisher.BLL.Dtos;

public record GetCollectionDto(Ulid Id, string ClientName, decimal Amount, DateTime Date);
public record CreateCollectionDto(int ClientId, decimal Amount, DateTime Date);
