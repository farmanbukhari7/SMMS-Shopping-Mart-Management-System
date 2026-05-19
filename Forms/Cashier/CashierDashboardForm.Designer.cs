namespace Shopping_mart_Management_system.Forms.Cashier
{
    partial class CashierDashboardForm
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
            panelLogo = new Panel();
            lblAppName = new Label();
            lblRole = new Label();
            btnBilling = new Button();
            btnLogout = new Button();
            panelTopBar = new Panel();
            lblPageTitle = new Label();
            lblUserInfo = new Label();
            panelContent = new Panel();
            panelSidebar.SuspendLayout();
            panelTopBar.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(26, 31, 46);
            panelSidebar.Controls.Add(btnLogout);
            panelSidebar.Controls.Add(btnBilling);
            panelSidebar.Controls.Add(lblRole);
            panelSidebar.Controls.Add(lblAppName);
            panelSidebar.Controls.Add(panelLogo);
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(220, 700);
            panelSidebar.TabIndex = 0;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(20, 24, 38);
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(220, 80);
            panelLogo.TabIndex = 0;
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
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRole.ForeColor = Color.FromArgb(100, 120, 160);
            lblRole.Location = new Point(20, 48);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(63, 18);
            lblRole.TabIndex = 2;
            lblRole.Text = "Cashier";
            // 
            // btnBilling
            // 
            btnBilling.BackColor = Color.FromArgb(50, 60, 85);
            btnBilling.Cursor = Cursors.Hand;
            btnBilling.FlatAppearance.BorderSize = 0;
            btnBilling.FlatStyle = FlatStyle.Flat;
            btnBilling.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBilling.ForeColor = Color.White;
            btnBilling.Location = new Point(0, 100);
            btnBilling.Name = "btnBilling";
            btnBilling.Size = new Size(220, 50);
            btnBilling.TabIndex = 3;
            btnBilling.Text = "   \U0001f9fe  Billing";
            btnBilling.TextAlign = ContentAlignment.MiddleLeft;
            btnBilling.UseVisualStyleBackColor = false;
            btnBilling.Click += btnBilling_Click;
            // 
            // btnLogout
            // 
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.FromArgb(200, 80, 80);
            btnLogout.Location = new Point(-1, 594);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(220, 50);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "🚪  Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
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
            // lblPageTitle
            // 
            lblPageTitle.AutoSize = true;
            lblPageTitle.Font = new Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPageTitle.Location = new Point(20, 15);
            lblPageTitle.Name = "lblPageTitle";
            lblPageTitle.Size = new Size(100, 33);
            lblPageTitle.TabIndex = 0;
            lblPageTitle.Text = "Billing";
            // 
            // lblUserInfo
            // 
            lblUserInfo.AutoSize = true;
            lblUserInfo.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUserInfo.Location = new Point(800, 20);
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Size = new Size(135, 21);
            lblUserInfo.TabIndex = 1;
            lblUserInfo.Text = "Cashier · Name";
            // 
            // panelContent
            // 
            panelContent.Location = new Point(220, 60);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(980, 640);
            panelContent.TabIndex = 2;
            // 
            // CashierDashboardForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 242, 245);
            ClientSize = new Size(1178, 644);
            Controls.Add(panelContent);
            Controls.Add(panelTopBar);
            Controls.Add(panelSidebar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "CashierDashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SMMS — Cashier";
            Load += CashierDashboardForm_Load;
            panelSidebar.ResumeLayout(false);
            panelSidebar.PerformLayout();
            panelTopBar.ResumeLayout(false);
            panelTopBar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSidebar;
        private Label lblAppName;
        private Panel panelLogo;
        private Button btnBilling;
        private Label lblRole;
        private Button btnLogout;
        private Panel panelTopBar;
        private Label lblPageTitle;
        private Label lblUserInfo;
        private Panel panelContent;
    }
}