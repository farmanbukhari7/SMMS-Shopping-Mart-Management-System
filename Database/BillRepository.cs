// ============================================================
// FILE: BillRepository.cs
// LAYER: Database (Layer 2 - Data Access)
//
// PURPOSE:
//   This file handles ALL database operations related to Bills
//   and Bill Items. It saves new bills, loads past bills for
//   the reports screen, and provides statistics for the
//   Admin Dashboard.
//
// METHODS IN THIS FILE:
//   SaveBill()           → saves a complete bill with all items
//   GetAllBills()        → loads all bills for Reports screen
//   GetBillItems()       → loads items of one specific bill
//   GetTodayBillCount()  → counts today's bills for Dashboard
//   GetTodayRevenue()    → sums today's revenue for Dashboard
//   GetNextInvoiceNo()   → generates the next invoice number
//
// CONNECTED TO:
//   - BaseRepository.cs  (inherits GetConnection method)
//   - Bill.cs            (uses Bill model)
//   - BillItem.cs        (uses BillItem model)
//   - BillingForm.cs     (calls SaveBill, GetNextInvoiceNo)
//   - ReportsForm.cs     (calls GetAllBills, GetBillItems)
//   - DashboardForm.cs   (calls GetTodayBillCount, GetTodayRevenue)
// ============================================================

using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Shopping_mart_Management_system.Models;

namespace Shopping_mart_Management_system.Database
{
    public class BillRepository : BaseRepository
    {
        // ─────────────────────────────────────────────────────
        // SAVE BILL
        // Saves a complete bill AND all its items to the
        // database in one go. Uses a Transaction to make sure
        // either EVERYTHING saves or NOTHING saves.
        //
        // A Transaction means: if saving the bill items fails
        // after the bill header was saved, the whole thing is
        // cancelled (rolled back) to keep data consistent.
        //
        // Called by: BillingForm.cs when SAVE & PRINT is clicked
        // ─────────────────────────────────────────────────────
        public bool SaveBill(Bill bill, List<BillItem> items)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                // Start a transaction — all or nothing
                var transaction = conn.BeginTransaction();

