using TheFisher.DAL.enums;

namespace TheFisher.BLL.Dtos;

public class PurchaseDto
{
    public Ulid Id { get; set; }
    public int DealerId { get; set; }
    public string DealerName { get; set; }
    public int ItemId { get; set; }
    public string ItemName { get; set; }
    public int Boxes { get; set; }
    public decimal? UnitPrice { get; set; }
    public decimal Units { get; set; }
    public DateTime Date { get; set; }
    public decimal? TransportationFees { get; set; }
    public decimal? Tax { get; set; }
}
    
    
    