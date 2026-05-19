// ============================================================
// FILE: ProductRepository.cs
// LAYER: Database (Layer 2 - Data Access)
//
// PURPOSE:
//   This file handles ALL database operations related to
//   Products. Any time the application needs to read, add,
//   update, or delete a product, it goes through this file.
//
// METHODS IN THIS FILE:
//   GetAllProducts()  → loads all products from database
//   AddProduct()      → saves a new product to database
//   UpdateProduct()   → updates an existing product
//   DeleteProduct()   → removes a product from database
//   GetTotalCount()   → counts total number of products
//
// CONNECTED TO:
//   - BaseRepository.cs  (inherits GetConnection method)
//   - Product.cs         (uses Product model to hold data)
//   - ProductsForm.cs    (calls all methods here)
//   - BillingForm.cs     (calls GetAllProducts for dropdown)
//   - DashboardForm.cs   (calls GetTotalCount for stat card)
// ============================================================

using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Shopping_mart_Management_system.Models;

namespace Shopping_mart_Management_system.Database
{
    public class ProductRepository : BaseRepository
    {
        // ─────────────────────────────────────────────────────
        // GET ALL PRODUCTS
        // Loads every product from the database and returns
        // them as a list of Product objects, sorted by name.
        //
        // Called by: ProductsForm.cs and BillingForm.cs
        // ─────────────────────────────────────────────────────
        public List<Product> GetAllProducts()
        {
            var products = new List<Product>();

            using (var conn = GetConnection())
            {
                conn.Open();

                string query = "SELECT id, name, price, stock " +
                               "FROM products " +
                               "ORDER BY name ASC";

                var cmd = new MySqlCommand(query, conn);
                var reader = cmd.ExecuteReader();

                // Create one Product object for each row
                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Name = reader["name"].ToString(),
                        Price = Convert.ToDecimal(reader["price"]),
                        Stock = Convert.ToInt32(reader["stock"])
                    });
                }
            }

            return products;
        }

        // ─────────────────────────────────────────────────────
        // ADD PRODUCT
        // Saves a brand new product to the database.
        // Returns true if successful, false if failed.
        //
        // Called by: ProductsForm.cs when ADD PRODUCT is clicked
        // ─────────────────────────────────────────────────────
        public bool AddProduct(Product product)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();

                    string query = "INSERT INTO products (name, price, stock) " +
                                   "VALUES (@name, @price, @stock)";

                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", product.Name);
                    cmd.Parameters.AddWithValue("@price", product.Price);
                    cmd.Parameters.AddWithValue("@stock", product.Stock);
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
        // UPDATE PRODUCT
        // Updates the name, price, and stock of an existing
        // product identified by its ID.
        // Returns true if successful, false if failed.
        //
        // Called by: ProductsForm.cs when UPDATE SELECTED clicked
        // ─────────────────────────────────────────────────────
        public bool UpdateProduct(Product product)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();

                    string query = "UPDATE products " +
                                   "SET name = @name, " +
                                   "price = @price, " +
                                   "stock = @stock " +
                                   "WHERE id = @id";

                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", product.Name);
                    cmd.Parameters.AddWithValue("@price", product.Price);
                    cmd.Parameters.AddWithValue("@stock", product.Stock);
                    cmd.Parameters.AddWithValue("@id", product.Id);
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
        // DELETE PRODUCT
        // Removes a product from the database using its ID.
        // Returns true if deleted, false if failed.
        //
        // Called by: ProductsForm.cs when DELETE SELECTED clicked
        // ─────────────────────────────────────────────────────
        public bool DeleteProduct(int id)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();

                    string query = "DELETE FROM products WHERE id = @id";
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
        // GET TOTAL COUNT
        // Returns the total number of products in the database.
        // Used by the Dashboard to show the Total Products card.
        //
        // Called by: DashboardForm.cs when loading statistics
        // ─────────────────────────────────────────────────────
        public int GetTotalCount()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand(
                    "SELECT COUNT(*) FROM products", conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}