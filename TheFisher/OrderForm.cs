using TheFisher.BLL.DTOs;
using TheFisher.BLL.IServices;

namespace TheFisher;

public partial class OrderForm : Form
{
    private readonly IOrderService _orderService;
    private readonly IClientService _clientService;
    private readonly IItemService _itemService;

    public OrderForm(IOrderService orderService, IClientService clientService, IItemService itemService)
    {
        _orderService = orderService;
        _clientService = clientService;
        _itemService = itemService;
        InitializeComponent();
        // Use Task.Run to avoid CS4014 warning
        _ = Task.Run(async () => await LoadComboBoxes());
    }


    private async Task LoadComboBoxes()
    {
        try
        {
            var clients = await _clientService.GetClientsForDropDown();
            clientComboBox.DataSource = clients;
            clientComboBox.DisplayMember = "Name";
            clientComboBox.ValueMember = "Id";

            var items = await _itemService.GetItemsForDropDown();
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
            MessageBox.Show("يرجى اختيار العميل والمنتج.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (weightNumeric.Value <= 0 || kiloPriceNumeric.Value <= 0)
        {
            MessageBox.Show("يرجى إدخال وزن وسعر صحيحين.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            var orderDto = new OrderCreateDto(
                (int)clientComboBox.SelectedValue,
                (int)itemComboBox.SelectedValue,
                weightNumeric.Value,
                kiloPriceNumeric.Value,
                datePicker.Value,
                taxNumeric.Value
            );

            await _orderService.CreateOrderAsync(orderDto);
            MessageBox.Show("تم حفظ الطلب بنجاح!", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"خطأ في حفظ الطلب: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}