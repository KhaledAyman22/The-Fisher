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
            this.components = new System.ComponentModel.Container();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.stockNumeric = new System.Windows.Forms.NumericUpDown();
            this.priceNumeric = new System.Windows.Forms.NumericUpDown();
            this.addButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.inputPanel = new System.Windows.Forms.Panel();
            this.nameLabel = new System.Windows.Forms.Label();
            this.stockLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceNumeric)).BeginInit();
            this.inputPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 80);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(900, 520);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.SelectionChanged += new System.EventHandler(this.DataGridView_SelectionChanged);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(80, 12);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(150, 23);
            this.nameTextBox.TabIndex = 1;
            // 
            // stockNumeric
            // 
            this.stockNumeric.DecimalPlaces = 3;
            this.stockNumeric.Location = new System.Drawing.Point(320, 12);
            this.stockNumeric.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.stockNumeric.Name = "stockNumeric";
            this.stockNumeric.Size = new System.Drawing.Size(100, 23);
            this.stockNumeric.TabIndex = 2;
            // 
            // priceNumeric
            // 
            this.priceNumeric.DecimalPlaces = 2;
            this.priceNumeric.Location = new System.Drawing.Point(530, 12);
            this.priceNumeric.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.priceNumeric.Name = "priceNumeric";
            this.priceNumeric.Size = new System.Drawing.Size(100, 23);
            this.priceNumeric.TabIndex = 3;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(650, 11);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 25);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(730, 11);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 25);
            this.updateButton.TabIndex = 5;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(810, 11);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 25);
            this.deleteButton.TabIndex = 6;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // inputPanel
            // 
            this.inputPanel.Controls.Add(this.priceLabel);
            this.inputPanel.Controls.Add(this.stockLabel);
            this.inputPanel.Controls.Add(this.nameLabel);
            this.inputPanel.Controls.Add(this.deleteButton);
            this.inputPanel.Controls.Add(this.updateButton);
            this.inputPanel.Controls.Add(this.addButton);
            this.inputPanel.Controls.Add(this.priceNumeric);
            this.inputPanel.Controls.Add(this.stockNumeric);
            this.inputPanel.Controls.Add(this.nameTextBox);
            this.inputPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.inputPanel.Location = new System.Drawing.Point(0, 0);
            this.inputPanel.Name = "inputPanel";
            this.inputPanel.Padding = new System.Windows.Forms.Padding(10);
            this.inputPanel.Size = new System.Drawing.Size(900, 80);
            this.inputPanel.TabIndex = 7;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(10, 15);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(42, 15);
            this.nameLabel.TabIndex = 8;
            this.nameLabel.Text = "Name:";
            // 
            // stockLabel
            // 
            this.stockLabel.AutoSize = true;
            this.stockLabel.Location = new System.Drawing.Point(250, 15);
            this.stockLabel.Name = "stockLabel";
            this.stockLabel.Size = new System.Drawing.Size(64, 15);
            this.stockLabel.TabIndex = 9;
            this.stockLabel.Text = "Stock (KG):";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(440, 15);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(84, 15);
            this.priceLabel.TabIndex = 10;
            this.priceLabel.Text = "Avg Price/KG:";
            // 
            // ItemsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.inputPanel);
            this.Name = "ItemsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Items Management";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceNumeric)).EndInit();
            this.inputPanel.ResumeLayout(false);
            this.inputPanel.PerformLayout();
            this.ResumeLayout(false);
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