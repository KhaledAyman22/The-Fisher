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