namespace TheFisher
{
    partial class OrderForm
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
            itemComboBox = new ComboBox();
            weightNumeric = new NumericUpDown();
            kiloPriceNumeric = new NumericUpDown();
            datePicker = new DateTimePicker();
            saveButton = new Button();
            cancelButton = new Button();
            totalLabel = new Label();
            clientLabel = new Label();
            itemLabel = new Label();
            weightLabel = new Label();
            priceLabel = new Label();
            dateLabel = new Label();
            totalNumeric = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)weightNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)kiloPriceNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)totalNumeric).BeginInit();
            SuspendLayout();
            // 
            // clientComboBox
            // 
            clientComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            clientComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            clientComboBox.FormattingEnabled = true;
            clientComboBox.Location = new Point(105, 12);
            clientComboBox.Name = "clientComboBox";
            clientComboBox.Size = new Size(190, 23);
            clientComboBox.TabIndex = 1;
            // 
            // itemComboBox
            // 
            itemComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            itemComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            itemComboBox.FormattingEnabled = true;
            itemComboBox.Location = new Point(105, 41);
            itemComboBox.Name = "itemComboBox";
            itemComboBox.Size = new Size(190, 23);
            itemComboBox.TabIndex = 3;
            // 
            // weightNumeric
            // 
            weightNumeric.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            weightNumeric.DecimalPlaces = 3;
            weightNumeric.Location = new Point(105, 70);
            weightNumeric.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            weightNumeric.Name = "weightNumeric";
            weightNumeric.Size = new Size(190, 23);
            weightNumeric.TabIndex = 5;
            weightNumeric.ValueChanged += WeightNumeric_ValueChanged;
            // 
            // kiloPriceNumeric
            // 
            kiloPriceNumeric.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            kiloPriceNumeric.DecimalPlaces = 2;
            kiloPriceNumeric.Location = new Point(105, 99);
            kiloPriceNumeric.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            kiloPriceNumeric.Name = "kiloPriceNumeric";
            kiloPriceNumeric.Size = new Size(190, 23);
            kiloPriceNumeric.TabIndex = 7;
            kiloPriceNumeric.ValueChanged += KiloPriceNumeric_ValueChanged;
            // 
            // datePicker
            // 
            datePicker.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            datePicker.Location = new Point(105, 157);
            datePicker.Name = "datePicker";
            datePicker.Size = new Size(190, 23);
            datePicker.TabIndex = 11;
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            saveButton.Location = new Point(20, 200);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 25);
            saveButton.TabIndex = 12;
            saveButton.Text = "حفظ";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += SaveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cancelButton.Location = new Point(105, 200);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 25);
            cancelButton.TabIndex = 13;
            cancelButton.Text = "إلغاء";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += CancelButton_Click;
            // 
            // totalLabel
            // 
            totalLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            totalLabel.AutoSize = true;
            totalLabel.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            totalLabel.Location = new Point(31, 134);
            totalLabel.Name = "totalLabel";
            totalLabel.RightToLeft = RightToLeft.Yes;
            totalLabel.Size = new Size(61, 19);
            totalLabel.TabIndex = 8;
            totalLabel.Text = "المجموع:";
            // 
            // clientLabel
            // 
            clientLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            clientLabel.AutoSize = true;
            clientLabel.Location = new Point(31, 18);
            clientLabel.Name = "clientLabel";
            clientLabel.RightToLeft = RightToLeft.Yes;
            clientLabel.Size = new Size(43, 15);
            clientLabel.TabIndex = 0;
            clientLabel.Text = "العميل:";
            // 
            // itemLabel
            // 
            itemLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            itemLabel.AutoSize = true;
            itemLabel.Location = new Point(31, 47);
            itemLabel.Name = "itemLabel";
            itemLabel.RightToLeft = RightToLeft.Yes;
            itemLabel.Size = new Size(39, 15);
            itemLabel.TabIndex = 2;
            itemLabel.Text = "المنتج:";
            // 
            // weightLabel
            // 
            weightLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            weightLabel.AutoSize = true;
            weightLabel.Location = new Point(31, 76);
            weightLabel.Name = "weightLabel";
            weightLabel.RightToLeft = RightToLeft.Yes;
            weightLabel.Size = new Size(36, 15);
            weightLabel.TabIndex = 4;
            weightLabel.Text = "الوزن:";
            // 
            // priceLabel
            // 
            priceLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            priceLabel.AutoSize = true;
            priceLabel.Location = new Point(31, 105);
            priceLabel.Name = "priceLabel";
            priceLabel.RightToLeft = RightToLeft.Yes;
            priceLabel.Size = new Size(62, 15);
            priceLabel.TabIndex = 6;
            priceLabel.Text = "سعر الكيلو:";
            // 
            // dateLabel
            // 
            dateLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dateLabel.AutoSize = true;
            dateLabel.Location = new Point(31, 163);
            dateLabel.Name = "dateLabel";
            dateLabel.RightToLeft = RightToLeft.Yes;
            dateLabel.Size = new Size(41, 15);
            dateLabel.TabIndex = 10;
            dateLabel.Text = "التاريخ:";
            // 
            // totalNumeric
            // 
            totalNumeric.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            totalNumeric.DecimalPlaces = 2;
            totalNumeric.Enabled = false;
            totalNumeric.Location = new Point(105, 128);
            totalNumeric.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            totalNumeric.Name = "totalNumeric";
            totalNumeric.Size = new Size(190, 23);
            totalNumeric.TabIndex = 9;
            // 
            // OrderForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 250);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(dateLabel);
            Controls.Add(totalLabel);
            Controls.Add(priceLabel);
            Controls.Add(weightLabel);
            Controls.Add(itemLabel);
            Controls.Add(clientLabel);
            Controls.Add(datePicker);
            Controls.Add(kiloPriceNumeric);
            Controls.Add(weightNumeric);
            Controls.Add(itemComboBox);
            Controls.Add(clientComboBox);
            Controls.Add(totalNumeric);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "OrderForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "طلب جديد";
            ((System.ComponentModel.ISupportInitialize)weightNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)kiloPriceNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)totalNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox clientComboBox;
        private System.Windows.Forms.ComboBox itemComboBox;
        private System.Windows.Forms.NumericUpDown weightNumeric;
        private System.Windows.Forms.NumericUpDown kiloPriceNumeric;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label clientLabel;
        private System.Windows.Forms.Label itemLabel;
        private System.Windows.Forms.Label weightLabel;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.NumericUpDown totalNumeric;
    }
} 