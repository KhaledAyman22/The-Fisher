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

    public void Print(object dto)
    {
        var type = dto.GetType();
        if (_strategies.ContainsKey(type))
        {
            _strategies[type].Print(dto); // This now calls the void Print method
        }
        else
        {
            throw new NotSupportedException($"Printing for type {type.Name} is not supported.");
        }
    }
}