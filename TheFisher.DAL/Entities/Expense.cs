using TheFisher.DAL.enums;

namespace TheFisher.DAL.Entities;

public class Expense
{
    public Ulid Id { get; set; }
    public ExpenseType ExpenseType { get; set; }
    public decimal Amount { get; set; }
    public string? Description { get; set; }
}