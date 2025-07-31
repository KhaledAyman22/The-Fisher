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
            // dealerComboBox
            // 
            this.dealerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dealerComboBox.FormattingEnabled = true;
            this.dealerComboBox.Location = new System.Drawing.Point(120, 20);
            this.dealerComboBox.Name = "dealerComboBox";
            this.dealerComboBox.Size = new System.Drawing.Size(200, 23);
            this.dealerComboBox.TabIndex = 0;
            // 
            // itemComboBox
            // 
            this.itemComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.itemComboBox.FormattingEnabled = true;
            this.itemComboBox.Location = new System.Drawing.Point(120, 60);
            this.itemComboBox.Name = "itemComboBox";
            this.itemComboBox.Size = new System.Drawing.Size(200, 23);
            this.itemComboBox.TabIndex = 1;
            // 
            // typeComboBox
            // 
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Location = new System.Drawing.Point(120, 100);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(200, 23);
            this.typeComboBox.TabIndex = 2;
            this.typeComboBox.SelectedIndexChanged += new System.EventHandler(this.TypeComboBox_SelectedIndexChanged);
            // 
            // unitsNumeric
            // 
            this.unitsNumeric.Location = new System.Drawing.Point(120, 140);
            this.unitsNumeric.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.unitsNumeric.Name = "unitsNumeric";
            this.unitsNumeric.Size = new System.Drawing.Size(100, 23);
            this.unitsNumeric.TabIndex = 3;
            // 
            // unitPriceNumeric
            // 
            this.unitPriceNumeric.DecimalPlaces = 2;
            this.unitPriceNumeric.Location = new System.Drawing.Point(120, 180);
            this.unitPriceNumeric.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.unitPriceNumeric.Name = "unitPriceNumeric";
            this.unitPriceNumeric.Size = new System.Drawing.Size(100, 23);
            this.unitPriceNumeric.TabIndex = 4;
            // 
            // totalWeightNumeric
            // 
            this.totalWeightNumeric.DecimalPlaces = 3;
            this.totalWeightNumeric.Location = new System.Drawing.Point(120, 220);
            this.totalWeightNumeric.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.totalWeightNumeric.Name = "totalWeightNumeric";
            this.totalWeightNumeric.Size = new System.Drawing.Size(100, 23);
            this.totalWeightNumeric.TabIndex = 5;
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(120, 260);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(200, 23);
            this.datePicker.TabIndex = 6;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(120, 300);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 25);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(210, 300);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 25);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // dealerLabel
            // 
            this.dealerLabel.AutoSize = true;
            this.dealerLabel.Location = new System.Drawing.Point(20, 23);
            this.dealerLabel.Name = "dealerLabel";
            this.dealerLabel.Size = new System.Drawing.Size(44, 15);
            this.dealerLabel.TabIndex = 9;
            this.dealerLabel.Text = "Dealer:";
            // 
            // itemLabel
            // 
            this.itemLabel.AutoSize = true;
            this.itemLabel.Location = new System.Drawing.Point(20, 63);
            this.itemLabel.Name = "itemLabel";
            this.itemLabel.Size = new System.Drawing.Size(35, 15);
            this.itemLabel.TabIndex = 10;
            this.itemLabel.Text = "Item:";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(20, 103);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(34, 15);
            this.typeLabel.TabIndex = 11;
            this.typeLabel.Text = "Type:";
            // 
            // unitsLabel
            // 
            this.unitsLabel.AutoSize = true;
            this.unitsLabel.Location = new System.Drawing.Point(20, 143);
            this.unitsLabel.Name = "unitsLabel";
            this.unitsLabel.Size = new System.Drawing.Size(38, 15);
            this.unitsLabel.TabIndex = 12;
            this.unitsLabel.Text = "Units:";
            // 
            // unitPriceLabel
            // 
            this.unitPriceLabel.AutoSize = true;
            this.unitPriceLabel.Location = new System.Drawing.Point(20, 183);
            this.unitPriceLabel.Name = "unitPriceLabel";
            this.unitPriceLabel.Size = new System.Drawing.Size(67, 15);
            this.unitPriceLabel.TabIndex = 13;
            this.unitPriceLabel.Text = "Unit Price:";
            // 
            // totalWeightLabel
            // 
            this.totalWeightLabel.AutoSize = true;
            this.totalWeightLabel.Location = new System.Drawing.Point(20, 223);
            this.totalWeightLabel.Name = "totalWeightLabel";
            this.totalWeightLabel.Size = new System.Drawing.Size(82, 15);
            this.totalWeightLabel.TabIndex = 14;
            this.totalWeightLabel.Text = "Total Weight:";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(20, 263);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(34, 15);
            this.dateLabel.TabIndex = 15;
            this.dateLabel.Text = "Date:";
            // 
            // PurchaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 350);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.totalWeightLabel);
            this.Controls.Add(this.unitPriceLabel);
            this.Controls.Add(this.unitsLabel);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.itemLabel);
            this.Controls.Add(this.dealerLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.totalWeightNumeric);
            this.Controls.Add(this.unitPriceNumeric);
            this.Controls.Add(this.unitsNumeric);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.itemComboBox);
            this.Controls.Add(this.dealerComboBox);
            this.Name = "PurchaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Purchase";
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