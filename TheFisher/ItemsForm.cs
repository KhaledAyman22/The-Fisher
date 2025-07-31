using TheFisher.BLL.IServices;
using TheFisher.DAL.Entities;

namespace TheFisher;

public partial class ItemsForm : Form
{
    private readonly IItemService _itemService;

    public ItemsForm(IItemService itemService)
    {
        _itemService = itemService;
        InitializeComponent();
        // Use Task.Run to avoid CS4014 warning
        _ = Task.Run(async () => await LoadItems());
    }



    private async Task LoadItems()
    {
        try
        {
            var items = await _itemService.GetAllItemsAsync();
            dataGridView.DataSource = items.ToList();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void AddButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(nameTextBox.Text))
        {
            MessageBox.Show("يرجى إدخال اسم المنتج.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            await _itemService.AddItem(nameTextBox.Text.Trim());
            await LoadItems();
            ClearInputs();
            MessageBox.Show("تم إضافة المنتج بنجاح!", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"خطأ في إضافة المنتج: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void UpdateButton_Click(object sender, EventArgs e)
    {
        if (dataGridView.CurrentRow?.DataBoundItem is not ItemDto selectedItem)
        {
            MessageBox.Show("يرجى اختيار منتج للتحديث.", "خطأ في الاختيار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(nameTextBox.Text))
        {
            MessageBox.Show("يرجى إدخال اسم المنتج.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            await _itemService.UpdateItem(selectedItem.Id, nameTextBox.Text.Trim());
            await LoadItems();
            ClearInputs();
            MessageBox.Show("تم تحديث المنتج بنجاح!", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"خطأ في تحديث المنتج: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void DeleteButton_Click(object sender, EventArgs e)
    {
        if (dataGridView.CurrentRow?.DataBoundItem is not ItemDto selectedItem)
        {
            MessageBox.Show("يرجى اختيار منتج للحذف.", "خطأ في الاختيار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var result = MessageBox.Show($"هل أنت متأكد من حذف المنتج '{selectedItem.Name}'؟", 
            "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            try
            {
                await _itemService.DeleteItem(selectedItem.Id);
                await LoadItems();
                ClearInputs();
                MessageBox.Show("تم حذف المنتج بنجاح!", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في حذف المنتج: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void DataGridView_SelectionChanged(object sender, EventArgs e)
    {
        if (dataGridView.CurrentRow?.DataBoundItem is ItemDto selectedItem)
        {
            nameTextBox.Text = selectedItem.Name;
            stockNumeric.Value = selectedItem.Stock;
            priceNumeric.Value = selectedItem.AvgPricePerKg;
        }
    }

    private void ClearInputs()
    {
        nameTextBox.Text = string.Empty;
        stockNumeric.Value = 0;
        priceNumeric.Value = 0;
    }
}