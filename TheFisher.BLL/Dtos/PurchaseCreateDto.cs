using TheFisher.DAL.enums;

namespace TheFisher.BLL.DTOs;

public class PurchaseCreateDto
{
    public int DealerId { get; set; }
    public int ItemId { get; set; }
    public int TotalUnits { get; set; }
    public decimal? KiloPrice { get; set; }
    public decimal TotalWeight { get; set; }
    public PurchaseType Type { get; set; }
    public DateTime Date { get; set; }
}