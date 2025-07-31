namespace TheFisher.BLL.DTOs;

public class OrderPaymentDto
{
    public Ulid OrderId { get; set; }
    public decimal Amount { get; set; }
}