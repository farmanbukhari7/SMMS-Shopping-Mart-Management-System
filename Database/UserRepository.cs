// ============================================================
// FILE: UserRepository.cs
// LAYER: Database (Layer 2 - Data Access)
//
// PURPOSE:
//   This file handles ALL database operations related to Users
//   (both Admins and Cashiers). Any time the application needs
//   to read, add, or delete a user from the database, it goes
//   through this file.
//
// METHODS IN THIS FILE:
//   Login()           → checks if username and password match
//   GetAllCashiers()  → loads all cashier accounts from DB
//   AddCashier()      → saves a new cashier to the database
//   DeleteCashier()   → removes a cashier from the database
//   UsernameExists()  → checks if a username is already taken
//
// CONNECTED TO:
//   - BaseRepository.cs  (inherits GetConnection method)
//   - User.cs            (uses User model to hold data)
//   - LoginForm.cs       (calls Login method)
//   - CashiersForm.cs    (calls GetAllCashiers, Add, Delete)
// ============================================================

using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Shopping_mart_Management_system.Models;

namespace Shopping_mart_Management_system.Database
{
    public class UserRepository : BaseRepository
    {
        // ─────────────────────────────────────────────────────
        // LOGIN
        // Checks if the given username and password exist in
        // the database. If found, returns the User object.
        // If not found, returns null (meaning login failed).
        //
        // Called by: LoginForm.cs when LOGIN button is clicked
        // ─────────────────────────────────────────────────────
        public User Login(string username, string password)
        {
            // Start with null — assume login will fail
            User user = null;

            // Open connection to the database
            using (var conn = GetConnection())
            {
                conn.Open();

                // SQL query: find a user where both username
                // AND password match what was entered
                string query = "SELECT id, full_name, role " +
                               "FROM users " +
                               "WHERE username = @username " +
                               "AND password = @password";

                var cmd = new MySqlCommand(query, conn);

                // @username and @password are safe placeholders
                // that prevent SQL injection attacks
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                var reader = cmd.ExecuteReader();

                // If a matching record is found, fill the User object
                if (reader.Read())
                {
                    user = new User
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        FullName = reader["full_name"].ToString(),
                        Role = reader["role"].ToString()
                    };
                }
            }

            // Return the User object if login succeeded, or null
            return user;
        }

        // ─────────────────────────────────────────────────────
        // GET ALL CASHIERS
        // Loads all users with the role "Cashier" from the
        // database and returns them as a list of User objects.
        //
        // Called by: CashiersForm.cs when the screen loads
        // ─────────────────────────────────────────────────────
        public List<User> GetAllCashiers()
        {
            // Create an empty list to hold the cashiers
            var cashiers = new List<User>();

            using (var conn = GetConnection())
            {
                conn.Open();

                // Get all users where role is Cashier
                // Order by newest first (id DESC)
                string query = "SELECT id, full_name, username, " +
                               "password, created_at " +
                               "FROM users " +
                               "WHERE role = 'Cashier' " +
                               "ORDER BY id DESC";

                var cmd = new MySqlCommand(query, conn);
                var reader = cmd.ExecuteReader();

                // Loop through every row returned and
                // create a User object for each one
                while (reader.Read())
                {
                    cashiers.Add(new User
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        FullName = reader["full_name"].ToString(),
                        Username = reader["username"].ToString(),
                        Password = reader["password"].ToString()
                    });
                }
            }

            return cashiers;
        }

        // ─────────────────────────────────────────────────────
        // ADD CASHIER
        // Saves a new cashier account to the database.
        // Returns true if saved successfully, false if failed.
        //
        // Called by: CashiersForm.cs when ADD CASHIER is clicked
        // ─────────────────────────────────────────────────────
        public bool AddCashier(User user)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();

                    // INSERT a new row into the users table
                    // with role fixed as 'Cashier'
                    string query = "INSERT INTO users " +
                                   "(full_name, username, password, role) " +
                                   "VALUES (@name, @username, @password, 'Cashier')";

                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", user.FullName);
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.ExecuteNonQuery();

                    return true; // Saved successfully
                }
            }
            catch
            {
                return false; // Something went wrong
            }
        }

        // ─────────────────────────────────────────────────────
        // DELETE CASHIER
        // Removes a cashier from the database using their ID.
        // Returns true if deleted, false if failed.
        //
        // Called by: CashiersForm.cs when DELETE is clicked
        // ─────────────────────────────────────────────────────
        public bool DeleteCashier(int id)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();

                    // DELETE the row where id matches
                    string query = "DELETE FROM users WHERE id = @id";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        // ─────────────────────────────────────────────────────
        // USERNAME EXISTS
        // Checks if a username is already taken in the database.
        // Returns true if taken, false if available.
        //
        // Called by: CashiersForm.cs before adding a new cashier
        // ─────────────────────────────────────────────────────
        public bool UsernameExists(string username)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                // COUNT how many users have this username
                // If count > 0 then username is already taken
                string query = "SELECT COUNT(*) FROM users " +
                               "WHERE username = @username";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
    }
}