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
            ((System.ComponentModel.ISupportInitialize)(this.weightNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kiloPriceNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // clientComboBox
            // 
            this.clientComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clientComboBox.FormattingEnabled = true;
            this.clientComboBox.Location = new System.Drawing.Point(120, 20);
            this.clientComboBox.Name = "clientComboBox";
            this.clientComboBox.Size = new System.Drawing.Size(200, 23);
            this.clientComboBox.TabIndex = 0;
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
            // weightNumeric
            // 
            this.weightNumeric.DecimalPlaces = 3;
            this.weightNumeric.Location = new System.Drawing.Point(120, 100);
            this.weightNumeric.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.weightNumeric.Name = "weightNumeric";
            this.weightNumeric.Size = new System.Drawing.Size(100, 23);
            this.weightNumeric.TabIndex = 2;
            this.weightNumeric.ValueChanged += new System.EventHandler(this.WeightNumeric_ValueChanged);
            // 
            // kiloPriceNumeric
            // 
            this.kiloPriceNumeric.DecimalPlaces = 2;
            this.kiloPriceNumeric.Location = new System.Drawing.Point(120, 140);
            this.kiloPriceNumeric.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.kiloPriceNumeric.Name = "kiloPriceNumeric";
            this.kiloPriceNumeric.Size = new System.Drawing.Size(100, 23);
            this.kiloPriceNumeric.TabIndex = 3;
            this.kiloPriceNumeric.ValueChanged += new System.EventHandler(this.KiloPriceNumeric_ValueChanged);
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(120, 180);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(200, 23);
            this.datePicker.TabIndex = 4;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(120, 220);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 25);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(210, 220);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 25);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.totalLabel.Location = new System.Drawing.Point(120, 260);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(48, 21);
            this.totalLabel.TabIndex = 7;
            this.totalLabel.Text = "Total:";
            // 
            // clientLabel
            // 
            this.clientLabel.AutoSize = true;
            this.clientLabel.Location = new System.Drawing.Point(20, 23);
            this.clientLabel.Name = "clientLabel";
            this.clientLabel.Size = new System.Drawing.Size(41, 15);
            this.clientLabel.TabIndex = 8;
            this.clientLabel.Text = "Client:";
            // 
            // itemLabel
            // 
            this.itemLabel.AutoSize = true;
            this.itemLabel.Location = new System.Drawing.Point(20, 63);
            this.itemLabel.Name = "itemLabel";
            this.itemLabel.Size = new System.Drawing.Size(35, 15);
            this.itemLabel.TabIndex = 9;
            this.itemLabel.Text = "Item:";
            // 
            // weightLabel
            // 
            this.weightLabel.AutoSize = true;
            this.weightLabel.Location = new System.Drawing.Point(20, 103);
            this.weightLabel.Name = "weightLabel";
            this.weightLabel.Size = new System.Drawing.Size(48, 15);
            this.weightLabel.TabIndex = 10;
            this.weightLabel.Text = "Weight:";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(20, 143);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(67, 15);
            this.priceLabel.TabIndex = 11;
            this.priceLabel.Text = "Price/KG:";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(20, 183);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(34, 15);
            this.dateLabel.TabIndex = 12;
            this.dateLabel.Text = "Date:";
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.weightLabel);
            this.Controls.Add(this.itemLabel);
            this.Controls.Add(this.clientLabel);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.kiloPriceNumeric);
            this.Controls.Add(this.weightNumeric);
            this.Controls.Add(this.itemComboBox);
            this.Controls.Add(this.clientComboBox);
            this.Name = "OrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Order";
            ((System.ComponentModel.ISupportInitialize)(this.weightNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kiloPriceNumeric)).EndInit();
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
    }
} 