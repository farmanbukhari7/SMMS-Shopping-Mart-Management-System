// ============================================================
// FILE: CashierDashboardForm.cs
// LAYER: Forms (Layer 3 - User Interface)
//
// PURPOSE:
//   This is the dashboard shown to Cashiers after they login.
//   Unlike the Admin Dashboard, this screen only shows the
//   Billing module. Cashiers cannot access Products, Cashier
//   Management, or Reports screens.
//
// FLOW:
//   1. Cashier logs in → this form opens automatically
//   2. Billing screen loads immediately inside the content panel
//   3. Cashier can click Billing button to reload billing screen
//   4. Cashier clicks Logout to return to Login screen
//
// CONNECTED TO:
//   - SessionManager.cs  (reads cashier name for display)
//   - BillingForm.cs     (loaded inside the content panel)
//   - LoginForm.cs       (shown again when cashier logs out)
// ============================================================

using System.Windows.Forms;
using Shopping_mart_Management_system.Database;
using Shopping_mart_Management_system.Forms.Admin;

namespace Shopping_mart_Management_system.Forms.Cashier
{
    public partial class CashierDashboardForm : Form
    {
        public CashierDashboardForm()
        {
            InitializeComponent();

            // Show the cashier's name in the top bar and sidebar
            lblUserInfo.Text =
                "Cashier · " + SessionManager.CurrentUserName;
            lblRole.Text = SessionManager.CurrentUserName;
        }

        private void CashierDashboardForm_Load(
            object sender, System.EventArgs e)
        {
            // Automatically open billing when cashier logs in
            LoadBilling();
        }

        // ─────────────────────────────────────────────────────
        // LOAD BILLING
        // Loads the BillingForm inside the content panel.
        // The cashier sees only the billing screen — nothing else.
        // ─────────────────────────────────────────────────────
        private void LoadBilling()
        {
            panelContent.Controls.Clear();

            var form = new BillingForm();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelContent.Controls.Add(form);
            form.Show();
            form.LoadData();
        }

        // ─────────────────────────────────────────────────────
        // BILLING BUTTON CLICKED
        // Reloads the billing screen fresh
        // ─────────────────────────────────────────────────────
        private void btnBilling_Click(object sender, System.EventArgs e)
        {
            LoadBilling();
        }

        // ─────────────────────────────────────────────────────
        // LOGOUT BUTTON CLICKED
        // Clears session data and returns to login screen
        // ─────────────────────────────────────────────────────
        private void btnLogout_Click(object sender, System.EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Erase all session data
                SessionManager.Clear();

                // Hide this window and show login screen
                this.Hide();
                new Shopping_mart_Management_system
                    .Forms.Auth.LoginForm().Show();
            }
        }
    }
}