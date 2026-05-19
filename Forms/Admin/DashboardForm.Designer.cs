namespace Shopping_mart_Management_system.Forms.Admin
{
    partial class DashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelSidebar = new Panel();
            btnLogout = new Button();
            btnNavReports = new Button();
            btnNavBilling = new Button();
            btnNavProducts = new Button();
            btnNavCashiers = new Button();
            btnNavDashboard = new Button();
            lblRole = new Label();
            lblAppName = new Label();
            panelLogo = new Panel();
            panelTopBar = new Panel();
            lblUserInfo = new Label();
            lblPageTitle = new Label();
            panelContent = new Panel();
            cardRevenue = new Panel();
            lblRevenueCount = new Label();
            lblRevenueTitle = new Label();
            cardCashiers = new Panel();
            lblCashiersCount = new Label();
            lblCashiersTitle = new Label();
            cardBills = new Panel();
            lblBillsCount = new Label();
            lblBillsTitle = new Label();
            cardProducts = new Panel();
            lblProductsTitle = new Label();
            lblProductsCount = new Label();
            panelStats = new Panel();
            panelSidebar.SuspendLayout();
            panelTopBar.SuspendLayout();
            cardRevenue.SuspendLayout();
            cardCashiers.SuspendLayout();
            cardBills.SuspendLayout();
            cardProducts.SuspendLayout();
            panelStats.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(26, 31, 46);
            panelSidebar.Controls.Add(btnLogout);
            panelSidebar.Controls.Add(btnNavReports);
            panelSidebar.Controls.Add(btnNavBilling);
            panelSidebar.Controls.Add(btnNavProducts);
            panelSidebar.Controls.Add(btnNavCashiers);
            panelSidebar.Controls.Add(btnNavDashboard);
            panelSidebar.Controls.Add(lblRole);
            panelSidebar.Controls.Add(lblAppName);
            panelSidebar.Controls.Add(panelLogo);
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(220, 700);
            panelSidebar.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Arial Narrow", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.FromArgb(200, 80, 80);
            btnLogout.Location = new Point(0, 596);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(220, 50);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "   🚪  Logout";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnNavReports
            // 
            btnNavReports.BackColor = Color.FromArgb(50, 60, 85);
            btnNavReports.Cursor = Cursors.Hand;
            btnNavReports.FlatAppearance.BorderSize = 0;
            btnNavReports.FlatStyle = FlatStyle.Flat;
            btnNavReports.Font = new Font("Arial Narrow", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNavReports.ForeColor = Color.White;
            btnNavReports.Location = new Point(0, 300);
            btnNavReports.Name = "btnNavReports";
            btnNavReports.Size = new Size(220, 50);
            btnNavReports.TabIndex = 7;
            btnNavReports.Text = "   📈  Reports";
            btnNavReports.TextAlign = ContentAlignment.MiddleLeft;
            btnNavReports.UseVisualStyleBackColor = false;
            btnNavReports.Click += btnNavReports_Click;
            // 
            // btnNavBilling
            // 
            btnNavBilling.Cursor = Cursors.Hand;
            btnNavBilling.FlatAppearance.BorderSize = 0;
            btnNavBilling.FlatStyle = FlatStyle.Flat;
            btnNavBilling.Font = new Font("Arial Narrow", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNavBilling.ForeColor = Color.FromArgb(150, 160, 180);
            btnNavBilling.Location = new Point(0, 250);
            btnNavBilling.Name = "btnNavBilling";
            btnNavBilling.Size = new Size(220, 50);
            btnNavBilling.TabIndex = 6;
            btnNavBilling.Text = "   \U0001f9fe  Billing";
            btnNavBilling.TextAlign = ContentAlignment.MiddleLeft;
            btnNavBilling.UseVisualStyleBackColor = true;
            btnNavBilling.Click += btnNavBilling_Click;
            // 
            // btnNavProducts
            // 
            btnNavProducts.BackColor = Color.FromArgb(50, 60, 85);
            btnNavProducts.Cursor = Cursors.Hand;
            btnNavProducts.FlatAppearance.BorderSize = 0;
            btnNavProducts.FlatStyle = FlatStyle.Flat;
            btnNavProducts.Font = new Font("Arial Narrow", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNavProducts.ForeColor = Color.White;
            btnNavProducts.Location = new Point(0, 200);
            btnNavProducts.Name = "btnNavProducts";
            btnNavProducts.Size = new Size(220, 50);
            btnNavProducts.TabIndex = 5;
            btnNavProducts.Text = "   📦  Products";
            btnNavProducts.TextAlign = ContentAlignment.MiddleLeft;
            btnNavProducts.UseVisualStyleBackColor = false;
            btnNavProducts.Click += btnNavProducts_Click;
            // 
            // btnNavCashiers
            // 
            btnNavCashiers.Cursor = Cursors.Hand;
            btnNavCashiers.FlatAppearance.BorderSize = 0;
            btnNavCashiers.FlatStyle = FlatStyle.Flat;
            btnNavCashiers.Font = new Font("Arial Narrow", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNavCashiers.ForeColor = Color.FromArgb(150, 160, 180);
            btnNavCashiers.Location = new Point(0, 150);
            btnNavCashiers.Name = "btnNavCashiers";
            btnNavCashiers.Size = new Size(220, 50);
            btnNavCashiers.TabIndex = 4;
            btnNavCashiers.Text = "   👤  Cashiers";
            btnNavCashiers.TextAlign = ContentAlignment.MiddleLeft;
            btnNavCashiers.UseVisualStyleBackColor = true;
            btnNavCashiers.Click += btnNavCashiers_Click;
            // 
            // btnNavDashboard
            // 
            btnNavDashboard.BackColor = Color.FromArgb(50, 60, 85);
            btnNavDashboard.Cursor = Cursors.Hand;
            btnNavDashboard.FlatAppearance.BorderSize = 0;
            btnNavDashboard.FlatStyle = FlatStyle.Flat;
            btnNavDashboard.Font = new Font("Arial Narrow", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNavDashboard.ForeColor = Color.White;
            btnNavDashboard.Location = new Point(0, 100);
            btnNavDashboard.Name = "btnNavDashboard";
            btnNavDashboard.Size = new Size(220, 50);
            btnNavDashboard.TabIndex = 3;
            btnNavDashboard.Text = "   📊  Dashboard";
            btnNavDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnNavDashboard.UseVisualStyleBackColor = false;
            btnNavDashboard.Click += btnNavDashboard_Click;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Arial Narrow", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRole.ForeColor = Color.FromArgb(100, 120, 160);
            lblRole.Location = new Point(20, 48);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(86, 20);
            lblRole.TabIndex = 2;
            lblRole.Text = "Administrator";
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAppName.ForeColor = Color.White;
            lblAppName.Location = new Point(20, 15);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(103, 33);
            lblAppName.TabIndex = 1;
            lblAppName.Text = "SMMS";
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(20, 24, 38);
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(220, 80);
            panelLogo.TabIndex = 0;
            // 
            // panelTopBar
            // 
            panelTopBar.BackColor = Color.White;
            panelTopBar.Controls.Add(lblUserInfo);
            panelTopBar.Controls.Add(lblPageTitle);
            panelTopBar.Location = new Point(220, 0);
            panelTopBar.Name = "panelTopBar";
            panelTopBar.Size = new Size(980, 60);
            panelTopBar.TabIndex = 1;
            // 
            // lblUserInfo
            // 
            lblUserInfo.AutoSize = true;
            lblUserInfo.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUserInfo.ForeColor = Color.FromArgb(100, 120, 160);
            lblUserInfo.Location = new Point(800, 20);
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Size = new Size(149, 22);
            lblUserInfo.TabIndex = 1;
            lblUserInfo.Text = "Admin · Administrator";
            // 
            // lblPageTitle
            // 
            lblPageTitle.AutoSize = true;
            lblPageTitle.Font = new Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPageTitle.ForeColor = Color.FromArgb(26, 31, 46);
            lblPageTitle.Location = new Point(20, 15);
            lblPageTitle.Name = "lblPageTitle";
            lblPageTitle.Size = new Size(161, 33);
            lblPageTitle.TabIndex = 0;
            lblPageTitle.Text = "Dashboard";
            // 
            // panelContent
            // 
            panelContent.Location = new Point(220, 220);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(994, 778);
            panelContent.TabIndex = 2;
            // 
            // cardRevenue
            // 
            cardRevenue.BackColor = Color.White;
            cardRevenue.Controls.Add(lblRevenueCount);
            cardRevenue.Controls.Add(lblRevenueTitle);
            cardRevenue.Location = new Point(715, 26);
            cardRevenue.Name = "cardRevenue";
            cardRevenue.Size = new Size(210, 110);
            cardRevenue.TabIndex = 3;
            // 
            // lblRevenueCount
            // 
            lblRevenueCount.AutoSize = true;
            lblRevenueCount.Font = new Font("Arial", 15F, FontStyle.Bold);
            lblRevenueCount.ForeColor = Color.FromArgb(79, 142, 247);
            lblRevenueCount.Location = new Point(15, 45);
            lblRevenueCount.Name = "lblRevenueCount";
            lblRevenueCount.Size = new Size(87, 35);
            lblRevenueCount.TabIndex = 1;
            lblRevenueCount.Text = "Rs. 0";
            // 
            // lblRevenueTitle
            // 
            lblRevenueTitle.AutoSize = true;
            lblRevenueTitle.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRevenueTitle.ForeColor = Color.FromArgb(120, 130, 150);
            lblRevenueTitle.Location = new Point(14, 15);
            lblRevenueTitle.Name = "lblRevenueTitle";
            lblRevenueTitle.Size = new Size(122, 22);
            lblRevenueTitle.TabIndex = 0;
            lblRevenueTitle.Text = "Today's Revenue";
            // 
            // cardCashiers
            // 
            cardCashiers.BackColor = Color.White;
            cardCashiers.Controls.Add(lblCashiersCount);
            cardCashiers.Controls.Add(lblCashiersTitle);
            cardCashiers.Location = new Point(255, 26);
            cardCashiers.Name = "cardCashiers";
            cardCashiers.Size = new Size(210, 110);
            cardCashiers.TabIndex = 1;
            // 
            // lblCashiersCount
            // 
            lblCashiersCount.AutoSize = true;
            lblCashiersCount.Font = new Font("Arial", 15F, FontStyle.Bold);
            lblCashiersCount.ForeColor = Color.FromArgb(79, 142, 247);
            lblCashiersCount.Location = new Point(16, 45);
            lblCashiersCount.Name = "lblCashiersCount";
            lblCashiersCount.Size = new Size(32, 35);
            lblCashiersCount.TabIndex = 1;
            lblCashiersCount.Text = "0";
            // 
            // lblCashiersTitle
            // 
            lblCashiersTitle.AutoSize = true;
            lblCashiersTitle.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCashiersTitle.ForeColor = Color.FromArgb(120, 130, 150);
            lblCashiersTitle.Location = new Point(14, 15);
            lblCashiersTitle.Name = "lblCashiersTitle";
            lblCashiersTitle.Size = new Size(102, 22);
            lblCashiersTitle.TabIndex = 0;
            lblCashiersTitle.Text = "Total Cashiers";
            // 
            // cardBills
            // 
            cardBills.BackColor = Color.White;
            cardBills.Controls.Add(lblBillsCount);
            cardBills.Controls.Add(lblBillsTitle);
            cardBills.Location = new Point(485, 26);
            cardBills.Name = "cardBills";
            cardBills.Size = new Size(210, 110);
            cardBills.TabIndex = 2;
            // 
            // lblBillsCount
            // 
            lblBillsCount.AutoSize = true;
            lblBillsCount.Font = new Font("Arial", 15F, FontStyle.Bold);
            lblBillsCount.ForeColor = Color.FromArgb(79, 142, 247);
            lblBillsCount.Location = new Point(15, 45);
            lblBillsCount.Name = "lblBillsCount";
            lblBillsCount.Size = new Size(32, 35);
            lblBillsCount.TabIndex = 1;
            lblBillsCount.Text = "0";
            // 
            // lblBillsTitle
            // 
            lblBillsTitle.AutoSize = true;
            lblBillsTitle.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBillsTitle.ForeColor = Color.FromArgb(120, 130, 150);
            lblBillsTitle.Location = new Point(14, 15);
            lblBillsTitle.Name = "lblBillsTitle";
            lblBillsTitle.Size = new Size(90, 22);
            lblBillsTitle.TabIndex = 0;
            lblBillsTitle.Text = "Today's Bills";
            // 
            // cardProducts
            // 
            cardProducts.BackColor = Color.White;
            cardProducts.Controls.Add(lblProductsTitle);
            cardProducts.Controls.Add(lblProductsCount);
            cardProducts.Location = new Point(25, 26);
            cardProducts.Name = "cardProducts";
            cardProducts.Size = new Size(210, 110);
            cardProducts.TabIndex = 0;
            // 
            // lblProductsTitle
            // 
            lblProductsTitle.AutoSize = true;
            lblProductsTitle.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProductsTitle.ForeColor = Color.FromArgb(120, 130, 150);
            lblProductsTitle.Location = new Point(15, 15);
            lblProductsTitle.Name = "lblProductsTitle";
            lblProductsTitle.Size = new Size(101, 22);
            lblProductsTitle.TabIndex = 0;
            lblProductsTitle.Text = "Total Products";
            // 
            // lblProductsCount
            // 
            lblProductsCount.AutoSize = true;
            lblProductsCount.Font = new Font("Arial", 15F, FontStyle.Bold);
            lblProductsCount.ForeColor = Color.FromArgb(79, 142, 247);
            lblProductsCount.Location = new Point(15, 45);
            lblProductsCount.Name = "lblProductsCount";
            lblProductsCount.Size = new Size(32, 35);
            lblProductsCount.TabIndex = 1;
            lblProductsCount.Text = "0";
            // 
            // panelStats
            // 
            panelStats.Controls.Add(cardProducts);
            panelStats.Controls.Add(cardBills);
            panelStats.Controls.Add(cardCashiers);
            panelStats.Controls.Add(cardRevenue);
            panelStats.Location = new Point(220, 60);
            panelStats.Name = "panelStats";
            panelStats.Size = new Size(980, 160);
            panelStats.TabIndex = 4;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 242, 245);
            ClientSize = new Size(1178, 644);
            Controls.Add(panelStats);
            Controls.Add(panelContent);
            Controls.Add(panelTopBar);
            Controls.Add(panelSidebar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "DashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Shoping Mart Management System";
            Load += DashboardForm_Load;
            panelSidebar.ResumeLayout(false);
            panelSidebar.PerformLayout();
            panelTopBar.ResumeLayout(false);
            panelTopBar.PerformLayout();
            cardRevenue.ResumeLayout(false);
            cardRevenue.PerformLayout();
            cardCashiers.ResumeLayout(false);
            cardCashiers.PerformLayout();
            cardBills.ResumeLayout(false);
            cardBills.PerformLayout();
            cardProducts.ResumeLayout(false);
            cardProducts.PerformLayout();
            panelStats.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSidebar;
        private Label lblRole;
        private Label lblAppName;
        private Panel panelLogo;
        private Button btnNavDashboard;
        private Button btnNavCashiers;
        private Button btnNavProducts;
        private Button btnNavBilling;
        private Button btnNavReports;
        private Button btnLogout;
        private Panel panelTopBar;
        private Label lblPageTitle;
        private Label lblUserInfo;
        private Panel panelContent;
        private Panel cardRevenue;
        private Label lblRevenueCount;
        private Label lblRevenueTitle;
        private Panel cardCashiers;
        private Label lblCashiersCount;
        private Label lblCashiersTitle;
        private Panel cardBills;
        private Label lblBillsCount;
        private Label lblBillsTitle;
        private Panel cardProducts;
        private Label lblProductsTitle;
        private Label lblProductsCount;
        private Panel panelStats;
    }
}