namespace TheFisher
{
    partial class DealersForm
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
            balanceNumeric = new NumericUpDown();
            addButton = new Button();
            updateButton = new Button();
            deleteButton = new Button();
            inputPanel = new Panel();
            balanceLabel = new Label();
            nameLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)balanceNumeric).BeginInit();
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
            dataGridView.Size = new Size(784, 381);
            dataGridView.TabIndex = 0;
            dataGridView.SelectionChanged += DataGridView_SelectionChanged;
            // 
            // nameTextBox
            // 
            nameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nameTextBox.Location = new Point(561, 12);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.RightToLeft = RightToLeft.Yes;
            nameTextBox.Size = new Size(160, 23);
            nameTextBox.TabIndex = 1;
            // 
            // balanceNumeric
            // 
            balanceNumeric.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            balanceNumeric.DecimalPlaces = 2;
            balanceNumeric.Location = new Point(336, 12);
            balanceNumeric.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            balanceNumeric.Name = "balanceNumeric";
            balanceNumeric.Size = new Size(160, 23);
            balanceNumeric.TabIndex = 2;
            // 
            // addButton
            // 
            addButton.Location = new Point(20, 11);
            addButton.Name = "addButton";
            addButton.Size = new Size(75, 25);
            addButton.TabIndex = 3;
            addButton.Text = "إضافة";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += AddButton_Click;
            // 
            // updateButton
            // 
            updateButton.Location = new Point(105, 11);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(75, 25);
            updateButton.TabIndex = 4;
            updateButton.Text = "تحديث";
            updateButton.UseVisualStyleBackColor = true;
            updateButton.Click += UpdateButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(190, 11);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(75, 25);
            deleteButton.TabIndex = 5;
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
            inputPanel.Controls.Add(balanceNumeric);
            inputPanel.Controls.Add(nameTextBox);
            inputPanel.Controls.Add(balanceLabel);
            inputPanel.Controls.Add(nameLabel);
            inputPanel.Dock = DockStyle.Top;
            inputPanel.Location = new Point(0, 0);
            inputPanel.Name = "inputPanel";
            inputPanel.Padding = new Padding(10);
            inputPanel.Size = new Size(784, 80);
            inputPanel.TabIndex = 6;
            // 
            // balanceLabel
            // 
            balanceLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            balanceLabel.AutoSize = true;
            balanceLabel.Location = new Point(502, 15);
            balanceLabel.Name = "balanceLabel";
            balanceLabel.RightToLeft = RightToLeft.Yes;
            balanceLabel.Size = new Size(43, 15);
            balanceLabel.TabIndex = 8;
            balanceLabel.Text = "الرصيد:";
            // 
            // nameLabel
            // 
            nameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(726, 15);
            nameLabel.Name = "nameLabel";
            nameLabel.RightToLeft = RightToLeft.Yes;
            nameLabel.Size = new Size(37, 15);
            nameLabel.TabIndex = 7;
            nameLabel.Text = "الاسم:";
            // 
            // DealersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(dataGridView);
            Controls.Add(inputPanel);
            MinimumSize = new Size(800, 500);
            Name = "DealersForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "إدارة التجار";
            Load += DealersForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)balanceNumeric).EndInit();
            inputPanel.ResumeLayout(false);
            inputPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.NumericUpDown balanceNumeric;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Panel inputPanel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label balanceLabel;
    }
} 