using Microsoft.EntityFrameworkCore;
using TheFisher.BLL.DTOs;
using TheFisher.BLL.IServices;
using TheFisher.DAL;
using TheFisher.DAL.enums;

namespace TheFisher;

public partial class PurchaseForm : Form
{
    private readonly FisherDbContext _context;
    private readonly IPurchaseService _purchaseService;
    private ComboBox _dealerComboBox, _itemComboBox, _typeComboBox;
    private NumericUpDown _unitsNumeric, _unitPriceNumeric, _totalWeightNumeric;
    private DateTimePicker _datePicker;
    private Button _saveButton, _cancelButton;

    public PurchaseForm(FisherDbContext context, IPurchaseService purchaseService)
    {
        _context = context;
        _purchaseService = purchaseService;
        InitializeComponent();
        LoadComboBoxes();
    }



    private async Task LoadComboBoxes()
    {
        try
        {
            var dealers = await _context.Dealers.OrderBy(d => d.Name).ToListAsync();
            _dealerComboBox.DataSource = dealers;
            _dealerComboBox.DisplayMember = "Name";
            _dealerComboBox.ValueMember = "Id";

            var items = await _context.Items.OrderBy(i => i.Name).ToListAsync();
            _itemComboBox.DataSource = items;
            _itemComboBox.DisplayMember = "Name";
            _itemComboBox.ValueMember = "Id";
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
        if (_dealerComboBox.SelectedValue == null || _itemComboBox.SelectedValue == null)
        {
            MessageBox.Show("Please select dealer and item.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (_totalWeightNumeric.Value <= 0)
        {
            MessageBox.Show("Please enter a valid total weight.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            var purchaseDto = new PurchaseCreateDto
            {
                DealerId = (int)_dealerComboBox.SelectedValue,
                ItemId = (int)_itemComboBox.SelectedValue,
                TotalUnits = (int)_unitsNumeric.Value,
                KiloPrice = _unitPriceNumeric.Enabled ? _unitPriceNumeric.Value : null,
                TotalWeight = _totalWeightNumeric.Value,
                Type = (PurchaseType)Enum.Parse(typeof(PurchaseType), _typeComboBox.SelectedItem.ToString()!),
                Date = _datePicker.Value
            };

            await _purchaseService.CreatePurchaseAsync(purchaseDto);
            MessageBox.Show("Purchase saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving purchase: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}