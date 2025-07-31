namespace TheFisher
{
    partial class ReportsForm
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
            filterComboBox = new ComboBox();
            refreshButton = new Button();
            filterLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(0, 60);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.Size = new Size(800, 540);
            dataGridView.TabIndex = 3;
            // 
            // filterComboBox
            // 
            filterComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            filterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            filterComboBox.FormattingEnabled = true;
            filterComboBox.Location = new Point(67, 15);
            filterComboBox.Name = "filterComboBox";
            filterComboBox.Size = new Size(190, 23);
            filterComboBox.TabIndex = 1;
            filterComboBox.SelectedIndexChanged += FilterComboBox_SelectedIndexChanged;
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(713, 18);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(75, 25);
            refreshButton.TabIndex = 2;
            refreshButton.Text = "تحديث";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += RefreshButton_Click;
            // 
            // filterLabel
            // 
            filterLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            filterLabel.AutoSize = true;
            filterLabel.Location = new Point(25, 18);
            filterLabel.Name = "filterLabel";
            filterLabel.RightToLeft = RightToLeft.Yes;
            filterLabel.Size = new Size(36, 15);
            filterLabel.TabIndex = 0;
            filterLabel.Text = "الفلتر:";
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(refreshButton);
            Controls.Add(filterLabel);
            Controls.Add(filterComboBox);
            Controls.Add(dataGridView);
            Name = "ReportsForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "التقارير";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ComboBox filterComboBox;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Label filterLabel;
    }
} 