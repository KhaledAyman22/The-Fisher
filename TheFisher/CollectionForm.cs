using TheFisher.BLL.Dtos;
using TheFisher.BLL.IServices;

namespace TheFisher;

public partial class CollectionForm : Form
{
    private readonly ICollectionService _collectionService;
    private readonly IClientService _clientService;
    private readonly ISalesService _salesService;
    private List<ClientDto> clients;
    
    public CollectionForm(ICollectionService collectionService, IClientService clientService, ISalesService salesService)
    {
        _collectionService = collectionService;
        _clientService = clientService;
        _salesService = salesService;
        InitializeComponent();
        
        LoadComboBoxes();
    }

    private async Task LoadComboBoxes()
    {
        try
        {
            clients = await _clientService.GetClients();
            clientComboBox.DataSource = clients;
            clientComboBox.DisplayMember = "Name";
            clientComboBox.ValueMember = "Id";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading clients: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // private async void ClientComboBox_SelectedIndexChanged(object sender, EventArgs e)
    // {
    //     if (clientComboBox.SelectedItem is ClientDropDownDto selectedClient)
    //     {
    //         await LoadClientOrders(selectedClient.Id);
    //     }
    // }

    private void CancelButton_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
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
            var client = (ClientDto)clientComboBox.SelectedItem;
            var outstanding = clients.First(c => c.Id == client.Id).OutstandingBalance;
            
            if (outstanding < amountNumeric.Value)
            {
                MessageBox.Show($"يجب أن يساوي إجمالي مبالغ الدفع ({outstanding:C2}) مبلغ التحصيل ({amountNumeric.Value:C2}).", 
                    "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // var collectionDto = new CollectionDto(
            //     client.Id,
            //     amountNumeric.Value,
            //     datePicker.Value
            // );
            //
            // await _collectionService.CreateDailyCollectionsAsync(collectionDto);
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