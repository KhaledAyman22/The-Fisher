namespace TheFisher.BLL.Dtos;

public record GetCollectionDto(Ulid Id, string ClientName, decimal ClientOutstanding, decimal Amount, DateTime Date);
public record CollectionDto(Ulid Id, int ClientId, decimal Amount, DateTime Date);
