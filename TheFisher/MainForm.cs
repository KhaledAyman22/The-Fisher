using Microsoft.Extensions.DependencyInjection;
using TheFisher.BLL.IServices;
using TheFisher.BLL.Services;
using TheFisher.Helpers;

namespace TheFisher;

public partial class MainForm : Form
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ISalesService _salesService;
    private readonly IPurchaseService _purchaseService;
    private readonly ICollectionService _collectionService;

    // Dashboard controls
    private System.Windows.Forms.Timer _refreshTimer = null!;

    public MainForm(IServiceProvider serviceProvider, ISalesService salesService, IPurchaseService purchaseService, ICollectionService collectionService)
    {
        InitializeComponent();
        _serviceProvider = serviceProvider;
        _salesService = salesService;
        _purchaseService = purchaseService;
        _collectionService = collectionService;

        // Setup refresh timer
        SetupRefreshTimer();

        // Load initial statistics
        LoadStatistics();

        // Set minimum size to prevent controls from overlapping
        this.MinimumSize = new Size(1000, 700);

        // Subscribe to Resize event
        this.Resize += MainForm_Resize;

        // Initially arrange controls properly
        ArrangeControls();
    }

    private void MainForm_Resize(object? sender, EventArgs e)
    {
        // Recalculate card positions when form is resized
        FormResponsiveHelper.SetupResponsiveCardLayout(statsPanel, new[] { revenueCard, dealersCard, clientsCard, collectionsCard }, 2);
    }

    private void ArrangeControls()
    {
        // Adjust the layout of stats cards based on form size
        int cardMargin = 20;
        int cardWidth = (statsPanel.Width - (3 * cardMargin)) / 2;
        int cardHeight = (statsPanel.Height - (3 * cardMargin)) / 2;

        // Position the cards in a responsive grid layout
        revenueCard.Size = new Size(cardWidth, cardHeight);
        revenueCard.Location = new Point(cardMargin, cardMargin);

        dealersCard.Size = new Size(cardWidth, cardHeight);
        dealersCard.Location = new Point(cardWidth + (2 * cardMargin), cardMargin);

        clientsCard.Size = new Size(cardWidth, cardHeight);
        clientsCard.Location = new Point(cardMargin, cardHeight + (2 * cardMargin));

        collectionsCard.Size = new Size(cardWidth, cardHeight);
        collectionsCard.Location = new Point(cardWidth + (2 * cardMargin), cardHeight + (2 * cardMargin));
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
            // // Update date
            // dateLabel.Text = $"اليوم: {DateTime.Now:dddd، MMMM dd، yyyy}";
            //
            // // Load statistics sequentially to avoid connection conflicts
            // var revenue = await _salesService.GetCurrentMonthRevenueAsync();
            // var dealers = await _purchaseService.GetMoneyOwedToDealersAsync();
            // var clients = await _salesService.GetMoneyClientsOweAsync();
            // var collections = await _collectionService.GetCurrentMonthCollectionsAsync();
            //
            // // Update labels on UI thread
            // this.Invoke(() =>
            // {
            //     revenueLabel.Text = $"${revenue:N2}";
            //     owedToDealersLabel.Text = $"${dealers:N2}";
            //     clientsOweLabel.Text = $"${clients:N2}";
            //     collectionsLabel.Text = $"${collections:N2}";
            // });
        }
        catch (Exception ex)
        {
            MessageBox.Show($"خطأ في تحميل الإحصائيات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ShowDealersForm(object? sender, EventArgs e)
    {
        var form = new DealersForm(_serviceProvider.GetRequiredService<IDealerService>());
        form.ShowDialog();
        LoadStatistics();
    }

    private void ShowClientsForm(object? sender, EventArgs e)
    {
        var form = new ClientsForm(_serviceProvider.GetRequiredService<IClientService>());
        form.ShowDialog();
        LoadStatistics();
    }

    private void ShowItemsForm(object? sender, EventArgs e)
    {
        var form = new ItemsForm(_serviceProvider.GetRequiredService<IItemService>());
        form.ShowDialog();
        LoadStatistics();
    }

    private void ShowPurchaseForm(object? sender, EventArgs e)
    {
        var form = new PurchaseForm(
            _serviceProvider.GetRequiredService<IPurchaseService>(),
            _serviceProvider.GetRequiredService<IDealerService>(),
            _serviceProvider.GetRequiredService<IItemService>(),
            _serviceProvider.GetRequiredService<IClientService>()
        );
        form.ShowDialog();
        LoadStatistics();
    }

    private void ShowOrderForm(object? sender, EventArgs e)
    {
        var form = new OrderForm(
            _serviceProvider.GetRequiredService<ISalesService>(),
            _serviceProvider.GetRequiredService<IClientService>(),
            _serviceProvider.GetRequiredService<IItemService>()
        );
        form.ShowDialog();
        LoadStatistics();
    }

    private void ShowCollectionForm(object? sender, EventArgs e)
    {
        var form = new CollectionForm(
            _serviceProvider.GetRequiredService<ICollectionService>(),
            _serviceProvider.GetRequiredService<IClientService>(),
            _serviceProvider.GetRequiredService<ISalesService>()
        );
        form.ShowDialog();
        LoadStatistics();
    }

    private void ShowTodaysPurchasesReport(object? sender, EventArgs e)
    {
        var reportsService = _serviceProvider.GetRequiredService<IReportsService>();
        var form = new ReportsForm("Today's Purchases", reportsService);
        form.ShowDialog();
    }

    private void ShowTodaysCollectionsReport(object? sender, EventArgs e)
    {
        var reportsService = _serviceProvider.GetRequiredService<IReportsService>();
        var form = new ReportsForm("Today's Collections", reportsService);
        form.ShowDialog();
    }

    private void ShowPurchasesByDealerReport(object? sender, EventArgs e)
    {
        var reportsService = _serviceProvider.GetRequiredService<IReportsService>();
        var form = new ReportsForm("Purchases by Dealer", reportsService);
        form.ShowDialog();
    }

    private void ShowCollectionsByClientReport(object? sender, EventArgs e)
    {
        var reportsService = _serviceProvider.GetRequiredService<IReportsService>();
        var form = new ReportsForm("Collections by Client", reportsService);
        form.ShowDialog();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _refreshTimer?.Stop();
            _refreshTimer?.Dispose();
        }
        base.Dispose(disposing);
    }
}