                try
                {
                    // Step 1: Save the main bill header
                    string billQuery =
                        "INSERT INTO bills (invoice_no, cashier, sub_total, " +
                        "discount, tax, total, amount_paid, change_amount) " +
                        "VALUES (@inv, @cashier, @sub, @disc, @tax, " +
                        "@total, @paid, @change)";

                    var billCmd = new MySqlCommand(billQuery, conn, transaction);
                    billCmd.Parameters.AddWithValue("@inv", bill.InvoiceNo);
                    billCmd.Parameters.AddWithValue("@cashier", bill.Cashier);
                    billCmd.Parameters.AddWithValue("@sub", bill.SubTotal);
                    billCmd.Parameters.AddWithValue("@disc", bill.Discount);
                    billCmd.Parameters.AddWithValue("@tax", bill.Tax);
                    billCmd.Parameters.AddWithValue("@total", bill.Total);
                    billCmd.Parameters.AddWithValue("@paid", bill.AmountPaid);
                    billCmd.Parameters.AddWithValue("@change", bill.Change);
                    billCmd.ExecuteNonQuery();

                    // Step 2: Get the ID that was auto-assigned
                    // to the bill we just saved
                    long billId = billCmd.LastInsertedId;

                    // Step 3: Save each item linked to that bill
                    foreach (var item in items)
                    {
                        string itemQuery =
                            "INSERT INTO bill_items (bill_id, product_name, " +
                            "unit_price, quantity, discount, total) " +
                            "VALUES (@bid, @name, @price, @qty, @disc, @total)";

                        var itemCmd = new MySqlCommand(
                            itemQuery, conn, transaction);
                        itemCmd.Parameters.AddWithValue("@bid", billId);
                        itemCmd.Parameters.AddWithValue("@name", item.ProductName);
                        itemCmd.Parameters.AddWithValue("@price", item.UnitPrice);
                        itemCmd.Parameters.AddWithValue("@qty", item.Quantity);
                        itemCmd.Parameters.AddWithValue("@disc", item.Discount);
                        itemCmd.Parameters.AddWithValue("@total", item.Total);
                        itemCmd.ExecuteNonQuery();
                    }

                    // All saved successfully — confirm the transaction
                    transaction.Commit();
                    return true;
                }
                catch
                {
                    // Something went wrong — undo everything
                    transaction.Rollback();
                    return false;
                }
            }
        }

        // ─────────────────────────────────────────────────────
        // GET ALL BILLS
        // Loads all bills from the database, newest first.
        // Used by the Reports screen to show all transactions.
        //
        // Called by: ReportsForm.cs when the screen loads
        // ─────────────────────────────────────────────────────
        public List<Bill> GetAllBills()
        {
            var bills = new List<Bill>();

            using (var conn = GetConnection())
            {
                conn.Open();

                string query =
                    "SELECT id, invoice_no, cashier, total, " +
                    "amount_paid, change_amount, bill_date " +
                    "FROM bills " +
                    "ORDER BY bill_date DESC";

                var cmd = new MySqlCommand(query, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    bills.Add(new Bill
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        InvoiceNo = reader["invoice_no"].ToString(),
                        Cashier = reader["cashier"].ToString(),
                        Total = Convert.ToDecimal(reader["total"]),
                        AmountPaid = Convert.ToDecimal(reader["amount_paid"]),
                        Change = Convert.ToDecimal(reader["change_amount"]),
                        BillDate = Convert.ToDateTime(reader["bill_date"])
                    });
                }
            }

            return bills;
        }

        // ─────────────────────────────────────────────────────
        // GET BILL ITEMS
        // Loads all items that belong to one specific bill.
        // Used when the user clicks a bill row in Reports.
        //
        // Called by: ReportsForm.cs when a bill row is clicked
        // ─────────────────────────────────────────────────────
        public List<BillItem> GetBillItems(int billId)
        {
            var items = new List<BillItem>();

            using (var conn = GetConnection())
            {
                conn.Open();

                string query =
                    "SELECT product_name, unit_price, " +
                    "quantity, discount, total " +
                    "FROM bill_items " +
                    "WHERE bill_id = @id";

                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", billId);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    items.Add(new BillItem
                    {
                        ProductName = reader["product_name"].ToString(),
                        UnitPrice = Convert.ToDecimal(reader["unit_price"]),
                        Quantity = Convert.ToInt32(reader["quantity"]),
                        Discount = Convert.ToDecimal(reader["discount"]),
                        Total = Convert.ToDecimal(reader["total"])
                    });
                }
            }

            return items;
        }

        // ─────────────────────────────────────────────────────
        // GET TODAY BILL COUNT
        // Counts how many bills were created today.
        // Used by Dashboard for the "Today's Bills" stat card.
        //
        // Called by: DashboardForm.cs when loading statistics
        // ─────────────────────────────────────────────────────
        public int GetTodayBillCount()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand(
                    "SELECT COUNT(*) FROM bills " +
                    "WHERE DATE(bill_date) = CURDATE()", conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // ─────────────────────────────────────────────────────
        // GET TODAY REVENUE
        // Adds up the total amount from all bills created today.
        // Used by Dashboard for the "Today's Revenue" stat card.
        //
        // Called by: DashboardForm.cs when loading statistics
        // ─────────────────────────────────────────────────────
        public decimal GetTodayRevenue()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand(
                    "SELECT IFNULL(SUM(total), 0) FROM bills " +
                    "WHERE DATE(bill_date) = CURDATE()", conn);
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }

        // ─────────────────────────────────────────────────────
        // GET NEXT INVOICE NUMBER
        // Calculates what the next invoice number should be.
        // For example: if 5 bills exist, next is INV-0006
        //
        // Called by: BillingForm.cs when the screen loads
        // ─────────────────────────────────────────────────────
        public string GetNextInvoiceNumber()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand(
                    "SELECT COUNT(*) FROM bills", conn);
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                // Format as INV-0001, INV-0002 etc.
                return $"INV-{(count + 1):D4}";
            }
        }
    }
}