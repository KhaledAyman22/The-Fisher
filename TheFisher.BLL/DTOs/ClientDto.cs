namespace TheFisher.BLL.DTOs;

public class ClientDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal OutstandingBalance { get; set; }
}