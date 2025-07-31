using TheFisher.DAL;
using TheFisher.DAL.Entities;
using TheFisher.DAL.Repositories;

namespace TheFisher;

public partial class DealersForm : Form
{
    private readonly FisherDbContext _context;
    private readonly DealerRepository _dealerRepository;

    public DealersForm(FisherDbContext context)
    {
        _context = context;
        _dealerRepository = new DealerRepository(context);
        InitializeComponent();
        SetupDataGridView();
        LoadDealers();
    }

    private void SetupDataGridView()
    {
        dataGridView.Columns.Clear();
        dataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Visible = false });
        dataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Name", Width = 200 });
        dataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "OutstandingBalance", HeaderText = "Outstanding Balance", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
    }

    private async Task LoadDealers()
    {
        try
        {
            var dealers = await _dealerRepository.GetAllAsync();
            dataGridView.DataSource = dealers.ToList();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading dealers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void AddButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(nameTextBox.Text))
        {
            MessageBox.Show("Please enter a dealer name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            var dealer = new Dealer
            {
                Name = nameTextBox.Text.Trim(),
                OutstandingBalance = balanceNumeric.Value
            };

            await _dealerRepository.AddAsync(dealer);
            await LoadDealers();
            ClearInputs();
            MessageBox.Show("Dealer added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error adding dealer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void UpdateButton_Click(object sender, EventArgs e)
    {
        if (dataGridView.SelectedRows.Count == 0)
        {
            MessageBox.Show("Please select a dealer to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(nameTextBox.Text))
        {
            MessageBox.Show("Please enter a dealer name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            var selectedRow = dataGridView.SelectedRows[0];
            var dealerId = (int)selectedRow.Cells["Id"].Value;

            var dealer = await _dealerRepository.GetByIdAsync(dealerId);
            if (dealer == null)
            {
                MessageBox.Show("Dealer not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dealer.Name = nameTextBox.Text.Trim();
            dealer.OutstandingBalance = balanceNumeric.Value;

            await _dealerRepository.UpdateAsync(dealer);
            await LoadDealers();
            ClearInputs();
            MessageBox.Show("Dealer updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error updating dealer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void DeleteButton_Click(object sender, EventArgs e)
    {
        if (dataGridView.SelectedRows.Count == 0)
        {
            MessageBox.Show("Please select a dealer to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var result = MessageBox.Show("Are you sure you want to delete this dealer?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result != DialogResult.Yes) return;

        try
        {
            var selectedRow = dataGridView.SelectedRows[0];
            var dealerId = (int)selectedRow.Cells["Id"].Value;

            await _dealerRepository.DeleteAsync(dealerId);
            await LoadDealers();
            ClearInputs();
            MessageBox.Show("Dealer deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error deleting dealer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void DataGridView_SelectionChanged(object sender, EventArgs e)
    {
        if (dataGridView.SelectedRows.Count > 0)
        {
            var selectedRow = dataGridView.SelectedRows[0];
            nameTextBox.Text = selectedRow.Cells["Name"].Value?.ToString() ?? "";
            balanceNumeric.Value = selectedRow.Cells["OutstandingBalance"].Value != null ? (decimal)selectedRow.Cells["OutstandingBalance"].Value : 0;
        }
    }

    private void ClearInputs()
    {
        nameTextBox.Text = "";
        balanceNumeric.Value = 0;
        dataGridView.ClearSelection();
    }
}