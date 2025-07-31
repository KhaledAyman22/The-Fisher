using TheFisher.BLL.IServices;

namespace TheFisher;

public partial class ReportsForm : Form
{
    private readonly string _reportType;
    private readonly IReportsService _reportsService;

    public ReportsForm(string reportType, IReportsService reportsService)
    {
        _reportType = reportType;
        _reportsService = reportsService;
        InitializeComponent();
        // Use Task.Run to avoid CS4014 warning
        _ = Task.Run(async () => await LoadReport());
    }

    private async Task LoadFilterComboBox()
    {
        try
        {
            if (_reportType.Contains("by Dealer"))
            {
                var dealers = await _reportsService.GetDealersForFilterAsync();
                filterComboBox.DataSource = dealers;
                filterComboBox.DisplayMember = "Name";
                filterComboBox.ValueMember = "Id";
            }
            else if (_reportType.Contains("by Client"))
            {
                var clients = await _reportsService.GetClientsForFilterAsync();
                filterComboBox.DataSource = clients;
                filterComboBox.DisplayMember = "Name";
                filterComboBox.ValueMember = "Id";
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"خطأ في تحميل بيانات الفلتر: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async Task LoadReport()
    {
        try
        {
            object dataSource = null;

            switch (_reportType)
            {
                case "Today's Purchases":
                    dataSource = await _reportsService.GetTodaysPurchasesAsync();
                    break;

                case "Today's Collections":
                    dataSource = await _reportsService.GetTodaysCollectionsAsync();
                    break;

                case "Purchases by Dealer":
                    if (filterComboBox?.SelectedValue != null)
                    {
                        dataSource = await _reportsService.GetPurchasesByDealerAsync((int)filterComboBox.SelectedValue);
                    }
                    break;

                case "Collections by Client":
                    if (filterComboBox?.SelectedValue != null)
                    {
                        dataSource = await _reportsService.GetCollectionsByClientAsync((int)filterComboBox.SelectedValue);
                    }
                    break;
            }

            dataGridView.DataSource = dataSource;
                
            // Format currency columns
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (column.Name.Contains("Price") || column.Name.Contains("Amount"))
                {
                    column.DefaultCellStyle.Format = "C2";
                }
                else if (column.Name.Contains("Weight"))
                {
                    column.DefaultCellStyle.Format = "N3";
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"خطأ في تحميل التقرير: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void FilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        await LoadReport();
    }

    private async void RefreshButton_Click(object sender, EventArgs e)
    {
        await LoadReport();
    }
}