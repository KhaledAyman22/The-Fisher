using Microsoft.EntityFrameworkCore;
using TheFisher.DAL;

namespace TheFisher;

public partial class ReportsForm : Form
{
    private readonly FisherDbContext _context;
    private readonly string _reportType;

    public ReportsForm(FisherDbContext context, string reportType)
    {
        _context = context;
        _reportType = reportType;
        InitializeComponent();
        LoadReport();
    }

    private async Task LoadFilterComboBox()
    {
        try
        {
            if (_reportType.Contains("by Dealer"))
            {
                var dealers = await _context.Dealers.OrderBy(d => d.Name).ToListAsync();
                filterComboBox.DataSource = dealers;
                filterComboBox.DisplayMember = "Name";
                filterComboBox.ValueMember = "Id";
            }
            else if (_reportType.Contains("by Client"))
            {
                var clients = await _context.Clients.OrderBy(c => c.Name).ToListAsync();
                filterComboBox.DataSource = clients;
                filterComboBox.DisplayMember = "Name";
                filterComboBox.ValueMember = "Id";
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading filter data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    var todayPurchases = await _context.Purchases
                        .Include(p => p.Dealer)
                        .Include(p => p.Item)
                        .Where(p => p.Date.Date == DateTime.Today)
                        .Select(p => new
                        {
                            p.Id,
                            Dealer = p.Dealer.Name,
                            Item = p.Item.Name,
                            p.TotalUnits,
                            p.UnitPrice,
                            p.TotalWeight,
                            p.WeightAvailable,
                            p.Type,
                            p.Date
                        })
                        .OrderByDescending(p => p.Date)
                        .ToListAsync();
                    dataSource = todayPurchases;
                    break;

                case "Today's Collections":
                    var todayCollections = await _context.Collections
                        .Include(c => c.Client)
                        .Where(c => c.Date.Date == DateTime.Today)
                        .Select(c => new
                        {
                            c.Id,
                            Client = c.Client.Name,
                            c.Amount,
                            c.Date
                        })
                        .OrderByDescending(c => c.Date)
                        .ToListAsync();
                    dataSource = todayCollections;
                    break;

                case "Purchases by Dealer":
                    if (filterComboBox?.SelectedValue != null)
                    {
                        var dealerPurchases = await _context.Purchases
                            .Include(p => p.Dealer)
                            .Include(p => p.Item)
                            .Where(p => p.DealerId == (int)filterComboBox.SelectedValue)
                            .Select(p => new
                            {
                                p.Id,
                                Item = p.Item.Name,
                                p.TotalUnits,
                                p.UnitPrice,
                                p.TotalWeight,
                                p.WeightAvailable,
                                p.Type,
                                p.Date
                            })
                            .OrderByDescending(p => p.Date)
                            .ToListAsync();
                        dataSource = dealerPurchases;
                    }
                    break;

                case "Collections by Client":
                    if (filterComboBox?.SelectedValue != null)
                    {
                        var clientCollections = await _context.Collections
                            .Include(c => c.Client)
                            .Where(c => c.ClientId == (int)filterComboBox.SelectedValue)
                            .Select(c => new
                            {
                                c.Id,
                                c.Amount,
                                c.Date
                            })
                            .OrderByDescending(c => c.Date)
                            .ToListAsync();
                        dataSource = clientCollections;
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
            MessageBox.Show($"Error loading report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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