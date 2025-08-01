using TheFisher.BLL.IServices;
using TheFisher.BLL.Services;

namespace TheFisher;

public partial class ClientsForm : Form
{
    private readonly IClientService _clientService;
    
    public ClientsForm(IClientService clientService)
    {
        _clientService = clientService;
        InitializeComponent();
        SetupDataGridView();
        
        LoadClients();
    }

    private void SetupDataGridView()
    {
        dataGridView.Columns.Clear();
        dataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", HeaderText = "ID", Visible = false });
        dataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", DataPropertyName = "Name", HeaderText = "Name", Width = 200 });
        dataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "OutstandingBalance", DataPropertyName = "OutstandingBalance", HeaderText = "Outstanding Balance", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
    }

    private async Task LoadClients()
    {
        try
        {
            var clients = await _clientService.GetClients();
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
            MessageBox.Show("يرجى إدخال اسم العميل.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            await _clientService.AddClient(nameTextBox.Text.Trim(), balanceNumeric.Value);
            await LoadClients();
            ClearInputs();
            MessageBox.Show("تم إضافة العميل بنجاح.", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"خطأ في إضافة العميل: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void UpdateButton_Click(object sender, EventArgs e)
    {
        if (dataGridView.SelectedRows.Count == 0)
        {
            MessageBox.Show("يرجى اختيار عميل للتحديث.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(nameTextBox.Text))
        {
            MessageBox.Show("يرجى إدخال اسم العميل.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            var selectedRow = dataGridView.SelectedRows[0];
            var clientId = (int)selectedRow.Cells["Id"].Value;

            var clientName = nameTextBox.Text.Trim();
            var outstandingBalance = balanceNumeric.Value;

            await _clientService.UpdateClient(clientId, clientName, outstandingBalance);
            
            await LoadClients();
            ClearInputs();
            MessageBox.Show("تم تحديث العميل بنجاح.", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"خطأ في تحديث العميل: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void DeleteButton_Click(object sender, EventArgs e)
    {
        if (dataGridView.SelectedRows.Count == 0)
        {
            MessageBox.Show("يرجى اختيار عميل للحذف.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var result = MessageBox.Show("هل أنت متأكد من حذف هذا العميل؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result != DialogResult.Yes) return;

        try
        {
            var selectedRow = dataGridView.SelectedRows[0];
            var clientId = (int)selectedRow.Cells["Id"].Value;

            await _clientService.DeleteClient(clientId);
            await LoadClients();
            ClearInputs();
            MessageBox.Show("تم حذف العميل بنجاح.", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"خطأ في حذف العميل: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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