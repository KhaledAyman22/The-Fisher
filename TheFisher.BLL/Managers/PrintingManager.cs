using TheFisher.BLL.DTOs;
using TheFisher.BLL.Utilities.Prinitng;

namespace TheFisher.BLL.Managers;

public class PrintingManager
{
    private readonly Dictionary<Type, IPrintStrategy> _strategies = new();

    public PrintingManager()
    {
        // Strategies for single items
        _strategies[typeof(OrderDto)] = new OrderPrintStrategy();
        // You would create a PurchasePrintStrategy for a single purchase if needed

        // Strategies for lists (reports)
        _strategies[typeof(List<PurchaseDto>)] = new PurchaseListPrintStrategy();
        _strategies[typeof(List<CollectionDto>)] = new CollectionListPrintStrategy();
    }

    public void Print(object dto)
    {
        var type = dto.GetType();
        if (_strategies.TryGetValue(type, out var strategy))
        {
            strategy.Print(dto);
        }
        else
        {
            throw new NotSupportedException($"Printing for type {type.Name} is not supported.");
        }
    }
}