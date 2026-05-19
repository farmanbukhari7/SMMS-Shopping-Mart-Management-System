// ============================================================
// FILE: SessionManager.cs
// LAYER: Database (Layer 2 - Data Access)
//
// PURPOSE:
//   This file acts like a memory box that remembers who is
//   currently logged into the application. When a user logs
//   in successfully, their details are stored here so that
//   any screen in the application can access them at any time.
//
// SIMPLE ANALOGY:
//   Think of SessionManager like a visitor badge at an office.
//   When you sign in at the front desk, your name and role are
//   written on the badge. Every room (form) you visit can read
//   your badge to know who you are and what you are allowed to do.
//
// HOW IT WORKS:
//   - When login succeeds: LoginForm fills this class with user info
//   - During the session: any Form reads from this class
//   - When logout: Clear() is called to erase everything
//
// CONNECTED TO:
//   - LoginForm.cs           (fills session after login)
//   - DashboardForm.cs       (reads name and role for display)
//   - CashierDashboardForm   (reads name for display)
//   - BillingForm.cs         (reads cashier name for receipt)
//   - All Forms              (can check IsAdmin or IsCashier)
// ============================================================

namespace Shopping_mart_Management_system.Database
{
    public static class SessionManager
    {
        // The full name of the currently logged-in user
        // Example: "Ali Hassan"
        public static string CurrentUserName { get; set; } = "";

        // The role of the currently logged-in user
        // Value is either "Admin" or "Cashier"
        public static string CurrentRole { get; set; } = "";

        // The database ID of the currently logged-in user
        public static int CurrentUserId { get; set; } = 0;

        // Quick check — returns true if logged in user is Admin
        // Used by forms to show or hide admin-only features
        public static bool IsAdmin => CurrentRole == "Admin";

        // Quick check — returns true if logged in user is Cashier
        public static bool IsCashier => CurrentRole == "Cashier";

        // Clears all session data when the user logs out
        // After this is called the session is completely empty
        public static void Clear()
        {
            CurrentUserName = "";
            CurrentRole = "";
            CurrentUserId = 0;
        }
    }
}