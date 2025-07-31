using TheFisher.BLL.IServices;

namespace TheFisher;

public partial class DealersForm : Form
{
    private readonly IDealerService _dealerService;

    public DealersForm(IDealerService dealerService)
    {
        _dealerService = dealerService;
        InitializeComponent();
        SetupDataGridView();
        // Use Task.Run to avoid CS4014 warning
        _ = Task.Run(async () => await LoadDealers());
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
            var dealers = await _dealerService.GetAllDealersAsync();
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
            MessageBox.Show("يرجى إدخال اسم التاجر.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            await _dealerService.AddDealer(nameTextBox.Text.Trim(), balanceNumeric.Value);
            await LoadDealers();
            ClearInputs();
            MessageBox.Show("تم إضافة التاجر بنجاح.", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"خطأ في إضافة التاجر: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void UpdateButton_Click(object sender, EventArgs e)
    {
        if (dataGridView.SelectedRows.Count == 0)
        {
            MessageBox.Show("يرجى اختيار تاجر للتحديث.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(nameTextBox.Text))
        {
            MessageBox.Show("يرجى إدخال اسم التاجر.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            var selectedRow = dataGridView.SelectedRows[0];
            var dealerId = (int)selectedRow.Cells["Id"].Value;

            await _dealerService.UpdateDealer(dealerId, nameTextBox.Text.Trim(), balanceNumeric.Value);
            await LoadDealers();
            ClearInputs();
            MessageBox.Show("تم تحديث التاجر بنجاح.", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"خطأ في تحديث التاجر: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void DeleteButton_Click(object sender, EventArgs e)
    {
        if (dataGridView.SelectedRows.Count == 0)
        {
            MessageBox.Show("يرجى اختيار تاجر للحذف.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var result = MessageBox.Show("هل أنت متأكد من حذف هذا التاجر؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result != DialogResult.Yes) return;

        try
        {
            var selectedRow = dataGridView.SelectedRows[0];
            var dealerId = (int)selectedRow.Cells["Id"].Value;

            await _dealerService.DeleteDealer(dealerId);
            await LoadDealers();
            ClearInputs();
            MessageBox.Show("تم حذف التاجر بنجاح.", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"خطأ في حذف التاجر: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    private void DealersForm_Load(object sender, EventArgs e)
    {

    }
}