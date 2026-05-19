// ============================================================
// FILE: User.cs
// LAYER: Models (Layer 1 - Data Blueprint)
//
// PURPOSE:
//   This file describes what a User looks like in our system.
//   A User can be either an Administrator or a Cashier.
//   Both share the same structure but have different roles.
//
// HOW IT IS USED:
//   When someone logs in, their details are loaded from the
//   database into a User object. The role property decides
//   which dashboard they see after login.
//
// CONNECTED TO:
//   - UserRepository.cs  (loads and saves user data)
//   - LoginForm.cs       (checks username and password)
//   - SessionManager.cs  (stores the logged-in user's info)
//   - CashiersForm.cs    (shows cashier users in the table)
// ============================================================

namespace Shopping_mart_Management_system.Models
{
    public class User
    {
        // The unique ID number of the user in the database
        public int Id { get; set; }

        // The full name of the user (e.g. "Ali Hassan")
        public string FullName { get; set; }

        // The username used to log into the system (e.g. "ali")
        public string Username { get; set; }

        // The password used to log into the system
        public string Password { get; set; }

        // The role of this user — either "Admin" or "Cashier"
        // This decides what screens they can access
        public string Role { get; set; }
    }
}