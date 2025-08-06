using System.ComponentModel;
using TheFisher.BLL.Dtos;
using TheFisher.BLL.IServices;
using TheFisher.DAL.enums;

namespace TheFisher;

public partial class PurchaseForm : Form
{
    private readonly IPurchaseService _purchaseService;
    private readonly IDealerService _dealerService;
    private readonly IItemService _itemService;
    private readonly IClientService _clientService;
    private List<DealerDropDownDto> dealers;
    private List<ItemDropDownDto> items;
    private List<ClientDropDownDto> clients;


    public PurchaseForm(IPurchaseService purchaseService, IDealerService dealerService, IItemService itemService, IClientService clientService)
    {
        _purchaseService = purchaseService;
        _dealerService = dealerService;
        _itemService = itemService;
        _clientService = clientService;
        InitializeComponent();

        Init();
    }

    private async void Init()
    {
        dealers = await _dealerService.GetDealersForDropDown();
        items = await _itemService.GetItemsForDropDown();
        clients = await _clientService.GetClientsForDropDown();
        LoadComboBoxes();
    }

    private async Task SetupPurchaseGrid()
    {
        var dealer = (DealerDropDownDto) dealerComboBox.SelectedValue;
        var purchases =
            await _purchaseService.GetPurchasesAsync(datePicker.Value.Date, dealer.Id);
        purchasesGridView.AutoGenerateColumns = false;
        purchasesGridView.DataSource = new BindingList<PurchaseDto>(purchases.ToList());
        purchasesGridView.AllowUserToAddRows = true;
        purchasesGridView.AllowUserToOrderColumns = true;
        purchasesGridView.AllowUserToResizeColumns = true;
        purchasesGridView.AllowUserToDeleteRows = true;
        
        // Hidden Id
        var idColumn = new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Id",
            Visible = false
        };
        purchasesGridView.Columns.Add(idColumn);
        
        
        // Item ComboBox
        var clientColumn = new DataGridViewComboBoxColumn
        {
            DataPropertyName = "Id", // Bind to the ItemId in Dto
            HeaderText = "البائع",
            DisplayMember = "Name",
            ValueMember = "Id",
            DataSource = clients
        };
        purchasesGridView.Columns.Add(clientColumn);
        
        // Item ComboBox
        var itemColumn = new DataGridViewComboBoxColumn
        {
            DataPropertyName = "Id", // Bind to the ItemId in Dto
            HeaderText = "الصنف",
            DisplayMember = "Name",
            ValueMember = "Id",
            DataSource = items
        };
        purchasesGridView.Columns.Add(itemColumn);

        // TotalUnits
        purchasesGridView.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "TotalUnits",
            HeaderText = "وحدات"
        });

        // UnitPrice
        purchasesGridView.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "UnitPrice",
            HeaderText = "سعر"
        });

        // Units
        purchasesGridView.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Units",
            HeaderText = "وزن"
        });

        // TransportationFees
        purchasesGridView.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "TransportationFees",
            HeaderText = "نولون"
        });

        // Tax
        purchasesGridView.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Tax",
            HeaderText = "جر"
        });
    }


    private void LoadComboBoxes()
    {
        try
        {
            dealerComboBox.DataSource = dealers;
            dealerComboBox.DisplayMember = "Name";
            dealerComboBox.ValueMember = "Id";
            dealerComboBox.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private async void SaveButton_Click(object sender, EventArgs e)
    {
        // if (dealerComboBox.SelectedValue == null || itemComboBox.SelectedValue == null)
        // {
        //     MessageBox.Show("يرجى اختيار التاجر والمنتج.", "خطأ في التحقق", MessageBoxButtons.OK,
        //         MessageBoxIcon.Warning);
        //     return;
        // }
        //
        // if (totalWeightNumeric.Value <= 0)
        // {
        //     MessageBox.Show("يرجى إدخال وزن إجمالي صحيح.", "خطأ في التحقق", MessageBoxButtons.OK,
        //         MessageBoxIcon.Warning);
        //     return;
        // }

        try
        {
            // var purchaseDto = new PurchaseDto(
            //     (int)dealerComboBox.SelectedValue,
            //     (int)itemComboBox.SelectedValue,
            //     (int)unitsNumeric.Value,
            //     unitPriceNumeric.Enabled ? unitPriceNumeric.Value : null,
            //     totalWeightNumeric.Value,
            //     (PurchaseType)typeComboBox.SelectedIndex,
            //     datePicker.Value,
            //     transportaionNumeric.Enabled ? transportaionNumeric.Value : null,
            //     taxNumeric.Enabled ? taxNumeric.Value : null,
            //     commissionPercentNumeric.Enabled ? commissionPercentNumeric.Value : null
            // );
            //
            // await _purchaseService.CreatePurchaseAsync(purchaseDto);
            // MessageBox.Show("تم حفظ الشراء بنجاح!", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // this.DialogResult = DialogResult.OK;
            // this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"خطأ في حفظ الشراء: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void DealerSelectionChanged(object sender, EventArgs e)
    {
        await SetupPurchaseGrid();
    }
}