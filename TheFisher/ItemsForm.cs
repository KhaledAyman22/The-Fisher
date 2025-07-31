using System.Windows.Forms.VisualStyles;
using TheFisher.DAL;
using TheFisher.DAL.Entities;

namespace TheFisher;

public partial class ItemsForm : Form
{
    private readonly FisherDbContext _context;
    private readonly Repository<Item> _itemRepository;
    private DataGridView _dataGridView;
    private TextBox _nameTextBox;
    private NumericUpDown _stockNumeric, _priceNumeric;
    private Button _addButton, _updateButton, _deleteButton;

    public ItemsForm(FisherDbContext context)
    {
        _context = context;
        _itemRepository = new Repository<Item>(context);
        InitializeComponent();
        LoadItems();
    }



    private async Task LoadItems()
    {
        try
        {
            var items = await _itemRepository.GetAllAsync();
            _dataGridView.DataSource = items.ToList();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void AddButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_nameTextBox.Text))
        {
            MessageBox.Show("Please enter an item name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            var item = new Item
            {
                Name = _nameTextBox.Text.Trim(),
                Stock = _stockNumeric.Value,
                AvgPricePerKg = _priceNumeric.Value
            };

            await _itemRepository.AddAsync(item);
            await LoadItems();
            ClearInputs();
            MessageBox.Show("Item added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error adding item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void UpdateButton_Click(object sender, EventArgs e)
    {
        if (_dataGridView.CurrentRow?.DataBoundItem is not Item selectedItem)
        {
            MessageBox.Show("Please select an item to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(_nameTextBox.Text))
        {
            MessageBox.Show("Please enter an item name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            selectedItem.Name = _nameTextBox.Text.Trim();
            selectedItem.Stock = _stockNumeric.Value;
            selectedItem.AvgPricePerKg = _priceNumeric.Value;

            await _itemRepository.UpdateAsync(selectedItem);
            await LoadItems();
            ClearInputs();
            MessageBox.Show("Item updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error updating item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void DeleteButton_Click(object sender, EventArgs e)
    {
        if (_dataGridView.CurrentRow?.DataBoundItem is not Item selectedItem)
        {
            MessageBox.Show("Please select an item to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var result = MessageBox.Show($"Are you sure you want to delete item '{selectedItem.Name}'?", 
            "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            try
            {
                await _itemRepository.DeleteAsync(selectedItem.Id);
                await LoadItems();
                ClearInputs();
                MessageBox.Show("Item deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void DataGridView_SelectionChanged(object sender, EventArgs e)
    {
        if (_dataGridView.CurrentRow?.DataBoundItem is Item selectedItem)
        {
            _nameTextBox.Text = selectedItem.Name;
            _stockNumeric.Value = selectedItem.Stock;
            _priceNumeric.Value = selectedItem.AvgPricePerKg;
        }
    }

    private void ClearInputs()
    {
        _nameTextBox.Clear();
        _stockNumeric.Value = 0;
        _priceNumeric.Value = 0;
    }
}