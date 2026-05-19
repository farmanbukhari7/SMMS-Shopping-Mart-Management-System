// ============================================================
// FILE: DbConnection.cs
// LAYER: Database (Layer 2 - Data Access)
//
// PURPOSE:
//   Holds the MySQL connection string used by all repositories.
//   Also handles automatic database and table creation so
//   the professor does not need to run any SQL scripts.
//
// CONNECTED TO:
//   - BaseRepository.cs  (reads ConnectionString)
//   - Program.cs         (calls setup methods on startup)
// ============================================================

using System;
using System.IO;
using MySql.Data.MySqlClient;

namespace Shopping_mart_Management_system.Database
{
    public static class DbConnection
    {
        // The connection string used by all repositories
        public static string ConnectionString = "";

        // Path of the settings file that remembers the password
        private static string SettingsFile = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "db_settings.txt");

        // ─────────────────────────────────────────────────────
        // LOAD SAVED PASSWORD
        // Checks if a password was saved from a previous run.
        // Returns the saved password or empty string if none.
        // ─────────────────────────────────────────────────────
        public static string LoadSavedPassword()
        {
            if (File.Exists(SettingsFile))
                return File.ReadAllText(SettingsFile).Trim();

            return "";
        }

        // ─────────────────────────────────────────────────────
        // SET PASSWORD
        // Builds the connection string using the given password
        // and saves the password to file for next time.
        // ─────────────────────────────────────────────────────
        public static void SetPassword(string password)
        {
            // Build connection string with given password
            ConnectionString =
                "Server=localhost;" +
                "Database=MartBillingDB;" +
                "Uid=root;" +
                $"Pwd={password};";

            // Save password to file so we remember it next time
            File.WriteAllText(SettingsFile, password);
        }

        // ─────────────────────────────────────────────────────
        // TEST CONNECTION
        // Tries to connect to MySQL using current connection
        // string. Returns true if successful, false if not.
        // ─────────────────────────────────────────────────────
        public static bool TestConnection()
        {
            try
            {
                // Try connecting to MySQL server only (no DB yet)
                // because the database might not exist yet
                string serverOnly =
                    "Server=localhost;" +
                    "Uid=root;" +
                    $"Pwd={GetPasswordFromString()};";

                using (var conn = new MySqlConnection(serverOnly))
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        // ─────────────────────────────────────────────────────
        // AUTO SETUP DATABASE
        // Creates the database, all tables, and inserts the
        // default admin account and sample products.
        // This runs automatically so no SQL script is needed.
        // ─────────────────────────────────────────────────────
        public static void AutoSetupDatabase()
        {
            // Connect to MySQL server without specifying a DB
            // because MartBillingDB might not exist yet
            string serverOnly =
                "Server=localhost;" +
                "Uid=root;" +
                $"Pwd={GetPasswordFromString()};";

            using (var conn = new MySqlConnection(serverOnly))
            {
                conn.Open();

                // Step 1: Create the database if it doesn't exist
                ExecuteQuery(conn,
                    "CREATE DATABASE IF NOT EXISTS MartBillingDB;");

                // Step 2: Switch to using that database
                ExecuteQuery(conn, "USE MartBillingDB;");

                // Step 3: Create users table
                ExecuteQuery(conn, @"
                    CREATE TABLE IF NOT EXISTS users (
                        id         INT AUTO_INCREMENT PRIMARY KEY,
                        full_name  VARCHAR(100) NOT NULL,
                        username   VARCHAR(50)  NOT NULL UNIQUE,
                        password   VARCHAR(100) NOT NULL,
                        role       ENUM('Admin','Cashier') NOT NULL,
                        created_at DATETIME DEFAULT CURRENT_TIMESTAMP
                    );");

                // Step 4: Create products table
                ExecuteQuery(conn, @"
                    CREATE TABLE IF NOT EXISTS products (
                        id    INT AUTO_INCREMENT PRIMARY KEY,
                        name  VARCHAR(100)  NOT NULL,
                        price DECIMAL(10,2) NOT NULL,
                        stock INT DEFAULT 0
                    );");

                // Step 5: Create bills table
                ExecuteQuery(conn, @"
                    CREATE TABLE IF NOT EXISTS bills (
                        id            INT AUTO_INCREMENT PRIMARY KEY,
                        invoice_no    VARCHAR(20),
                        cashier       VARCHAR(50),
                        sub_total     DECIMAL(10,2),
                        discount      DECIMAL(10,2),
                        tax           DECIMAL(10,2),
                        total         DECIMAL(10,2),
                        amount_paid   DECIMAL(10,2),
                        change_amount DECIMAL(10,2),
                        bill_date     DATETIME DEFAULT CURRENT_TIMESTAMP
                    );");

                // Step 6: Create bill_items table
                ExecuteQuery(conn, @"
                    CREATE TABLE IF NOT EXISTS bill_items (
                        id           INT AUTO_INCREMENT PRIMARY KEY,
                        bill_id      INT,
                        product_name VARCHAR(100),
                        unit_price   DECIMAL(10,2),
                        quantity     INT,
                        discount     DECIMAL(10,2),
                        total        DECIMAL(10,2),
                        FOREIGN KEY (bill_id) REFERENCES bills(id)
                    );");

                // Step 7: Insert default Admin account
                // INSERT IGNORE means skip if already exists
                ExecuteQuery(conn, @"
                    INSERT IGNORE INTO users
                        (full_name, username, password, role)
                    VALUES
                        ('Administrator','admin','admin123','Admin');");

                // Step 8: Insert sample products
                // Step 8: Insert sample products ONLY if table is empty
                // This prevents duplicate products on every startup
                var checkCmd = new MySqlCommand(
                    "SELECT COUNT(*) FROM products;", conn);
                int productCount =
                    Convert.ToInt32(checkCmd.ExecuteScalar());

                if (productCount == 0)
                {
                    ExecuteQuery(conn, @"
        INSERT INTO products (name, price, stock)
        VALUES
            ('Lays Chips 50g',  50.00, 100),
            ('Coca-Cola 500ml', 40.00, 150),
            ('Bread Loaf',      80.00,  50),
            ('Milk 1L',        120.00,  80),
            ('Biscuits Pack',   30.00, 200);");
                }
            }
        }

        // Helper method to run a single SQL query
        private static void ExecuteQuery(
            MySqlConnection conn, string query)
        {
            using (var cmd = new MySqlCommand(query, conn))
                cmd.ExecuteNonQuery();
        }

        // Helper method to extract password from connection string
        private static string GetPasswordFromString()
        {
            // Find the Pwd= part in the connection string
            foreach (var part in ConnectionString.Split(';'))
            {
                if (part.Trim().StartsWith("Pwd="))
                    return part.Trim().Substring(4);
            }
            return "";
        }
    }
}