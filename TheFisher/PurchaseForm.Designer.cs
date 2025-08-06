using System.Globalization;

namespace TheFisher
{
    partial class PurchaseForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            saveButton = new Button();
            cancelButton = new Button();
            dealerNameLabel = new Label();
            dealerComboBox = new ComboBox();
            datePicker = new DateTimePicker();
            purchasesGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)purchasesGridView).BeginInit();
            SuspendLayout();
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            saveButton.Location = new Point(20, 403);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 25);
            saveButton.TabIndex = 20;
            saveButton.Text = "حفظ";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += SaveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cancelButton.Location = new Point(105, 403);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 25);
            cancelButton.TabIndex = 21;
            cancelButton.Text = "إلغاء";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += CancelButton_Click;
            // 
            // dealerNameLabel
            // 
            dealerNameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dealerNameLabel.AutoSize = true;
            dealerNameLabel.Location = new Point(12, 9);
            dealerNameLabel.Name = "dealerNameLabel";
            dealerNameLabel.Size = new Size(63, 15);
            dealerNameLabel.TabIndex = 22;
            dealerNameLabel.Text = "اسم العميل";
            // 
            // dealerComboBox
            // 
            dealerComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dealerComboBox.FormattingEnabled = true;
            dealerComboBox.Location = new Point(81, 6);
            dealerComboBox.Name = "dealerComboBox";
            dealerComboBox.Size = new Size(121, 23);
            dealerComboBox.TabIndex = 23;
            dealerComboBox.SelectedIndexChanged += DealerSelectionChanged;
            // 
            // datePicker
            // 
            datePicker.Location = new Point(427, 6);
            datePicker.Name = "datePicker";
            datePicker.Size = new Size(200, 23);
            datePicker.TabIndex = 24;
            // 
            // purchasesGridView
            // 
            purchasesGridView.AllowUserToOrderColumns = true;
            purchasesGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            purchasesGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            purchasesGridView.Location = new Point(20, 53);
            purchasesGridView.Name = "purchasesGridView";
            purchasesGridView.RowTemplate.Height = 25;
            purchasesGridView.Size = new Size(607, 344);
            purchasesGridView.TabIndex = 25;
            // 
            // PurchaseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(639, 453);
            Controls.Add(purchasesGridView);
            Controls.Add(datePicker);
            Controls.Add(dealerComboBox);
            Controls.Add(dealerNameLabel);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PurchaseForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "شراء جديد";
            ((System.ComponentModel.ISupportInitialize)purchasesGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private Label dealerNameLabel;
        private ComboBox dealerComboBox;
        private DateTimePicker datePicker;
        private DataGridView purchasesGridView;
    }
} 