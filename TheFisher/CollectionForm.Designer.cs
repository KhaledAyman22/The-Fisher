namespace TheFisher
{
    partial class CollectionForm
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
            clientComboBox = new ComboBox();
            amountNumeric = new NumericUpDown();
            datePicker = new DateTimePicker();
            saveButton = new Button();
            cancelButton = new Button();
            ordersGridView = new DataGridView();
            clientLabel = new Label();
            amountLabel = new Label();
            dateLabel = new Label();
            ordersLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)amountNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ordersGridView).BeginInit();
            SuspendLayout();
            // 
            // clientComboBox
            // 
            clientComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            clientComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            clientComboBox.FormattingEnabled = true;
            clientComboBox.Location = new Point(78, 15);
            clientComboBox.Name = "clientComboBox";
            clientComboBox.Size = new Size(190, 23);
            clientComboBox.TabIndex = 1;
            clientComboBox.SelectedIndexChanged += ClientComboBox_SelectedIndexChanged;
            // 
            // amountNumeric
            // 
            amountNumeric.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            amountNumeric.DecimalPlaces = 2;
            amountNumeric.Location = new Point(78, 44);
            amountNumeric.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            amountNumeric.Name = "amountNumeric";
            amountNumeric.Size = new Size(190, 23);
            amountNumeric.TabIndex = 3;
            // 
            // datePicker
            // 
            datePicker.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            datePicker.Location = new Point(78, 73);
            datePicker.Name = "datePicker";
            datePicker.Size = new Size(190, 23);
            datePicker.TabIndex = 5;
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            saveButton.Location = new Point(20, 220);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 25);
            saveButton.TabIndex = 8;
            saveButton.Text = "حفظ";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += SaveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cancelButton.Location = new Point(105, 220);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 25);
            cancelButton.TabIndex = 9;
            cancelButton.Text = "إلغاء";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += CancelButton_Click;
            // 
            // ordersGridView
            // 
            ordersGridView.AllowUserToAddRows = false;
            ordersGridView.AllowUserToDeleteRows = false;
            ordersGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ordersGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ordersGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ordersGridView.Location = new Point(78, 102);
            ordersGridView.MultiSelect = false;
            ordersGridView.Name = "ordersGridView";
            ordersGridView.ReadOnly = true;
            ordersGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ordersGridView.Size = new Size(190, 100);
            ordersGridView.TabIndex = 7;
            // 
            // clientLabel
            // 
            clientLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            clientLabel.AutoSize = true;
            clientLabel.Location = new Point(29, 18);
            clientLabel.Name = "clientLabel";
            clientLabel.RightToLeft = RightToLeft.Yes;
            clientLabel.Size = new Size(43, 15);
            clientLabel.TabIndex = 0;
            clientLabel.Text = "العميل:";
            // 
            // amountLabel
            // 
            amountLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            amountLabel.AutoSize = true;
            amountLabel.Location = new Point(29, 47);
            amountLabel.Name = "amountLabel";
            amountLabel.RightToLeft = RightToLeft.Yes;
            amountLabel.Size = new Size(39, 15);
            amountLabel.TabIndex = 2;
            amountLabel.Text = "المبلغ:";
            // 
            // dateLabel
            // 
            dateLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dateLabel.AutoSize = true;
            dateLabel.Location = new Point(29, 76);
            dateLabel.Name = "dateLabel";
            dateLabel.RightToLeft = RightToLeft.Yes;
            dateLabel.Size = new Size(41, 15);
            dateLabel.TabIndex = 4;
            dateLabel.Text = "التاريخ:";
            // 
            // ordersLabel
            // 
            ordersLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ordersLabel.AutoSize = true;
            ordersLabel.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            ordersLabel.Location = new Point(29, 105);
            ordersLabel.Name = "ordersLabel";
            ordersLabel.RightToLeft = RightToLeft.Yes;
            ordersLabel.Size = new Size(43, 16);
            ordersLabel.TabIndex = 6;
            ordersLabel.Text = "الطلبات:";
            // 
            // CollectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 270);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(ordersLabel);
            Controls.Add(dateLabel);
            Controls.Add(amountLabel);
            Controls.Add(clientLabel);
            Controls.Add(ordersGridView);
            Controls.Add(datePicker);
            Controls.Add(amountNumeric);
            Controls.Add(clientComboBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CollectionForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "تحصيل جديد";
            ((System.ComponentModel.ISupportInitialize)amountNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)ordersGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox clientComboBox;
        private System.Windows.Forms.NumericUpDown amountNumeric;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.DataGridView ordersGridView;
        private System.Windows.Forms.Label clientLabel;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label ordersLabel;
    }
} 