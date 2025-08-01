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
            dealerComboBox = new ComboBox();
            itemComboBox = new ComboBox();
            typeComboBox = new ComboBox();
            unitsNumeric = new NumericUpDown();
            unitPriceNumeric = new NumericUpDown();
            totalWeightNumeric = new NumericUpDown();
            datePicker = new DateTimePicker();
            saveButton = new Button();
            cancelButton = new Button();
            dealerLabel = new Label();
            itemLabel = new Label();
            typeLabel = new Label();
            unitsLabel = new Label();
            unitPriceLabel = new Label();
            totalWeightLabel = new Label();
            dateLabel = new Label();
            taxLabel = new Label();
            taxNumeric = new NumericUpDown();
            transportaionNumeric = new NumericUpDown();
            transportaionLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)unitsNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)unitPriceNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)totalWeightNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)taxNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)transportaionNumeric).BeginInit();
            SuspendLayout();
            // 
            // dealerComboBox
            // 
            dealerComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dealerComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            dealerComboBox.FormattingEnabled = true;
            dealerComboBox.Location = new Point(120, 15);
            dealerComboBox.Name = "dealerComboBox";
            dealerComboBox.Size = new Size(190, 23);
            dealerComboBox.TabIndex = 1;
            // 
            // itemComboBox
            // 
            itemComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            itemComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            itemComboBox.FormattingEnabled = true;
            itemComboBox.Location = new Point(120, 44);
            itemComboBox.Name = "itemComboBox";
            itemComboBox.Size = new Size(190, 23);
            itemComboBox.TabIndex = 3;
            // 
            // typeComboBox
            // 
            typeComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            typeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            typeComboBox.FormattingEnabled = true;
            typeComboBox.Items.AddRange(new object[] { "كاش", "آجل" });
            typeComboBox.SelectedIndex = 1;
            typeComboBox.Location = new Point(120, 73);
            typeComboBox.Name = "typeComboBox";
            typeComboBox.Size = new Size(190, 23);
            typeComboBox.TabIndex = 5;
            typeComboBox.SelectedIndexChanged += TypeComboBox_SelectedIndexChanged;
            // 
            // unitsNumeric
            // 
            unitsNumeric.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            unitsNumeric.DecimalPlaces = 3;
            unitsNumeric.Location = new Point(120, 102);
            unitsNumeric.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            unitsNumeric.Name = "unitsNumeric";
            unitsNumeric.Size = new Size(190, 23);
            unitsNumeric.TabIndex = 7;
            // 
            // unitPriceNumeric
            // 
            unitPriceNumeric.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            unitPriceNumeric.DecimalPlaces = 2;
            unitPriceNumeric.Location = new Point(120, 131);
            unitPriceNumeric.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            unitPriceNumeric.Name = "unitPriceNumeric";
            unitPriceNumeric.Size = new Size(190, 23);
            unitPriceNumeric.TabIndex = 9;
            // 
            // totalWeightNumeric
            // 
            totalWeightNumeric.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            totalWeightNumeric.DecimalPlaces = 3;
            totalWeightNumeric.Location = new Point(120, 160);
            totalWeightNumeric.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            totalWeightNumeric.Name = "totalWeightNumeric";
            totalWeightNumeric.Size = new Size(190, 23);
            totalWeightNumeric.TabIndex = 11;
            // 
            // datePicker
            // 
            datePicker.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            datePicker.Location = new Point(120, 245);
            datePicker.Name = "datePicker";
            datePicker.Size = new Size(190, 23);
            datePicker.Format = DateTimePickerFormat.Custom;
            datePicker.CustomFormat = "dd/MM/yyyy";
            datePicker.RightToLeft = RightToLeft.Yes;
            datePicker.RightToLeftLayout = true;
            datePicker.TabIndex = 13;
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            saveButton.Location = new Point(20, 292);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 25);
            saveButton.TabIndex = 14;
            saveButton.Text = "حفظ";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += SaveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cancelButton.Location = new Point(105, 292);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 25);
            cancelButton.TabIndex = 15;
            cancelButton.Text = "إلغاء";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += CancelButton_Click;
            // 
            // dealerLabel
            // 
            dealerLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dealerLabel.AutoSize = true;
            dealerLabel.Location = new Point(30, 18);
            dealerLabel.Name = "dealerLabel";
            dealerLabel.RightToLeft = RightToLeft.Yes;
            dealerLabel.Size = new Size(36, 15);
            dealerLabel.TabIndex = 0;
            dealerLabel.Text = "التاجر:";
            // 
            // itemLabel
            // 
            itemLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            itemLabel.AutoSize = true;
            itemLabel.Location = new Point(30, 47);
            itemLabel.Name = "itemLabel";
            itemLabel.RightToLeft = RightToLeft.Yes;
            itemLabel.Size = new Size(39, 15);
            itemLabel.TabIndex = 2;
            itemLabel.Text = "المنتج:";
            // 
            // typeLabel
            // 
            typeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            typeLabel.AutoSize = true;
            typeLabel.Location = new Point(30, 76);
            typeLabel.Name = "typeLabel";
            typeLabel.RightToLeft = RightToLeft.Yes;
            typeLabel.Size = new Size(34, 15);
            typeLabel.TabIndex = 4;
            typeLabel.Text = "النوع:";
            // 
            // unitsLabel
            // 
            unitsLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            unitsLabel.AutoSize = true;
            unitsLabel.Location = new Point(30, 105);
            unitsLabel.Name = "unitsLabel";
            unitsLabel.RightToLeft = RightToLeft.Yes;
            unitsLabel.Size = new Size(50, 15);
            unitsLabel.TabIndex = 6;
            unitsLabel.Text = "الوحدات:";
            // 
            // unitPriceLabel
            // 
            unitPriceLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            unitPriceLabel.AutoSize = true;
            unitPriceLabel.Location = new Point(30, 134);
            unitPriceLabel.Name = "unitPriceLabel";
            unitPriceLabel.RightToLeft = RightToLeft.Yes;
            unitPriceLabel.Size = new Size(67, 15);
            unitPriceLabel.TabIndex = 8;
            unitPriceLabel.Text = "سعر الوحدة:";
            // 
            // totalWeightLabel
            // 
            totalWeightLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            totalWeightLabel.AutoSize = true;
            totalWeightLabel.Location = new Point(30, 163);
            totalWeightLabel.Name = "totalWeightLabel";
            totalWeightLabel.RightToLeft = RightToLeft.Yes;
            totalWeightLabel.Size = new Size(80, 15);
            totalWeightLabel.TabIndex = 10;
            totalWeightLabel.Text = "الوزن الإجمالي:";
            // 
            // dateLabel
            // 
            dateLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dateLabel.AutoSize = true;
            dateLabel.Location = new Point(30, 245);
            dateLabel.Name = "dateLabel";
            dateLabel.RightToLeft = RightToLeft.Yes;
            dateLabel.Size = new Size(41, 15);
            dateLabel.TabIndex = 12;
            dateLabel.Text = "التاريخ:";
            // 
            // taxLabel
            // 
            taxLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            taxLabel.AutoSize = true;
            taxLabel.Location = new Point(30, 219);
            taxLabel.Name = "taxLabel";
            taxLabel.RightToLeft = RightToLeft.Yes;
            taxLabel.Size = new Size(22, 15);
            taxLabel.TabIndex = 16;
            taxLabel.Text = "جر:";
            // 
            // taxNumeric
            // 
            taxNumeric.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            taxNumeric.DecimalPlaces = 3;
            taxNumeric.Enabled = false;
            taxNumeric.Location = new Point(120, 217);
            taxNumeric.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            taxNumeric.Name = "taxNumeric";
            taxNumeric.Size = new Size(190, 23);
            taxNumeric.TabIndex = 17;
            // 
            // transportaionNumeric
            // 
            transportaionNumeric.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            transportaionNumeric.DecimalPlaces = 3;
            transportaionNumeric.Enabled = true;
            transportaionNumeric.Location = new Point(120, 189);
            transportaionNumeric.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            transportaionNumeric.Name = "transportaionNumeric";
            transportaionNumeric.Size = new Size(190, 23);
            transportaionNumeric.TabIndex = 19;
            // 
            // transportaionLabel
            // 
            transportaionLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            transportaionLabel.AutoSize = true;
            transportaionLabel.Location = new Point(30, 191);
            transportaionLabel.Name = "transportaionLabel";
            transportaionLabel.RightToLeft = RightToLeft.Yes;
            transportaionLabel.Size = new Size(38, 15);
            transportaionLabel.TabIndex = 18;
            transportaionLabel.Text = "نولون:";
            // 
            // PurchaseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 342);
            Controls.Add(transportaionNumeric);
            Controls.Add(transportaionLabel);
            Controls.Add(taxNumeric);
            Controls.Add(taxLabel);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(dateLabel);
            Controls.Add(totalWeightLabel);
            Controls.Add(unitPriceLabel);
            Controls.Add(unitsLabel);
            Controls.Add(typeLabel);
            Controls.Add(itemLabel);
            Controls.Add(dealerLabel);
            Controls.Add(datePicker);
            Controls.Add(totalWeightNumeric);
            Controls.Add(unitPriceNumeric);
            Controls.Add(unitsNumeric);
            Controls.Add(typeComboBox);
            Controls.Add(itemComboBox);
            Controls.Add(dealerComboBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PurchaseForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "شراء جديد";
            ((System.ComponentModel.ISupportInitialize)unitsNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)unitPriceNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)totalWeightNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)taxNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)transportaionNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox dealerComboBox;
        private System.Windows.Forms.ComboBox itemComboBox;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.NumericUpDown unitsNumeric;
        private System.Windows.Forms.NumericUpDown unitPriceNumeric;
        private System.Windows.Forms.NumericUpDown totalWeightNumeric;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label dealerLabel;
        private System.Windows.Forms.Label itemLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label unitsLabel;
        private System.Windows.Forms.Label unitPriceLabel;
        private System.Windows.Forms.Label totalWeightLabel;
        private System.Windows.Forms.Label dateLabel;
        private Label taxLabel;
        private NumericUpDown taxNumeric;
        private NumericUpDown transportaionNumeric;
        private Label transportaionLabel;
    }
} 