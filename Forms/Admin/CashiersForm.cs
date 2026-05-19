// ============================================================
// FILE: CashiersForm.cs
// LAYER: Forms (Layer 3 - User Interface)
//
// PURPOSE:
//   This screen allows the Administrator to manage cashier
//   accounts. The Admin can add new cashiers and delete
//   existing ones. This screen is NOT accessible to Cashiers.
//
// FLOW:
//   1. Screen loads and shows all cashiers in the table
//   2. Admin fills in Full Name, Username, Password
//   3. Admin clicks ADD CASHIER → saved to database
//   4. Admin clicks a row in the table to select a cashier
//   5. Admin clicks DELETE SELECTED → removed from database
//   6. Table refreshes automatically after every change
//
// CONNECTED TO:
//   - UserRepository.cs  (handles all database operations)
//   - User.cs            (model used to pass cashier data)
//   - DashboardForm.cs   (loads this form in the content panel)
// ============================================================

using System;
using System.Windows.Forms;
using Shopping_mart_Management_system.Database;
using Shopping_mart_Management_system.Models;

namespace Shopping_mart_Management_system.Forms.Admin
{
    public partial class CashiersForm : Form
    {
        // Repository that handles all User database operations
        private UserRepository _userRepo = new UserRepository();

        public CashiersForm()
        {
            InitializeComponent();
        }

        private void CashiersForm_Load(object sender, EventArgs e)
        {
            // Load all cashiers when the form opens
            LoadData();
        }

        // ─────────────────────────────────────────────────────
        // LOAD DATA
        // Loads all cashiers from the database and displays
        // them in the table. Called on load and after changes.
        // Public so DashboardForm can call it directly.
        // ─────────────────────────────────────────────────────
        public void LoadData()
        {
            try
            {
                // Ask UserRepository for all cashier accounts
                var cashiers = _userRepo.GetAllCashiers();

                // Clear the table and reload from scratch
                dgvCashiers.DataSource = null;
                dgvCashiers.Rows.Clear();

                // Set up column headers
                dgvCashiers.ColumnCount = 5;
                dgvCashiers.Columns[0].Name = "ID";
                dgvCashiers.Columns[0].Width = 50;
                dgvCashiers.Columns[1].Name = "Full Name";
                dgvCashiers.Columns[1].Width = 150;
                dgvCashiers.Columns[2].Name = "Username";
                dgvCashiers.Columns[2].Width = 130;
                dgvCashiers.Columns[3].Name = "Password";
                dgvCashiers.Columns[3].Width = 120;
                dgvCashiers.Columns[4].Name = "Added On";
                dgvCashiers.Columns[4].Width = 160;

                // Add one row for each cashier in the list
                foreach (var cashier in cashiers)
                {
                    dgvCashiers.Rows.Add(
                        cashier.Id,
                        cashier.FullName,
                        cashier.Username,
                        cashier.Password,
                        cashier.Id
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading cashiers: " + ex.Message);
            }
        }

        // ─────────────────────────────────────────────────────
        // ADD CASHIER BUTTON CLICKED
        // Reads the input fields, creates a User object,
        // and saves it to the database via UserRepository.
        // ─────────────────────────────────────────────────────
        private void btnAddCashier_Click(object sender, EventArgs e)
        {
            // Read input values
            string name = txtFullName.Text.Trim();
            string username = txtCashierUsername.Text.Trim();
            string password = txtCashierPassword.Text.Trim();

            // Validate — make sure no field is empty
            if (string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password))
            {
                MessageBox.Show(
                    "Please fill in all fields.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Check if the username is already taken
            if (_userRepo.UsernameExists(username))
            {
                MessageBox.Show(
                    "Username already exists! Please choose another.",
                    "Duplicate Username",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Create a User object with the entered details
            var newCashier = new User
            {
                FullName = name,
                Username = username,
                Password = password
            };

            // Ask UserRepository to save it to the database
            bool saved = _userRepo.AddCashier(newCashier);

            if (saved)
            {
                MessageBox.Show(
                    "Cashier added successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Clear the input fields
                txtFullName.Clear();
                txtCashierUsername.Clear();
                txtCashierPassword.Clear();

                // Reload the table to show the new cashier
                LoadData();
            }
            else
            {
                MessageBox.Show(
                    "Failed to add cashier. Please try again.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────
        // DELETE CASHIER BUTTON CLICKED
        // Gets the ID of the selected row and asks
        // UserRepository to remove that cashier from the DB.
        // ─────────────────────────────────────────────────────
        private void btnDeleteCashier_Click(object sender, EventArgs e)
        {
            // Make sure a row is selected in the table
            if (dgvCashiers.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a cashier to delete.",
                    "No Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Get the ID and name of the selected cashier
            int id = Convert.ToInt32(
                dgvCashiers.SelectedRows[0].Cells[0].Value);
            string name = dgvCashiers.SelectedRows[0]
                .Cells[1].Value.ToString();

            // Ask for confirmation before deleting
            var confirm = MessageBox.Show(
                $"Are you sure you want to delete cashier '{name}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                // Ask UserRepository to delete this cashier
                bool deleted = _userRepo.DeleteCashier(id);

                if (deleted)
                {
                    MessageBox.Show(
                        "Cashier deleted successfully.",
                        "Deleted",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Reload table to reflect the deletion
                    LoadData();
                }
                else
                {
                    MessageBox.Show(
                        "Failed to delete cashier.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}