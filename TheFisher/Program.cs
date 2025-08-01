using System.Globalization;
using Microsoft.Extensions.DependencyInjection;
using TheFisher.BLL.IServices;
using TheFisher.BLL.Services;
using TheFisher.DAL;

namespace TheFisher;

public static class Program
{
    [STAThread]
    public static void Main()
    {
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        Thread.CurrentThread.CurrentCulture = new CultureInfo("ar-EG");
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar-EG");
        
        var services = new ServiceCollection();
        ConfigureServices(services);
        var serviceProvider = services.BuildServiceProvider();

        try
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<FisherDbContext>();
            context.Database.EnsureCreated();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Database initialization failed: {ex.Message}", "Database Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        ApplicationConfiguration.Initialize();
        var mainForm = serviceProvider.GetRequiredService<MainForm>();
        Application.Run(mainForm);
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<FisherDbContext>(ServiceLifetime.Scoped);

        // Services
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IPurchaseService, PurchaseService>();
        services.AddScoped<ICollectionService, CollectionService>();
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<IDealerService, DealerService>();
        services.AddScoped<IItemService, ItemService>();
        services.AddScoped<IReportsService, ReportsService>();

        // Forms
        services.AddTransient<MainForm>();
        services.AddTransient<DealersForm>();
        services.AddTransient<ClientsForm>();
        services.AddTransient<ItemsForm>();
        services.AddTransient<PurchaseForm>();
        services.AddTransient<OrderForm>();
        services.AddTransient<CollectionForm>();
    }
}