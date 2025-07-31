using System.Net.Mime;
using TheFisher.DAL;

namespace TheFisher;

public static class Program
{
    [STAThread]
    public static void Main()
    {
        // Enable better scaling for high DPI displays
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
            
        // Initialize database
        try
        {
            using var context = new FisherDbContext();
            context.Database.EnsureCreated();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Database initialization failed: {ex.Message}", "Database Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}