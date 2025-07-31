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
            this.components = new System.ComponentModel.Container();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.balanceNumeric = new System.Windows.Forms.NumericUpDown();
            this.addButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.inputPanel = new System.Windows.Forms.Panel();
            this.nameLabel = new System.Windows.Forms.Label();
            this.balanceLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.balanceNumeric)).BeginInit();
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
            this.dataGridView.Size = new System.Drawing.Size(800, 520);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.SelectionChanged += new System.EventHandler(this.DataGridView_SelectionChanged);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(80, 12);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(200, 23);
            this.nameTextBox.TabIndex = 1;
            // 
            // balanceNumeric
            // 
            this.balanceNumeric.DecimalPlaces = 2;
            this.balanceNumeric.Location = new System.Drawing.Point(360, 12);
            this.balanceNumeric.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.balanceNumeric.Name = "balanceNumeric";
            this.balanceNumeric.Size = new System.Drawing.Size(100, 23);
            this.balanceNumeric.TabIndex = 2;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(480, 11);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 25);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(560, 11);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 25);
            this.updateButton.TabIndex = 4;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(640, 11);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 25);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // inputPanel
            // 
            this.inputPanel.Controls.Add(this.balanceLabel);
            this.inputPanel.Controls.Add(this.nameLabel);
            this.inputPanel.Controls.Add(this.deleteButton);
            this.inputPanel.Controls.Add(this.updateButton);
            this.inputPanel.Controls.Add(this.addButton);
            this.inputPanel.Controls.Add(this.balanceNumeric);
            this.inputPanel.Controls.Add(this.nameTextBox);
            this.inputPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.inputPanel.Location = new System.Drawing.Point(0, 0);
            this.inputPanel.Name = "inputPanel";
            this.inputPanel.Padding = new System.Windows.Forms.Padding(10);
            this.inputPanel.Size = new System.Drawing.Size(800, 80);
            this.inputPanel.TabIndex = 6;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(10, 15);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(42, 15);
            this.nameLabel.TabIndex = 7;
            this.nameLabel.Text = "Name:";
            // 
            // balanceLabel
            // 
            this.balanceLabel.AutoSize = true;
            this.balanceLabel.Location = new System.Drawing.Point(300, 15);
            this.balanceLabel.Name = "balanceLabel";
            this.balanceLabel.Size = new System.Drawing.Size(54, 15);
            this.balanceLabel.TabIndex = 8;
            this.balanceLabel.Text = "Balance:";
            // 
            // DealersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.inputPanel);
            this.Name = "DealersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dealers Management";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.balanceNumeric)).EndInit();
            this.inputPanel.ResumeLayout(false);
            this.inputPanel.PerformLayout();
            this.ResumeLayout(false);
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