namespace TheFisher.BLL.Dtos;

public record DealerDropDownDto(int Id, string Name);
public class DealerDto
{

    public int Id { get; set; }
    public string Name { get; set; }
    public decimal OutstandingBalance { get; set; }

}