using System.Text;
using TheFisher.BLL.DTOs;

namespace TheFisher.BLL.Utilities.Prinitng;

public class OrderPrintStrategy : IPrintStrategy
{
    public string Print(object data)
    {
        var order = (OrderDto)data;
        var sb = new StringBuilder();
        sb.AppendLine("--- Order Receipt ---");
        sb.AppendLine($"Client: {order.ClientName}");
        sb.AppendLine($"Item: {order.ItemName}");
        sb.AppendLine($"Total: {order.Total:C}");
        return sb.ToString();
    }
}

public class PurchasePrintStrategy : IPrintStrategy
{
    public string Print(object data)
    {
        var purchase = (PurchaseDto)data;
        var sb = new StringBuilder();
        sb.AppendLine("--- Purchase Receipt ---");
        sb.AppendLine($"Provider: {purchase.ProviderName}");
        sb.AppendLine($"Item: {purchase.ItemName}");
        sb.AppendLine($"Total: {purchase.Total:C}");
        return sb.ToString();
    }
}