// ============================================================
// FILE: FirstTimeSetupForm.cs
// LAYER: Forms (Layer 3 - User Interface)
//
// PURPOSE:
//   This is the simple one-popup setup screen that appears
//   only on the FIRST run on any new computer.
//   The user enters their MySQL root password, clicks
//   CONNECT & START, and everything is set up automatically.
//   This screen never appears again on the same computer.
//
// FLOW:
//   1. User types their MySQL root password
//   2. User clicks CONNECT & START
//   3. App tests the connection
//   4. If connected:
//      → Database and tables created automatically
//      → Password saved so this never shows again
//      → Login form opens
//   5. If failed:
//      → Clear error message shown
//      → User can try again
//
// CONNECTED TO:
//   - DbConnection.cs  (tests connection and sets up database)
//   - LoginForm.cs     (opened after successful setup)
// ============================================================

using System;
using System.Windows.Forms;
using Shopping_mart_Management_system.Database;

namespace Shopping_mart_Management_system.Forms.Auth
{
    public partial class FirstTimeSetupForm : Form
    {
        public FirstTimeSetupForm()
        {
            InitializeComponent();
        }

        // ─────────────────────────────────────────────────────
        // CONNECT & START BUTTON CLICKED
        // Tests the MySQL connection with the entered password.
        // If successful, sets up database and opens Login form.
        // ─────────────────────────────────────────────────────
        private void btnConnect_Click(object sender, EventArgs e)
        {
            // Get the password the user typed
            // (empty string is valid — some MySQL installs
            //  have no password)
            string password = txtPassword.Text;

            // Save the password and build the connection string
            DbConnection.SetPassword(password);

            // Show a loading message while connecting
            btnConnect.Text = "Connecting...";
            btnConnect.Enabled = false;

            // Test if the connection works
            if (DbConnection.TestConnection())
            {
                try
                {
                    // Connection works!
                    // Now automatically create the database,
                    // all tables, and default data
                    DbConnection.AutoSetupDatabase();

                    MessageBox.Show(
                        "Connected successfully!\n\n" +
                        "Database has been set up automatically.\n" +
                        "You will not see this screen again.",
                        "Setup Complete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Open the Login form and close this one
                    this.Hide();
                    new LoginForm().Show();
                }
                catch (Exception ex)
                {
                    // Connection worked but database setup failed
                    MessageBox.Show(
                        "Connected but failed to set up database.\n\n" +
                        "Error: " + ex.Message,
                        "Setup Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    btnConnect.Text = "CONNECT & START";
                    btnConnect.Enabled = true;
                }
            }
            else
            {
                // Connection failed — wrong password most likely
                MessageBox.Show(
                    "Could not connect to MySQL!\n\n" +
                    "Please check:\n" +
                    "• MySQL Server is installed and running\n" +
                    "• The password you entered is correct\n" +
                    "• If you have no password, leave it empty",
                    "Connection Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                // Reset the button so user can try again
                btnConnect.Text = "CONNECT & START";
                btnConnect.Enabled = true;
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }
    }
}