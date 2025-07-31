using TheFisher.BLL.IServices;
using TheFisher.BLL.Services;
using TheFisher.DAL;

namespace TheFisher;

public partial class MainForm : Form
{
    private readonly FisherDbContext _context;
    private readonly IOrderService _orderService;
    private readonly IPurchaseService _purchaseService;
    private readonly ICollectionService _collectionService;
    
    // Dashboard controls
    private System.Windows.Forms.Timer _refreshTimer = null!;

    public MainForm()
    {
        InitializeComponent();
        _context = new FisherDbContext();
        _orderService = new OrderService(_context);
        _purchaseService = new PurchaseService(_context);
        _collectionService = new CollectionService(_context);

        // Ensure database is created
        _context.Database.EnsureCreated();
        
        // Setup refresh timer
        SetupRefreshTimer();
        
        // Load initial statistics
        LoadStatistics();
    }

    private void SetupRefreshTimer()
    {
        _refreshTimer = new System.Windows.Forms.Timer
        {
            Interval = 30000 // Refresh every 30 seconds
        };
        _refreshTimer.Tick += (s, e) => LoadStatistics();
        _refreshTimer.Start();
    }

    private async void LoadStatistics()
    {
        try
        {
            // Update date
            dateLabel.Text = $"Today: {DateTime.Now:dddd, MMMM dd, yyyy}";

            // Load statistics sequentially to avoid connection conflicts
            var revenue = await _orderService.GetCurrentMonthRevenueAsync();
            var dealers = await _purchaseService.GetMoneyOwedToDealersAsync();
            var clients = await _orderService.GetMoneyClientsOweAsync();
            var collections = await _collectionService.GetCurrentMonthCollectionsAsync();

            // Update labels on UI thread
            this.Invoke(() =>
            {
                revenueLabel.Text = $"${revenue:N2}";
                owedToDealersLabel.Text = $"${dealers:N2}";
                clientsOweLabel.Text = $"${clients:N2}";
                collectionsLabel.Text = $"${collections:N2}";
            });
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading statistics: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ShowDealersForm(object sender, EventArgs e)
    {
        var form = new DealersForm(_context);
        form.ShowDialog();
        LoadStatistics(); // Refresh statistics after form closes
    }

    private void ShowClientsForm(object sender, EventArgs e)
    {
        var form = new ClientsForm(_context);
        form.ShowDialog();
        LoadStatistics(); // Refresh statistics after form closes
    }

    private void ShowItemsForm(object sender, EventArgs e)
    {
        var form = new ItemsForm(_context);
        form.ShowDialog();
        LoadStatistics(); // Refresh statistics after form closes
    }

    private void ShowPurchaseForm(object sender, EventArgs e)
    {
        var form = new PurchaseForm(_context, _purchaseService);
        form.ShowDialog();
        LoadStatistics(); // Refresh statistics after form closes
    }

    private void ShowOrderForm(object sender, EventArgs e)
    {
        var form = new OrderForm(_context, _orderService);
        form.ShowDialog();
        LoadStatistics(); // Refresh statistics after form closes
    }

    private void ShowCollectionForm(object sender, EventArgs e)
    {
        var form = new CollectionForm(_context, _collectionService);
        form.ShowDialog();
        LoadStatistics(); // Refresh statistics after form closes
    }

    private void ShowTodaysPurchasesReport(object sender, EventArgs e)
    {
        var form = new ReportsForm(_context, "Today's Purchases");
        form.ShowDialog();
    }

    private void ShowTodaysCollectionsReport(object sender, EventArgs e)
    {
        var form = new ReportsForm(_context, "Today's Collections");
        form.ShowDialog();
    }

    private void ShowPurchasesByDealerReport(object sender, EventArgs e)
    {
        var form = new ReportsForm(_context, "Purchases by Dealer");
        form.ShowDialog();
    }

    private void ShowCollectionsByClientReport(object sender, EventArgs e)
    {
        var form = new ReportsForm(_context, "Collections by Client");
        form.ShowDialog();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _refreshTimer?.Stop();
            _refreshTimer?.Dispose();
            _context?.Dispose();
        }
        base.Dispose(disposing);
    }
}