namespace TheFisher.BLL.DTOs;

public class CollectionCreateDto
{
    public int ClientId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public List<OrderPaymentDto> OrderPayments { get; set; } = new();
}