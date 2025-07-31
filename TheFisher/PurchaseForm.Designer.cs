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
            this.components = new System.ComponentModel.Container();
            this.dealerComboBox = new System.Windows.Forms.ComboBox();
            this.itemComboBox = new System.Windows.Forms.ComboBox();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.unitsNumeric = new System.Windows.Forms.NumericUpDown();
            this.unitPriceNumeric = new System.Windows.Forms.NumericUpDown();
            this.totalWeightNumeric = new System.Windows.Forms.NumericUpDown();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.dealerLabel = new System.Windows.Forms.Label();
            this.itemLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.unitsLabel = new System.Windows.Forms.Label();
            this.unitPriceLabel = new System.Windows.Forms.Label();
            this.totalWeightLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.unitsNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitPriceNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalWeightNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // dealerLabel
            // 
            this.dealerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dealerLabel.AutoSize = true;
            this.dealerLabel.Location = new System.Drawing.Point(320, 18);
            this.dealerLabel.Name = "dealerLabel";
            this.dealerLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dealerLabel.Size = new System.Drawing.Size(42, 15);
            this.dealerLabel.TabIndex = 0;
            this.dealerLabel.Text = "التاجر:";
            // 
            // dealerComboBox
            // 
            this.dealerComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dealerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dealerComboBox.FormattingEnabled = true;
            this.dealerComboBox.Location = new System.Drawing.Point(120, 15);
            this.dealerComboBox.Name = "dealerComboBox";
            this.dealerComboBox.Size = new System.Drawing.Size(190, 23);
            this.dealerComboBox.TabIndex = 1;
            // 
            // itemLabel
            // 
            this.itemLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.itemLabel.AutoSize = true;
            this.itemLabel.Location = new System.Drawing.Point(320, 47);
            this.itemLabel.Name = "itemLabel";
            this.itemLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.itemLabel.Size = new System.Drawing.Size(42, 15);
            this.itemLabel.TabIndex = 2;
            this.itemLabel.Text = "المنتج:";
            // 
            // itemComboBox
            // 
            this.itemComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.itemComboBox.FormattingEnabled = true;
            this.itemComboBox.Location = new System.Drawing.Point(120, 44);
            this.itemComboBox.Name = "itemComboBox";
            this.itemComboBox.Size = new System.Drawing.Size(190, 23);
            this.itemComboBox.TabIndex = 3;
            // 
            // typeLabel
            // 
            this.typeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(320, 76);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.typeLabel.Size = new System.Drawing.Size(42, 15);
            this.typeLabel.TabIndex = 4;
            this.typeLabel.Text = "النوع:";
            // 
            // typeComboBox
            // 
            this.typeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "كاش",
            "آجل"});
            this.typeComboBox.Location = new System.Drawing.Point(120, 73);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(190, 23);
            this.typeComboBox.TabIndex = 5;
            // 
            // unitsLabel
            // 
            this.unitsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.unitsLabel.AutoSize = true;
            this.unitsLabel.Location = new System.Drawing.Point(320, 105);
            this.unitsLabel.Name = "unitsLabel";
            this.unitsLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.unitsLabel.Size = new System.Drawing.Size(42, 15);
            this.unitsLabel.TabIndex = 6;
            this.unitsLabel.Text = "الوحدات:";
            // 
            // unitsNumeric
            // 
            this.unitsNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.unitsNumeric.DecimalPlaces = 3;
            this.unitsNumeric.Location = new System.Drawing.Point(120, 102);
            this.unitsNumeric.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.unitsNumeric.Name = "unitsNumeric";
            this.unitsNumeric.Size = new System.Drawing.Size(190, 23);
            this.unitsNumeric.TabIndex = 7;
            // 
            // unitPriceLabel
            // 
            this.unitPriceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.unitPriceLabel.AutoSize = true;
            this.unitPriceLabel.Location = new System.Drawing.Point(320, 134);
            this.unitPriceLabel.Name = "unitPriceLabel";
            this.unitPriceLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.unitPriceLabel.Size = new System.Drawing.Size(42, 15);
            this.unitPriceLabel.TabIndex = 8;
            this.unitPriceLabel.Text = "سعر الوحدة:";
            // 
            // unitPriceNumeric
            // 
            this.unitPriceNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.unitPriceNumeric.DecimalPlaces = 2;
            this.unitPriceNumeric.Location = new System.Drawing.Point(120, 131);
            this.unitPriceNumeric.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.unitPriceNumeric.Name = "unitPriceNumeric";
            this.unitPriceNumeric.Size = new System.Drawing.Size(190, 23);
            this.unitPriceNumeric.TabIndex = 9;
            // 
            // totalWeightLabel
            // 
            this.totalWeightLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalWeightLabel.AutoSize = true;
            this.totalWeightLabel.Location = new System.Drawing.Point(320, 163);
            this.totalWeightLabel.Name = "totalWeightLabel";
            this.totalWeightLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.totalWeightLabel.Size = new System.Drawing.Size(42, 15);
            this.totalWeightLabel.TabIndex = 10;
            this.totalWeightLabel.Text = "الوزن الإجمالي:";
            // 
            // totalWeightNumeric
            // 
            this.totalWeightNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalWeightNumeric.DecimalPlaces = 3;
            this.totalWeightNumeric.Location = new System.Drawing.Point(120, 160);
            this.totalWeightNumeric.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.totalWeightNumeric.Name = "totalWeightNumeric";
            this.totalWeightNumeric.Size = new System.Drawing.Size(190, 23);
            this.totalWeightNumeric.TabIndex = 11;
            // 
            // dateLabel
            // 
            this.dateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(320, 192);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateLabel.Size = new System.Drawing.Size(42, 15);
            this.dateLabel.TabIndex = 12;
            this.dateLabel.Text = "التاريخ:";
            // 
            // datePicker
            // 
            this.datePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datePicker.Location = new System.Drawing.Point(120, 189);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(190, 23);
            this.datePicker.TabIndex = 13;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.Location = new System.Drawing.Point(20, 230);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 25);
            this.saveButton.TabIndex = 14;
            this.saveButton.Text = "حفظ";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelButton.Location = new System.Drawing.Point(105, 230);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 25);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "إلغاء";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // PurchaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 280);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.totalWeightLabel);
            this.Controls.Add(this.unitPriceLabel);
            this.Controls.Add(this.unitsLabel);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.itemLabel);
            this.Controls.Add(this.dealerLabel);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.totalWeightNumeric);
            this.Controls.Add(this.unitPriceNumeric);
            this.Controls.Add(this.unitsNumeric);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.itemComboBox);
            this.Controls.Add(this.dealerComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PurchaseForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "شراء جديد";
            ((System.ComponentModel.ISupportInitialize)(this.unitsNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitPriceNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalWeightNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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
    }
} 