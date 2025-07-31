using Microsoft.EntityFrameworkCore;
using TheFisher.BLL.DTOs;
using TheFisher.BLL.IServices;
using TheFisher.DAL;

namespace TheFisher;

public partial class OrderForm : Form
{
    private readonly FisherDbContext _context;
    private readonly IOrderService _orderService;

    public OrderForm(FisherDbContext context, IOrderService orderService)
    {
        _context = context;
        _orderService = orderService;
        InitializeComponent();
        LoadComboBoxes();
    }



    private async Task LoadComboBoxes()
    {
        try
        {
            var clients = await _context.Clients.OrderBy(c => c.Name).ToListAsync();
            clientComboBox.DataSource = clients;
            clientComboBox.DisplayMember = "Name";
            clientComboBox.ValueMember = "Id";

            var items = await _context.Items.OrderBy(i => i.Name).ToListAsync();
            itemComboBox.DataSource = items;
            itemComboBox.DisplayMember = "Name";
            itemComboBox.ValueMember = "Id";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void WeightNumeric_ValueChanged(object sender, EventArgs e)
    {
        CalculateTotal();
    }

    private void KiloPriceNumeric_ValueChanged(object sender, EventArgs e)
    {
        CalculateTotal();
    }

    private void CalculateTotal()
    {
        var total = weightNumeric.Value * kiloPriceNumeric.Value;
        totalLabel.Text = total.ToString("C2");
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private async void SaveButton_Click(object? sender, EventArgs e)
    {
        if (clientComboBox.SelectedValue == null || itemComboBox.SelectedValue == null)
        {
            MessageBox.Show("Please select client and item.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (weightNumeric.Value <= 0 || kiloPriceNumeric.Value <= 0)
        {
            MessageBox.Show("Please enter valid weight and price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            var orderDto = new OrderCreateDto
            {
                ClientId = (int)clientComboBox.SelectedValue,
                ItemId = (int)itemComboBox.SelectedValue,
                Weight = weightNumeric.Value,
                KiloPrice = kiloPriceNumeric.Value,
                Date = datePicker.Value
            };

            await _orderService.CreateOrderAsync(orderDto);
            MessageBox.Show("Order saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}