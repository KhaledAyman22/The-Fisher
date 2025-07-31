namespace TheFisher
{
    partial class ItemsForm
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
            dataGridView = new DataGridView();
            nameTextBox = new TextBox();
            stockNumeric = new NumericUpDown();
            priceNumeric = new NumericUpDown();
            addButton = new Button();
            updateButton = new Button();
            deleteButton = new Button();
            inputPanel = new Panel();
            priceLabel = new Label();
            stockLabel = new Label();
            nameLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)stockNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)priceNumeric).BeginInit();
            inputPanel.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(0, 80);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(1034, 521);
            dataGridView.TabIndex = 0;
            dataGridView.SelectionChanged += DataGridView_SelectionChanged;
            // 
            // nameTextBox
            // 
            nameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nameTextBox.Location = new Point(802, 18);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.RightToLeft = RightToLeft.Yes;
            nameTextBox.Size = new Size(160, 23);
            nameTextBox.TabIndex = 1;
            // 
            // stockNumeric
            // 
            stockNumeric.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            stockNumeric.BackColor = Color.FromArgb(245, 245, 245);
            stockNumeric.DecimalPlaces = 3;
            stockNumeric.Enabled = false;
            stockNumeric.Location = new Point(391, 18);
            stockNumeric.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            stockNumeric.Name = "stockNumeric";
            stockNumeric.ReadOnly = true;
            stockNumeric.Size = new Size(93, 23);
            stockNumeric.TabIndex = 2;
            // 
            // priceNumeric
            // 
            priceNumeric.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            priceNumeric.BackColor = Color.FromArgb(245, 245, 245);
            priceNumeric.DecimalPlaces = 2;
            priceNumeric.Enabled = false;
            priceNumeric.Location = new Point(593, 18);
            priceNumeric.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            priceNumeric.Name = "priceNumeric";
            priceNumeric.ReadOnly = true;
            priceNumeric.Size = new Size(85, 23);
            priceNumeric.TabIndex = 3;
            // 
            // addButton
            // 
            addButton.Location = new Point(20, 11);
            addButton.Name = "addButton";
            addButton.Size = new Size(75, 25);
            addButton.TabIndex = 4;
            addButton.Text = "إضافة";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += AddButton_Click;
            // 
            // updateButton
            // 
            updateButton.Location = new Point(105, 11);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(75, 25);
            updateButton.TabIndex = 5;
            updateButton.Text = "تحديث";
            updateButton.UseVisualStyleBackColor = true;
            updateButton.Click += UpdateButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(190, 11);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(75, 25);
            deleteButton.TabIndex = 6;
            deleteButton.Text = "حذف";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += DeleteButton_Click;
            // 
            // inputPanel
            // 
            inputPanel.BackColor = Color.FromArgb(240, 240, 240);
            inputPanel.Controls.Add(deleteButton);
            inputPanel.Controls.Add(updateButton);
            inputPanel.Controls.Add(addButton);
            inputPanel.Controls.Add(priceNumeric);
            inputPanel.Controls.Add(stockNumeric);
            inputPanel.Controls.Add(nameTextBox);
            inputPanel.Controls.Add(priceLabel);
            inputPanel.Controls.Add(stockLabel);
            inputPanel.Controls.Add(nameLabel);
            inputPanel.Dock = DockStyle.Top;
            inputPanel.Location = new Point(0, 0);
            inputPanel.Name = "inputPanel";
            inputPanel.Padding = new Padding(10);
            inputPanel.Size = new Size(1034, 80);
            inputPanel.TabIndex = 7;
            // 
            // priceLabel
            // 
            priceLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            priceLabel.AutoSize = true;
            priceLabel.ForeColor = Color.Gray;
            priceLabel.Location = new Point(688, 21);
            priceLabel.Name = "priceLabel";
            priceLabel.RightToLeft = RightToLeft.Yes;
            priceLabel.Size = new Size(104, 15);
            priceLabel.TabIndex = 10;
            priceLabel.Text = "متوسط السعر/كجم:";
            // 
            // stockLabel
            // 
            stockLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            stockLabel.AutoSize = true;
            stockLabel.ForeColor = Color.Gray;
            stockLabel.Location = new Point(494, 21);
            stockLabel.Name = "stockLabel";
            stockLabel.RightToLeft = RightToLeft.Yes;
            stockLabel.Size = new Size(80, 15);
            stockLabel.TabIndex = 9;
            stockLabel.Text = "المخزون (كجم):";
            // 
            // nameLabel
            // 
            nameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(968, 21);
            nameLabel.Name = "nameLabel";
            nameLabel.RightToLeft = RightToLeft.Yes;
            nameLabel.Size = new Size(37, 15);
            nameLabel.TabIndex = 8;
            nameLabel.Text = "الاسم:";
            // 
            // ItemsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1034, 601);
            Controls.Add(dataGridView);
            Controls.Add(inputPanel);
            MinimumSize = new Size(1050, 500);
            Name = "ItemsForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "إدارة المنتجات";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)stockNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)priceNumeric).EndInit();
            inputPanel.ResumeLayout(false);
            inputPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.NumericUpDown stockNumeric;
        private System.Windows.Forms.NumericUpDown priceNumeric;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Panel inputPanel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label stockLabel;
        private System.Windows.Forms.Label priceLabel;
    }
} 