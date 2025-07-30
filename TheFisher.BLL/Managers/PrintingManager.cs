using TheFisher.BLL.DTOs;
using TheFisher.BLL.Utilities.Prinitng;

namespace TheFisher.BLL.Managers;

public class PrintingManager
{
    private readonly Dictionary<Type, IPrintStrategy> _strategies = new();

    public PrintingManager()
    {
        _strategies[typeof(OrderDto)] = new OrderPrintStrategy();
        _strategies[typeof(PurchaseDto)] = new PurchasePrintStrategy();
    }

    public string Print(object dto)
    {
        var type = dto.GetType();
        if (_strategies.TryGetValue(type, out var strategy))
        {
            return strategy.Print(dto);
        }
        throw new NotSupportedException($"Printing for type {type.Name} is not supported.");
    }
}