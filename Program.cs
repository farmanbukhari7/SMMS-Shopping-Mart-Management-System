// ============================================================
// FILE: Program.cs
// LAYER: Entry Point
//
// PURPOSE:
//   This is the starting point of the entire application.
//   It handles the first-time setup automatically so the
//   professor only needs to enter their MySQL password once.
//
// FLOW:
//   FIRST TIME (no saved password):
//     1. Show simple password popup
//     2. Test the connection
//     3. Create database and tables automatically
//     4. Save password for next time
//     5. Open Login form
//
//   NEXT TIME (password already saved):
//     1. Load saved password
//     2. Test connection silently
//     3. Open Login form directly
//     4. If connection fails → show password popup again
// ============================================================

using System;
using System.Windows.Forms;
using Shopping_mart_Management_system.Database;
using Shopping_mart_Management_system.Forms.Auth;

namespace Shopping_mart_Management_system
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Step 1: Check if we have a saved password
            string savedPassword = DbConnection.LoadSavedPassword();

            if (!string.IsNullOrEmpty(savedPassword))
            {
                // Password was saved before — try using it
                DbConnection.SetPassword(savedPassword);

                if (DbConnection.TestConnection())
                {
                    // Connection works — go straight to Login
                    
                    Application.Run(new LoginForm());
                    return;
                }
                // If connection failed, fall through to show popup
            }

            // Step 2: No saved password OR saved password failed
            // Show the simple one-popup setup screen
            Application.Run(new FirstTimeSetupForm());
        }
    }
}