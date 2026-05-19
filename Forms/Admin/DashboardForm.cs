// ============================================================
// FILE: DashboardForm.cs
// LAYER: Forms (Layer 3 - User Interface)
//
// PURPOSE:
//   This is the MAIN screen for the Administrator after login.
//   It shows a sidebar for navigation and 4 statistics cards
//   showing a quick overview of the business.
//
// FLOW:
//   1. Form opens after Admin logs in
//   2. Dashboard loads statistics from database
//   3. Admin clicks sidebar buttons to navigate to screens
//   4. Each screen loads inside panelContent
//   5. When Dashboard button is clicked, stats reload
//
// CONNECTED TO:
//   - ProductRepository.cs  (gets total product count)
//   - UserRepository.cs     (gets total cashier count)
//   - BillRepository.cs     (gets today's bills and revenue)
//   - SessionManager.cs     (reads logged-in user name/role)
//   - All Admin Forms       (loaded inside panelContent)
// ============================================================

using System;
using System.Windows.Forms;
using Shopping_mart_Management_system.Database;

namespace Shopping_mart_Management_system.Forms.Admin
{
    public partial class DashboardForm : Form
    {
        // Create repository instances to use for
        // loading statistics from the database
        private ProductRepository _productRepo = new ProductRepository();
        private UserRepository _userRepo = new UserRepository();
        private BillRepository _billRepo = new BillRepository();

        public DashboardForm()
        {
            InitializeComponent();

            // Show logged-in user info in the top bar and sidebar
            lblUserInfo.Text = SessionManager.CurrentRole +
                               " · " + SessionManager.CurrentUserName;
            lblRole.Text = SessionManager.CurrentRole;
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            // Load the dashboard stats when form first opens
            ShowDashboard();
        }

        // ─────────────────────────────────────────────────────
        // SHOW DASHBOARD
        // Resets the content area and reloads the stat cards.
        // Called when the Dashboard button is clicked or on load.
        // ─────────────────────────────────────────────────────
        private void ShowDashboard()
        {
            lblPageTitle.Text = "Dashboard";
            panelContent.Controls.Clear();

            // Make the stat cards visible again
            panelStats.Visible = true;
            panelStats.BringToFront();

            // Move panelContent back down below the stat cards
            panelContent.Location =
                new System.Drawing.Point(220, 220);
            panelContent.Size =
                new System.Drawing.Size(980, 480);

            LoadStats();
        }

        // ─────────────────────────────────────────────────────
        // LOAD STATS
        // Reads the 4 statistics from the database and
        // displays them in the stat cards on the Dashboard.
        // ─────────────────────────────────────────────────────
        private void LoadStats()
        {
            try
            {
                // Total products — reads from products table
                lblProductsCount.Text =
                    _productRepo.GetTotalCount().ToString();

                // Total cashiers — reads from users table
                lblCashiersCount.Text =
                    _userRepo.GetAllCashiers().Count.ToString();

                // Today's bill count — counts bills from today
                lblBillsCount.Text =
                    _billRepo.GetTodayBillCount().ToString();

                // Today's revenue — sums totals from today's bills
                lblRevenueCount.Text = "Rs. " +
                    _billRepo.GetTodayRevenue().ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading stats: " + ex.Message);
            }
        }

        // ─────────────────────────────────────────────────────
        // LOAD SUB FORM
        // Loads any form inside the content panel.
        // Hides the stat cards and expands the content area
        // to fill the full available space.
        // ─────────────────────────────────────────────────────
        private void LoadSubForm(Form form, string title)
        {
            lblPageTitle.Text = title;

            // Hide stat cards when showing a sub-form
            panelStats.Visible = false;
            panelContent.Controls.Clear();

            // Expand content panel to fill the full area
            panelContent.Location =
                new System.Drawing.Point(220, 60);
            panelContent.Size =
                new System.Drawing.Size(980, 640);

            // Embed the form inside the content panel
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelContent.Controls.Add(form);
            form.Show();
        }

        // ─────────────────────────────────────────────────────
        // NAVIGATION BUTTONS
        // Each button loads the correct form into the panel
        // ─────────────────────────────────────────────────────

        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            ShowDashboard();
        }

        private void btnNavCashiers_Click(object sender, EventArgs e)
        {
            var form = new CashiersForm();
            LoadSubForm(form, "Cashier Management");
            form.LoadData();
        }

        private void btnNavProducts_Click(object sender, EventArgs e)
        {
            var form = new ProductsForm();
            LoadSubForm(form, "Products Management");
            form.LoadData();
        }

        private void btnNavBilling_Click(object sender, EventArgs e)
        {
            var form = new BillingForm();
            LoadSubForm(form, "Billing");
            form.LoadData();
        }

        private void btnNavReports_Click(object sender, EventArgs e)
        {
            var form = new ReportsForm();
            LoadSubForm(form, "Reports");
            form.LoadData();
        }

        // ─────────────────────────────────────────────────────
        // LOGOUT BUTTON
        // Clears the session and returns to the Login screen
        // ─────────────────────────────────────────────────────
        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Clear all session data (name, role, id)
                SessionManager.Clear();

                // Hide this window and show the login screen
                this.Hide();
                new Shopping_mart_Management_system
                    .Forms.Auth.LoginForm().Show();
            }
        }
    }
}