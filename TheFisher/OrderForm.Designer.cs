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
            this.components = new System.ComponentModel.Container();
            this.clientComboBox = new System.Windows.Forms.ComboBox();
            this.itemComboBox = new System.Windows.Forms.ComboBox();
            this.weightNumeric = new System.Windows.Forms.NumericUpDown();
            this.kiloPriceNumeric = new System.Windows.Forms.NumericUpDown();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.totalLabel = new System.Windows.Forms.Label();
            this.clientLabel = new System.Windows.Forms.Label();
            this.itemLabel = new System.Windows.Forms.Label();
            this.weightLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.totalNumeric = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.weightNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kiloPriceNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // clientLabel
            // 
            this.clientLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clientLabel.AutoSize = true;
            this.clientLabel.Location = new System.Drawing.Point(320, 18);
            this.clientLabel.Name = "clientLabel";
            this.clientLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.clientLabel.Size = new System.Drawing.Size(42, 15);
            this.clientLabel.TabIndex = 0;
            this.clientLabel.Text = "العميل:";
            // 
            // clientComboBox
            // 
            this.clientComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clientComboBox.FormattingEnabled = true;
            this.clientComboBox.Location = new System.Drawing.Point(120, 15);
            this.clientComboBox.Name = "clientComboBox";
            this.clientComboBox.Size = new System.Drawing.Size(190, 23);
            this.clientComboBox.TabIndex = 1;
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
            // weightLabel
            // 
            this.weightLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.weightLabel.AutoSize = true;
            this.weightLabel.Location = new System.Drawing.Point(320, 76);
            this.weightLabel.Name = "weightLabel";
            this.weightLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.weightLabel.Size = new System.Drawing.Size(42, 15);
            this.weightLabel.TabIndex = 4;
            this.weightLabel.Text = "الوزن:";
            // 
            // weightNumeric
            // 
            this.weightNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.weightNumeric.DecimalPlaces = 3;
            this.weightNumeric.Location = new System.Drawing.Point(120, 73);
            this.weightNumeric.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.weightNumeric.Name = "weightNumeric";
            this.weightNumeric.Size = new System.Drawing.Size(190, 23);
            this.weightNumeric.TabIndex = 5;
            this.weightNumeric.ValueChanged += new System.EventHandler(this.WeightNumeric_ValueChanged);
            // 
            // priceLabel
            // 
            this.priceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(320, 105);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.priceLabel.Size = new System.Drawing.Size(42, 15);
            this.priceLabel.TabIndex = 6;
            this.priceLabel.Text = "سعر الكيلو:";
            // 
            // kiloPriceNumeric
            // 
            this.kiloPriceNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kiloPriceNumeric.DecimalPlaces = 2;
            this.kiloPriceNumeric.Location = new System.Drawing.Point(120, 102);
            this.kiloPriceNumeric.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.kiloPriceNumeric.Name = "kiloPriceNumeric";
            this.kiloPriceNumeric.Size = new System.Drawing.Size(190, 23);
            this.kiloPriceNumeric.TabIndex = 7;
            this.kiloPriceNumeric.ValueChanged += new System.EventHandler(this.KiloPriceNumeric_ValueChanged);
            // 
            // totalLabel
            // 
            this.totalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalLabel.AutoSize = true;
            this.totalLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.totalLabel.Location = new System.Drawing.Point(320, 134);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.totalLabel.Size = new System.Drawing.Size(42, 15);
            this.totalLabel.TabIndex = 8;
            this.totalLabel.Text = "المجموع:";
            // 
            // totalNumeric
            // 
            this.totalNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalNumeric.DecimalPlaces = 2;
            this.totalNumeric.Enabled = false;
            this.totalNumeric.Location = new System.Drawing.Point(120, 131);
            this.totalNumeric.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.totalNumeric.Name = "totalNumeric";
            this.totalNumeric.Size = new System.Drawing.Size(190, 23);
            this.totalNumeric.TabIndex = 9;
            // 
            // dateLabel
            // 
            this.dateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(320, 163);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateLabel.Size = new System.Drawing.Size(42, 15);
            this.dateLabel.TabIndex = 10;
            this.dateLabel.Text = "التاريخ:";
            // 
            // datePicker
            // 
            this.datePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datePicker.Location = new System.Drawing.Point(120, 160);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(190, 23);
            this.datePicker.TabIndex = 11;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.Location = new System.Drawing.Point(20, 200);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 25);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "حفظ";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelButton.Location = new System.Drawing.Point(105, 200);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 25);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "إلغاء";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.weightLabel);
            this.Controls.Add(this.itemLabel);
            this.Controls.Add(this.clientLabel);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.kiloPriceNumeric);
            this.Controls.Add(this.weightNumeric);
            this.Controls.Add(this.itemComboBox);
            this.Controls.Add(this.clientComboBox);
            this.Controls.Add(this.totalNumeric);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "طلب جديد";
            ((System.ComponentModel.ISupportInitialize)(this.weightNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kiloPriceNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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