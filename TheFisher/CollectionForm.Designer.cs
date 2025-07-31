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
            this.components = new System.ComponentModel.Container();
            this.clientComboBox = new System.Windows.Forms.ComboBox();
            this.amountNumeric = new System.Windows.Forms.NumericUpDown();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.ordersGridView = new System.Windows.Forms.DataGridView();
            this.clientLabel = new System.Windows.Forms.Label();
            this.amountLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.ordersLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.amountNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersGridView)).BeginInit();
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
            this.clientComboBox.SelectedIndexChanged += new System.EventHandler(this.ClientComboBox_SelectedIndexChanged);
            // 
            // amountNumeric
            // 
            this.amountNumeric.DecimalPlaces = 2;
            this.amountNumeric.Location = new System.Drawing.Point(120, 60);
            this.amountNumeric.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.amountNumeric.Name = "amountNumeric";
            this.amountNumeric.Size = new System.Drawing.Size(100, 23);
            this.amountNumeric.TabIndex = 1;
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(120, 100);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(200, 23);
            this.datePicker.TabIndex = 2;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(12, 131);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 25);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "حفظ";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(93, 131);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 25);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "إلغاء";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ordersGridView
            // 
            this.ordersGridView.AllowUserToAddRows = false;
            this.ordersGridView.AllowUserToDeleteRows = false;
            this.ordersGridView.AutoGenerateColumns = false;
            this.ordersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ordersGridView.Location = new System.Drawing.Point(20, 200);
            this.ordersGridView.MultiSelect = false;
            this.ordersGridView.Name = "ordersGridView";
            this.ordersGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ordersGridView.Size = new System.Drawing.Size(600, 200);
            this.ordersGridView.TabIndex = 5;
            // 
            // clientLabel
            // 
            this.clientLabel.AutoSize = true;
            this.clientLabel.Location = new System.Drawing.Point(12, 15);
            this.clientLabel.Name = "clientLabel";
            this.clientLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.clientLabel.Size = new System.Drawing.Size(42, 15);
            this.clientLabel.TabIndex = 0;
            this.clientLabel.Text = "العميل:";
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Location = new System.Drawing.Point(12, 44);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.amountLabel.Size = new System.Drawing.Size(42, 15);
            this.amountLabel.TabIndex = 2;
            this.amountLabel.Text = "المبلغ:";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(12, 73);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateLabel.Size = new System.Drawing.Size(42, 15);
            this.dateLabel.TabIndex = 4;
            this.dateLabel.Text = "التاريخ:";
            // 
            // ordersLabel
            // 
            this.ordersLabel.AutoSize = true;
            this.ordersLabel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ordersLabel.Location = new System.Drawing.Point(12, 102);
            this.ordersLabel.Name = "ordersLabel";
            this.ordersLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ordersLabel.Size = new System.Drawing.Size(42, 15);
            this.ordersLabel.TabIndex = 6;
            this.ordersLabel.Text = "الطلبات:";
            // 
            // CollectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.ordersLabel);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.amountLabel);
            this.Controls.Add(this.clientLabel);
            this.Controls.Add(this.ordersGridView);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.amountNumeric);
            this.Controls.Add(this.clientComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CollectionForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تحصيل جديد";
            ((System.ComponentModel.ISupportInitialize)(this.amountNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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