using Microsoft.EntityFrameworkCore;
using TheFisher.BLL.DTOs;
using TheFisher.BLL.IServices;
using TheFisher.DAL;

namespace TheFisher;

public partial class CollectionForm : Form
{
    private readonly FisherDbContext _context;
    private readonly ICollectionService _collectionService;
    private ComboBox _clientComboBox;
    private NumericUpDown _amountNumeric;
    private DateTimePicker _datePicker;
    private DataGridView _ordersGridView;
    private Button _saveButton, _cancelButton;

    public CollectionForm(FisherDbContext context, ICollectionService collectionService)
    {
        _context = context;
        _collectionService = collectionService;
        InitializeComponent();
        LoadComboBoxes();
    }



    private async Task LoadComboBoxes()
    {
        try
        {
            var clients = await _context.Clients.OrderBy(c => c.Name).ToListAsync();
            _clientComboBox.DataSource = clients;
            _clientComboBox.DisplayMember = "Name";
            _clientComboBox.ValueMember = "Id";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading clients: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void ClientComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (clientComboBox.SelectedValue != null)
        {
            await LoadClientOrders((int)clientComboBox.SelectedValue);
        }
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private async Task LoadClientOrders(int clientId)
    {
        try
        {
            var orders = await _context.Orders
                .Include(o => o.Item)
                .Where(o => o.ClientId == clientId && o.Total > o.Collected)
                .Select(o => new
                {
                    o.Id,
                    o.Item.Name,
                    o.Weight,
                    o.Total,
                    o.Collected,
                    Balance = o.Total - o.Collected
                })
                .ToListAsync();

            _ordersGridView.DataSource = orders;

            // Add editable payment amount column
            foreach (DataGridViewRow row in _ordersGridView.Rows)
            {
                if (row.Cells["PaymentAmount"] != null)
                {
                    row.Cells["PaymentAmount"].Value = 0;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void SaveButton_Click(object sender, EventArgs e)
    {
        if (_clientComboBox.SelectedValue == null)
        {
            MessageBox.Show("Please select a client.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (_amountNumeric.Value <= 0)
        {
            MessageBox.Show("Please enter a valid collection amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            var orderPayments = new List<OrderPaymentDto>();
            decimal totalPayments = 0;

            foreach (DataGridViewRow row in _ordersGridView.Rows)
            {
                if (row.Cells["Select"].Value is true && 
                    decimal.TryParse(row.Cells["PaymentAmount"].Value?.ToString(), out decimal paymentAmount) && 
                    paymentAmount > 0)
                {
                    orderPayments.Add(new OrderPaymentDto
                    {
                        OrderId = Ulid.NewUlid(),
                        Amount = paymentAmount
                    });
                    totalPayments += paymentAmount;
                }
            }

            if (totalPayments != _amountNumeric.Value)
            {
                MessageBox.Show($"Total payment amounts ({totalPayments:C2}) must equal collection amount ({_amountNumeric.Value:C2}).", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var collectionDto = new CollectionCreateDto
            {
                ClientId = (int)_clientComboBox.SelectedValue,
                Amount = _amountNumeric.Value,
                Date = _datePicker.Value,
                OrderPayments = orderPayments
            };

            await _collectionService.CreateCollectionAsync(collectionDto);
            MessageBox.Show("Collection saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving collection: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}