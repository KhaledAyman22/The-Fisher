using TheFisher.DAL;
using TheFisher.DAL.Entities;
using TheFisher.DAL.Repositories;

namespace TheFisher;

public partial class ClientsForm : Form
{
    private readonly FisherDbContext _context;
    private readonly ClientRepository _clientRepository;

    public ClientsForm(FisherDbContext context)
    {
        _context = context;
        _clientRepository = new ClientRepository(context);
        InitializeComponent();
        SetupDataGridView();
        LoadClients();
    }

    private void SetupDataGridView()
    {
        dataGridView.Columns.Clear();
        dataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Visible = false });
        dataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Name", Width = 200 });
        dataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "OutstandingBalance", HeaderText = "Outstanding Balance", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
    }

    private async Task LoadClients()
    {
        try
        {
            var clients = await _clientRepository.GetAllAsync();
            dataGridView.DataSource = clients.ToList();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading clients: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void AddButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(nameTextBox.Text))
        {
            MessageBox.Show("Please enter a client name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            var client = new Client
            {
                Name = nameTextBox.Text.Trim(),
                OutstandingBalance = balanceNumeric.Value
            };

            await _clientRepository.AddAsync(client);
            await LoadClients();
            ClearInputs();
            MessageBox.Show("Client added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error adding client: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void UpdateButton_Click(object sender, EventArgs e)
    {
        if (dataGridView.SelectedRows.Count == 0)
        {
            MessageBox.Show("Please select a client to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(nameTextBox.Text))
        {
            MessageBox.Show("Please enter a client name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            var selectedRow = dataGridView.SelectedRows[0];
            var clientId = (int)selectedRow.Cells["Id"].Value;

            var client = await _clientRepository.GetByIdAsync(clientId);
            if (client == null)
            {
                MessageBox.Show("Client not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            client.Name = nameTextBox.Text.Trim();
            client.OutstandingBalance = balanceNumeric.Value;

            await _clientRepository.UpdateAsync(client);
            await LoadClients();
            ClearInputs();
            MessageBox.Show("Client updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error updating client: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void DeleteButton_Click(object sender, EventArgs e)
    {
        if (dataGridView.SelectedRows.Count == 0)
        {
            MessageBox.Show("Please select a client to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var result = MessageBox.Show("Are you sure you want to delete this client?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result != DialogResult.Yes) return;

        try
        {
            var selectedRow = dataGridView.SelectedRows[0];
            var clientId = (int)selectedRow.Cells["Id"].Value;

            await _clientRepository.DeleteAsync(clientId);
            await LoadClients();
            ClearInputs();
            MessageBox.Show("Client deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error deleting client: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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