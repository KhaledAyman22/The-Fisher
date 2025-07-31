namespace TheFisher
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;



        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip = new MenuStrip();
            masterDataMenuItem = new ToolStripMenuItem();
            dealersMenuItem = new ToolStripMenuItem();
            clientsMenuItem = new ToolStripMenuItem();
            itemsMenuItem = new ToolStripMenuItem();
            transactionsMenuItem = new ToolStripMenuItem();
            newPurchaseMenuItem = new ToolStripMenuItem();
            newOrderMenuItem = new ToolStripMenuItem();
            newCollectionMenuItem = new ToolStripMenuItem();
            reportsMenuItem = new ToolStripMenuItem();
            todaysPurchasesMenuItem = new ToolStripMenuItem();
            todaysCollectionsMenuItem = new ToolStripMenuItem();
            purchasesByDealerMenuItem = new ToolStripMenuItem();
            collectionsByClientMenuItem = new ToolStripMenuItem();
            dashboardPanel = new Panel();
            statsPanel = new Panel();
            collectionsCard = new Panel();
            collectionsTitleLabel = new Label();
            collectionsLabel = new Label();
            clientsCard = new Panel();
            clientsTitleLabel = new Label();
            clientsOweLabel = new Label();
            dealersCard = new Panel();
            dealersTitleLabel = new Label();
            owedToDealersLabel = new Label();
            revenueCard = new Panel();
            revenueTitleLabel = new Label();
            revenueLabel = new Label();
            dateLabel = new Label();
            titleLabel = new Label();
            menuStrip.SuspendLayout();
            dashboardPanel.SuspendLayout();
            statsPanel.SuspendLayout();
            collectionsCard.SuspendLayout();
            clientsCard.SuspendLayout();
            dealersCard.SuspendLayout();
            revenueCard.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { masterDataMenuItem, transactionsMenuItem, reportsMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(7, 3, 0, 3);
            menuStrip.Size = new Size(1600, 30);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip";
            // 
            // masterDataMenuItem
            // 
            masterDataMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dealersMenuItem, clientsMenuItem, itemsMenuItem });
            masterDataMenuItem.Name = "masterDataMenuItem";
            masterDataMenuItem.Size = new Size(104, 24);
            masterDataMenuItem.Text = "البيانات الأساسية";
            // 
            // dealersMenuItem
            // 
            dealersMenuItem.Name = "dealersMenuItem";
            dealersMenuItem.Size = new Size(142, 26);
            dealersMenuItem.Text = "التجار";
            dealersMenuItem.Click += ShowDealersForm;
            // 
            // clientsMenuItem
            // 
            clientsMenuItem.Name = "clientsMenuItem";
            clientsMenuItem.Size = new Size(142, 26);
            clientsMenuItem.Text = "العملاء";
            clientsMenuItem.Click += ShowClientsForm;
            // 
            // itemsMenuItem
            // 
            itemsMenuItem.Name = "itemsMenuItem";
            itemsMenuItem.Size = new Size(142, 26);
            itemsMenuItem.Text = "المنتجات";
            itemsMenuItem.Click += ShowItemsForm;
            // 
            // transactionsMenuItem
            // 
            transactionsMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newPurchaseMenuItem, newOrderMenuItem, newCollectionMenuItem });
            transactionsMenuItem.Name = "transactionsMenuItem";
            transactionsMenuItem.Size = new Size(104, 24);
            transactionsMenuItem.Text = "المعاملات";
            // 
            // newPurchaseMenuItem
            // 
            newPurchaseMenuItem.Name = "newPurchaseMenuItem";
            newPurchaseMenuItem.Size = new Size(193, 26);
            newPurchaseMenuItem.Text = "شراء جديد";
            newPurchaseMenuItem.Click += ShowPurchaseForm;
            // 
            // newOrderMenuItem
            // 
            newOrderMenuItem.Name = "newOrderMenuItem";
            newOrderMenuItem.Size = new Size(193, 26);
            newOrderMenuItem.Text = "طلب جديد";
            newOrderMenuItem.Click += ShowOrderForm;
            // 
            // newCollectionMenuItem
            // 
            newCollectionMenuItem.Name = "newCollectionMenuItem";
            newCollectionMenuItem.Size = new Size(193, 26);
            newCollectionMenuItem.Text = "تحصيل جديد";
            newCollectionMenuItem.Click += ShowCollectionForm;
            // 
            // reportsMenuItem
            // 
            reportsMenuItem.DropDownItems.AddRange(new ToolStripItem[] { todaysPurchasesMenuItem, todaysCollectionsMenuItem, purchasesByDealerMenuItem, collectionsByClientMenuItem });
            reportsMenuItem.Name = "reportsMenuItem";
            reportsMenuItem.Size = new Size(74, 24);
            reportsMenuItem.Text = "التقارير";
            // 
            // todaysPurchasesMenuItem
            // 
            todaysPurchasesMenuItem.Name = "todaysPurchasesMenuItem";
            todaysPurchasesMenuItem.Size = new Size(227, 26);
            todaysPurchasesMenuItem.Text = "مشتريات اليوم";
            todaysPurchasesMenuItem.Click += ShowTodaysPurchasesReport;
            // 
            // todaysCollectionsMenuItem
            // 
            todaysCollectionsMenuItem.Name = "todaysCollectionsMenuItem";
            todaysCollectionsMenuItem.Size = new Size(227, 26);
            todaysCollectionsMenuItem.Text = "تحصيلات اليوم";
            todaysCollectionsMenuItem.Click += ShowTodaysCollectionsReport;
            // 
            // purchasesByDealerMenuItem
            // 
            purchasesByDealerMenuItem.Name = "purchasesByDealerMenuItem";
            purchasesByDealerMenuItem.Size = new Size(227, 26);
            purchasesByDealerMenuItem.Text = "المشتريات حسب التاجر";
            purchasesByDealerMenuItem.Click += ShowPurchasesByDealerReport;
            // 
            // collectionsByClientMenuItem
            // 
            collectionsByClientMenuItem.Name = "collectionsByClientMenuItem";
            collectionsByClientMenuItem.Size = new Size(227, 26);
            collectionsByClientMenuItem.Text = "التحصيلات حسب العميل";
            collectionsByClientMenuItem.Click += ShowCollectionsByClientReport;
            // 
            // dashboardPanel
            // 
            dashboardPanel.BackColor = Color.FromArgb(240, 240, 240);
            dashboardPanel.Controls.Add(statsPanel);
            dashboardPanel.Controls.Add(dateLabel);
            dashboardPanel.Controls.Add(titleLabel);
            dashboardPanel.Dock = DockStyle.Fill;
            dashboardPanel.Location = new Point(0, 30);
            dashboardPanel.Margin = new Padding(3, 4, 3, 4);
            dashboardPanel.Name = "dashboardPanel";
            dashboardPanel.Padding = new Padding(23, 27, 23, 27);
            dashboardPanel.Size = new Size(1600, 715);
            dashboardPanel.TabIndex = 1;
            // 
            // statsPanel
            // 
            statsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            statsPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            statsPanel.BackColor = Color.White;
            statsPanel.Controls.Add(collectionsCard);
            statsPanel.Controls.Add(clientsCard);
            statsPanel.Controls.Add(dealersCard);
            statsPanel.Controls.Add(revenueCard);
            statsPanel.Location = new Point(57, 160);
            statsPanel.Margin = new Padding(3, 4, 3, 4);
            statsPanel.Name = "statsPanel";
            statsPanel.Size = new Size(1486, 524);
            statsPanel.TabIndex = 2;
            // 
            // collectionsCard
            // 
            collectionsCard.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            collectionsCard.BackColor = Color.White;
            collectionsCard.BorderStyle = BorderStyle.FixedSingle;
            collectionsCard.Controls.Add(collectionsTitleLabel);
            collectionsCard.Controls.Add(collectionsLabel);
            collectionsCard.Location = new Point(443, 272);
            collectionsCard.Margin = new Padding(3, 4, 3, 4);
            collectionsCard.Name = "collectionsCard";
            collectionsCard.Size = new Size(431, 199);
            collectionsCard.TabIndex = 3;
            // 
            // collectionsTitleLabel
            // 
            collectionsTitleLabel.AutoSize = true;
            collectionsTitleLabel.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            collectionsTitleLabel.ForeColor = Color.FromArgb(50, 50, 50);
            collectionsTitleLabel.Location = new Point(17, 20);
            collectionsTitleLabel.Name = "collectionsTitleLabel";
            collectionsTitleLabel.RightToLeft = RightToLeft.Yes;
            collectionsTitleLabel.Size = new Size(326, 24);
            collectionsTitleLabel.TabIndex = 0;
            collectionsTitleLabel.Text = "إجمالي التحصيلات (الشهر الحالي)";
            // 
            // collectionsLabel
            // 
            collectionsLabel.AutoSize = true;
            collectionsLabel.Font = new Font("Arial", 20F, FontStyle.Bold, GraphicsUnit.Point);
            collectionsLabel.ForeColor = Color.FromArgb(70, 130, 180);
            collectionsLabel.Location = new Point(17, 60);
            collectionsLabel.Name = "collectionsLabel";
            collectionsLabel.Size = new Size(102, 40);
            collectionsLabel.TabIndex = 1;
            collectionsLabel.Text = "$0.00";
            // 
            // clientsCard
            // 
            clientsCard.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            clientsCard.BackColor = Color.White;
            clientsCard.BorderStyle = BorderStyle.FixedSingle;
            clientsCard.Controls.Add(clientsTitleLabel);
            clientsCard.Controls.Add(clientsOweLabel);
            clientsCard.Location = new Point(443, 27);
            clientsCard.Margin = new Padding(3, 4, 3, 4);
            clientsCard.Name = "clientsCard";
            clientsCard.Size = new Size(431, 199);
            clientsCard.TabIndex = 2;
            // 
            // clientsTitleLabel
            // 
            clientsTitleLabel.AutoSize = true;
            clientsTitleLabel.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            clientsTitleLabel.ForeColor = Color.FromArgb(50, 50, 50);
            clientsTitleLabel.Location = new Point(17, 20);
            clientsTitleLabel.Name = "clientsTitleLabel";
            clientsTitleLabel.RightToLeft = RightToLeft.Yes;
            clientsTitleLabel.Size = new Size(192, 24);
            clientsTitleLabel.TabIndex = 0;
            clientsTitleLabel.Text = "المدينين يدين للعملاء";
            // 
            // clientsOweLabel
            // 
            clientsOweLabel.AutoSize = true;
            clientsOweLabel.Font = new Font("Arial", 20F, FontStyle.Bold, GraphicsUnit.Point);
            clientsOweLabel.ForeColor = Color.FromArgb(255, 140, 0);
            clientsOweLabel.Location = new Point(17, 60);
            clientsOweLabel.Name = "clientsOweLabel";
            clientsOweLabel.Size = new Size(102, 40);
            clientsOweLabel.TabIndex = 1;
            clientsOweLabel.Text = "$0.00";
            // 
            // dealersCard
            // 
            dealersCard.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            dealersCard.BackColor = Color.White;
            dealersCard.BorderStyle = BorderStyle.FixedSingle;
            dealersCard.Controls.Add(dealersTitleLabel);
            dealersCard.Controls.Add(owedToDealersLabel);
            dealersCard.Location = new Point(23, 272);
            dealersCard.Margin = new Padding(3, 4, 3, 4);
            dealersCard.Name = "dealersCard";
            dealersCard.Size = new Size(396, 199);
            dealersCard.TabIndex = 1;
            // 
            // dealersTitleLabel
            // 
            dealersTitleLabel.AutoSize = true;
            dealersTitleLabel.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dealersTitleLabel.ForeColor = Color.FromArgb(50, 50, 50);
            dealersTitleLabel.Location = new Point(17, 20);
            dealersTitleLabel.Name = "dealersTitleLabel";
            dealersTitleLabel.RightToLeft = RightToLeft.Yes;
            dealersTitleLabel.Size = new Size(235, 24);
            dealersTitleLabel.TabIndex = 0;
            dealersTitleLabel.Text = "المدينين يدين للتجار";
            // 
            // owedToDealersLabel
            // 
            owedToDealersLabel.AutoSize = true;
            owedToDealersLabel.Font = new Font("Arial", 20F, FontStyle.Bold, GraphicsUnit.Point);
            owedToDealersLabel.ForeColor = Color.FromArgb(220, 20, 60);
            owedToDealersLabel.Location = new Point(17, 60);
            owedToDealersLabel.Name = "owedToDealersLabel";
            owedToDealersLabel.Size = new Size(102, 40);
            owedToDealersLabel.TabIndex = 1;
            owedToDealersLabel.Text = "$0.00";
            // 
            // revenueCard
            // 
            revenueCard.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            revenueCard.BackColor = Color.White;
            revenueCard.BorderStyle = BorderStyle.FixedSingle;
            revenueCard.Controls.Add(revenueTitleLabel);
            revenueCard.Controls.Add(revenueLabel);
            revenueCard.Location = new Point(23, 27);
            revenueCard.Margin = new Padding(3, 4, 3, 4);
            revenueCard.Name = "revenueCard";
            revenueCard.Size = new Size(396, 199);
            revenueCard.TabIndex = 0;
            // 
            // revenueTitleLabel
            // 
            revenueTitleLabel.AutoSize = true;
            revenueTitleLabel.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            revenueTitleLabel.ForeColor = Color.FromArgb(50, 50, 50);
            revenueTitleLabel.Location = new Point(17, 20);
            revenueTitleLabel.Name = "revenueTitleLabel";
            revenueTitleLabel.RightToLeft = RightToLeft.Yes;
            revenueTitleLabel.Size = new Size(303, 24);
            revenueTitleLabel.TabIndex = 0;
            revenueTitleLabel.Text = "إجمالي الإيرادات (الشهر الحالي)";
            // 
            // revenueLabel
            // 
            revenueLabel.AutoSize = true;
            revenueLabel.Font = new Font("Arial", 20F, FontStyle.Bold, GraphicsUnit.Point);
            revenueLabel.ForeColor = Color.FromArgb(34, 139, 34);
            revenueLabel.Location = new Point(17, 60);
            revenueLabel.Name = "revenueLabel";
            revenueLabel.Size = new Size(102, 40);
            revenueLabel.TabIndex = 1;
            revenueLabel.Text = "$0.00";
            // 
            // dateLabel
            // 
            dateLabel.AutoSize = true;
            dateLabel.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dateLabel.ForeColor = Color.FromArgb(100, 100, 100);
            dateLabel.Location = new Point(57, 93);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(298, 23);
            dateLabel.TabIndex = 1;
            dateLabel.Text = "اليوم: الاثنين، 1 يناير، 2024";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.titleLabel.Location = new System.Drawing.Point(57, 40);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.titleLabel.Size = new System.Drawing.Size(226, 46);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "لوحة التحكم";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 745);
            this.Controls.Add(this.dashboardPanel);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نظام إدارة الصيد";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            dashboardPanel.ResumeLayout(false);
            dashboardPanel.PerformLayout();
            statsPanel.ResumeLayout(false);
            collectionsCard.ResumeLayout(false);
            collectionsCard.PerformLayout();
            clientsCard.ResumeLayout(false);
            clientsCard.PerformLayout();
            dealersCard.ResumeLayout(false);
            dealersCard.PerformLayout();
            revenueCard.ResumeLayout(false);
            revenueCard.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem masterDataMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dealersMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newPurchaseMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newOrderMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newCollectionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todaysPurchasesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todaysCollectionsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchasesByDealerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collectionsByClientMenuItem;
        private System.Windows.Forms.Panel dashboardPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Panel statsPanel;
        private System.Windows.Forms.Panel revenueCard;
        private System.Windows.Forms.Label revenueTitleLabel;
        private System.Windows.Forms.Label revenueLabel;
        private System.Windows.Forms.Panel dealersCard;
        private System.Windows.Forms.Label dealersTitleLabel;
        private System.Windows.Forms.Label owedToDealersLabel;
        private System.Windows.Forms.Panel clientsCard;
        private System.Windows.Forms.Label clientsTitleLabel;
        private System.Windows.Forms.Label clientsOweLabel;
        private System.Windows.Forms.Panel collectionsCard;
        private System.Windows.Forms.Label collectionsTitleLabel;
        private System.Windows.Forms.Label collectionsLabel;
    }
} 