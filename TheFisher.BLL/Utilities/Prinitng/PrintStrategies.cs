using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using TheFisher.BLL.DTOs;
using System.Runtime.Versioning;


namespace TheFisher.BLL.Utilities.Prinitng;

public class OrderPrintStrategy : IPrintStrategy
{
    private OrderDto _order;

    [SupportedOSPlatform("windows")] 
    public void Print(object data)
    {
        _order = (OrderDto)data;
        var printDocument = new PrintDocument();
        printDocument.PrintPage += Pd_PrintPage;
        printDocument.Print();
    }

    [SupportedOSPlatform("windows")] 
    private void Pd_PrintPage(object sender, PrintPageEventArgs e)
    {
        var font = new Font("Arial", 12);
        var brush = Brushes.Black;
        float y = 10;

        var sb = new StringBuilder();
        sb.AppendLine("--- Order Receipt ---");
        sb.AppendLine($"Date: {_order.Date:yyyy-MM-dd HH:mm}");
        sb.AppendLine($"Client: {_order.ClientName}");
        sb.AppendLine($"Item: {_order.ItemName}");
        sb.AppendLine($"Units: {_order.Units}");
        sb.AppendLine($"Unit Price: {_order.UnitPrice:C}");
        sb.AppendLine("--------------------");
        sb.AppendLine($"Total: {_order.Total:C}");

        e.Graphics.DrawString(sb.ToString(), font, brush, new PointF(10, y));
    }
}

// Add this class to PrintStrategies.cs
public class PurchaseListPrintStrategy : IPrintStrategy
{
    [SupportedOSPlatform("windows")]
    public void Print(object data)
    {
        var purchases = (List<PurchaseDto>)data;
        var printDocument = new PrintDocument();
        
        printDocument.PrintPage += (sender, e) =>
        {
            var font = new Font("Arial", 10);
            var brush = Brushes.Black;
            float y = 10;

            e.Graphics.DrawString("--- Purchase Report ---", new Font("Arial", 14, FontStyle.Bold), brush, new PointF(10, y));
            y += 30;

            foreach (var purchase in purchases)
            {
                var text = $"Date: {purchase.Date:d} | Provider: {purchase.ProviderName} | Item: {purchase.ItemName} | Total: {purchase.Total:C}";
                e.Graphics.DrawString(text, font, brush, new PointF(10, y));
                y += 20;
            }
        };
        printDocument.Print();
    }
}

// Add this class to PrintStrategies.cs
public class CollectionListPrintStrategy : IPrintStrategy
{
    [SupportedOSPlatform("windows")]
    public void Print(object data)
    {
        var collections = (List<CollectionDto>)data;
        var printDocument = new PrintDocument();
        
        printDocument.PrintPage += (sender, e) =>
        {
            var font = new Font("Arial", 10);
            var brush = Brushes.Black;
            float y = 10;
            
            e.Graphics.DrawString("--- Collection Report ---", new Font("Arial", 14, FontStyle.Bold), brush, new PointF(10, y));
            y += 30;

            foreach (var collection in collections)
            {
                var text = $"Date: {collection.Date:d} | Client: {collection.ClientName} | Amount: {collection.Amount:C}";
                e.Graphics.DrawString(text, font, brush, new PointF(10, y));
                y += 20;
            }
        };
        printDocument.Print();
    }
}