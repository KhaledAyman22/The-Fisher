using TheFisher.BLL.DTOs;
using TheFisher.BLL.IServices;
using TheFisher.DAL.enums;

namespace TheFisher;

public partial class PurchaseForm : Form
{
    private readonly IPurchaseService _purchaseService;
    private readonly IDealerService _dealerService;
    private readonly IItemService _itemService;

    public PurchaseForm(IPurchaseService purchaseService, IDealerService dealerService, IItemService itemService)
    {
        _purchaseService = purchaseService;
        _dealerService = dealerService;
        _itemService = itemService;
        InitializeComponent();
        // Use Task.Run to avoid CS4014 warning
        _ = Task.Run(async () => await LoadComboBoxes());
    }

    private async Task LoadComboBoxes()
    {
        try
        {
            var dealers = await _dealerService.GetDealersForDropDown();
            dealerComboBox.DataSource = dealers;
            dealerComboBox.DisplayMember = "Name";
            dealerComboBox.ValueMember = "Id";

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

    private void TypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Disable unit price for commissioned purchases
        unitPriceNumeric.Enabled = typeComboBox.SelectedItem?.ToString() == "direct";
        if (!unitPriceNumeric.Enabled)
            unitPriceNumeric.Value = 0;
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private async void SaveButton_Click(object sender, EventArgs e)
    {
        if (dealerComboBox.SelectedValue == null || itemComboBox.SelectedValue == null)
        {
            MessageBox.Show("يرجى اختيار التاجر والمنتج.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (totalWeightNumeric.Value <= 0)
        {
            MessageBox.Show("يرجى إدخال وزن إجمالي صحيح.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            var purchaseDto = new PurchaseCreateDto(
                (int)dealerComboBox.SelectedValue,
                (int)itemComboBox.SelectedValue,
                (int)unitsNumeric.Value,
                unitPriceNumeric.Enabled ? unitPriceNumeric.Value : null,
                totalWeightNumeric.Value,
                (PurchaseType)Enum.Parse(typeof(PurchaseType), typeComboBox.SelectedItem.ToString()!),
                datePicker.Value
            );

            await _purchaseService.CreatePurchaseAsync(purchaseDto);
            MessageBox.Show("تم حفظ الشراء بنجاح!", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"خطأ في حفظ الشراء: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}