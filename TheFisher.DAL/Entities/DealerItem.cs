namespace TheFisher.DAL.Entities;

public class DealerItem
{
    public int DealerId { get; set; }
    public int ItemId { get; set; }
    public decimal Stock { get; set; }
    public decimal CommissionedStock { get; set; }
    
    public Dealer? Dealer { get; set; }
    public Item? Item { get; set; }
}
