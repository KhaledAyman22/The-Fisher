namespace TheFisher.BLL.DTOs;

public class OrderCreateDto
{
    public int ClientId { get; set; }
    public int ItemId { get; set; }
    public decimal Weight { get; set; }
    public decimal KiloPrice { get; set; }
    public DateTime Date { get; set; }
}