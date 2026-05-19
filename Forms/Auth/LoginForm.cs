// ============================================================
// FILE: LoginForm.cs
// LAYER: Forms (Layer 3 - User Interface)
//
// PURPOSE:
//   This is the FIRST screen the user sees when they open
//   the application. It asks for a username and password,
//   checks them against the database, and opens the correct
//   dashboard based on the user's role.
//
// FLOW:
//   1. User types username and password
//   2. User clicks LOGIN button
//   3. LoginForm asks UserRepository to check the credentials
//   4. If correct → save user info in SessionManager
//      → open Admin Dashboard (if Admin)
//      → open Cashier Dashboard (if Cashier)
//   5. If wrong → show error message
//
// CONNECTED TO:
//   - UserRepository.cs        (checks login credentials)
//   - SessionManager.cs        (saves logged-in user info)
//   - DashboardForm.cs         (opened if role is Admin)
//   - CashierDashboardForm.cs  (opened if role is Cashier)
// ============================================================

using Shopping_mart_Management_system.Database;
using Shopping_mart_Management_system.Forms.Admin;
using Shopping_mart_Management_system.Forms.Cashier;
using System;
using System.Windows.Forms;

namespace Shopping_mart_Management_system.Forms.Auth
{
    public partial class LoginForm : Form
    {
        // Create one instance of UserRepository to use
        // for all database operations in this form
        private UserRepository _userRepo = new UserRepository();

        public LoginForm()
        {
            InitializeComponent();

            // Pre-fill credentials for easy testing during development
            // REMOVE these two lines when the app is ready for real use
            txtUsername.Text = "admin";
            txtPassword.Text = "admin123";
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Nothing needed here at load time
        }

        // ─────────────────────────────────────────────────────
        // LOGIN BUTTON CLICKED
        // Runs when the user clicks the LOGIN button.
        // Validates input, checks database, opens dashboard.
        // ─────────────────────────────────────────────────────
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Read what the user typed in the text boxes
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Step 1: Make sure both fields are filled
            if (string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password))
            {
                MessageBox.Show(
                    "Please enter username and password.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Step 2: Ask UserRepository to check if this
                // username and password exist in the database
                var user = _userRepo.Login(username, password);

                if (user != null)
                {
                    // Step 3: Login succeeded!
                    // Save the logged-in user's details in
                    // SessionManager so all forms can access them
                    SessionManager.CurrentUserName = user.FullName;
                    SessionManager.CurrentRole = user.Role;
                    SessionManager.CurrentUserId = user.Id;

                    // Show a welcome message
                    MessageBox.Show(
                        $"Welcome, {user.FullName}!",
                        "Login Successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Step 4: Open the correct dashboard
                    // based on whether user is Admin or Cashier
                    this.Hide();

                    if (user.Role == "Admin")
                    {
                        // Admin gets the full dashboard
                        new DashboardForm().Show();
                    }
                    else if (user.Role == "Cashier")
                    {
                        // Cashier gets the simplified dashboard
                        new CashierDashboardForm().Show();
                    }
                }
                else
                {
                    // Step 5: Login failed — wrong credentials
                    MessageBox.Show(
                        "Invalid username or password.",
                        "Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    // Clear password and focus username for retry
                    txtPassword.Clear();
                    txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Database error: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────
        // EXIT BUTTON CLICKED
        // Closes the entire application
        // ─────────────────────────────────────────────────────
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}