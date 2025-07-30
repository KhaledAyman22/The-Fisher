namespace TheFisher.BLL.DTOs;

public class CollectionDto
{
    public int Id { get; set; }
    public required string ClientName { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
}

public class CreateCollectionDto
{
    public int ClientId { get; set; }
    public decimal Amount { get; set; }
}