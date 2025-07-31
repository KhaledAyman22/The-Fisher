using TheFisher.BLL.DTOs;
using TheFisher.BLL.IServices;

namespace TheFisher;

public partial class CollectionForm : Form
{
    private readonly ICollectionService _collectionService;
    private readonly IClientService _clientService;
    private readonly IOrderService _orderService;

    public CollectionForm(ICollectionService collectionService, IClientService clientService, IOrderService orderService)
    {
        _collectionService = collectionService;
        _clientService = clientService;
        _orderService = orderService;
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
            var orders = await _orderService.GetClientUnpaidOrdersAsync(clientId);
            ordersGridView.DataSource = orders;

            // Add editable payment amount column
            foreach (DataGridViewRow row in ordersGridView.Rows)
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
        if (clientComboBox.SelectedValue == null)
        {
            MessageBox.Show("يرجى اختيار العميل.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (amountNumeric.Value <= 0)
        {
            MessageBox.Show("يرجى إدخال مبلغ تحصيل صحيح.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            var orderPayments = new List<OrderPaymentDto>();
            decimal totalPayments = 0;

            foreach (DataGridViewRow row in ordersGridView.Rows)
            {
                if (row.Cells["Select"].Value is true && 
                    decimal.TryParse(row.Cells["PaymentAmount"].Value?.ToString(), out decimal paymentAmount) && 
                    paymentAmount > 0)
                {
                    var idValue = row.Cells["Id"].Value?.ToString();
                    if (idValue != null)
                    {
                        var orderId = Ulid.Parse(idValue);
                        orderPayments.Add(new OrderPaymentDto(orderId, paymentAmount));
                        totalPayments += paymentAmount;
                    }
                }
            }

            if (totalPayments != amountNumeric.Value)
            {
                MessageBox.Show($"يجب أن يساوي إجمالي مبالغ الدفع ({totalPayments:C2}) مبلغ التحصيل ({amountNumeric.Value:C2}).", 
                    "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var collectionDto = new CollectionCreateDto(
                (int)clientComboBox.SelectedValue,
                amountNumeric.Value,
                datePicker.Value,
                orderPayments
            );

            await _collectionService.CreateCollectionAsync(collectionDto);
            MessageBox.Show("تم حفظ التحصيل بنجاح!", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"خطأ في حفظ التحصيل: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}