// ============================================================
// FILE: ReportsForm.cs
// LAYER: Forms (Layer 3 - User Interface)
//
// PURPOSE:
//   This screen shows a complete history of all bills saved
//   in the system. The Admin can click any bill to see the
//   individual items that were purchased in that transaction.
//   This screen is NOT accessible to Cashiers.
//
// FLOW:
//   1. Screen loads — all bills shown in the top table
//   2. Admin clicks a bill row in the top table
//   3. The items of that bill appear in the bottom table
//
// CONNECTED TO:
//   - BillRepository.cs  (loads bills and bill items)
//   - Bill.cs            (model for bill data)
//   - BillItem.cs        (model for bill item data)
//   - DashboardForm.cs   (loads this form in content panel)
// ============================================================

using System;
using System.Windows.Forms;
using Shopping_mart_Management_system.Database;

namespace Shopping_mart_Management_system.Forms.Admin
{
    public partial class ReportsForm : Form
    {
        // Repository that handles all Bill database operations
        private BillRepository _billRepo = new BillRepository();

        public ReportsForm()
        {
            InitializeComponent();
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // ─────────────────────────────────────────────────────
        // LOAD DATA
        // Loads all bills from the database and shows them
        // in the top table. Public so Dashboard can call it.
        // ─────────────────────────────────────────────────────
        public void LoadData()
        {
            try
            {
                // Ask BillRepository for all bills
                var bills = _billRepo.GetAllBills();

                // Clear and reload the top table
                dgvBills.DataSource = null;
                dgvBills.Rows.Clear();

                // Set up column headers for bills table
                dgvBills.ColumnCount = 7;
                dgvBills.Columns[0].Name = "ID";
                dgvBills.Columns[0].Width = 50;
                dgvBills.Columns[1].Name = "Invoice";
                dgvBills.Columns[1].Width = 110;
                dgvBills.Columns[2].Name = "Cashier";
                dgvBills.Columns[2].Width = 140;
                dgvBills.Columns[3].Name = "Total (Rs.)";
                dgvBills.Columns[3].Width = 100;
                dgvBills.Columns[4].Name = "Paid (Rs.)";
                dgvBills.Columns[4].Width = 100;
                dgvBills.Columns[5].Name = "Change (Rs.)";
                dgvBills.Columns[5].Width = 100;
                dgvBills.Columns[6].Name = "Date & Time";
                dgvBills.Columns[6].Width = 150;

                // Add one row for each bill
                foreach (var bill in bills)
                {
                    dgvBills.Rows.Add(
                        bill.Id,
                        bill.InvoiceNo,
                        bill.Cashier,
                        bill.Total,
                        bill.AmountPaid,
                        bill.Change,
                        bill.BillDate.ToString("dd/MM/yyyy hh:mm tt")
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading reports: " + ex.Message);
            }
        }

        // ─────────────────────────────────────────────────────
        // BILL ROW CLICKED
        // When the admin clicks a bill in the top table,
        // this method loads that bill's items into the
        // bottom table automatically.
        // ─────────────────────────────────────────────────────
        private void dgvBills_CellClick(object sender,
            DataGridViewCellEventArgs e)
        {
            // Ignore clicks on the header row
            if (e.RowIndex < 0) return;

            // Get the ID of the clicked bill
            int billId = Convert.ToInt32(
                dgvBills.Rows[e.RowIndex].Cells[0].Value);

            try
            {
                // Ask BillRepository for the items of this bill
                var items = _billRepo.GetBillItems(billId);

                // Clear and reload the bottom table
                dgvBillItems.DataSource = null;
                dgvBillItems.Rows.Clear();

                // Set up column headers for items table
                dgvBillItems.ColumnCount = 5;
                dgvBillItems.Columns[0].Name = "Product";
                dgvBillItems.Columns[0].Width = 220;
                dgvBillItems.Columns[1].Name = "Unit Price";
                dgvBillItems.Columns[1].Width = 120;
                dgvBillItems.Columns[2].Name = "Qty";
                dgvBillItems.Columns[2].Width = 80;
                dgvBillItems.Columns[3].Name = "Discount";
                dgvBillItems.Columns[3].Width = 100;
                dgvBillItems.Columns[4].Name = "Total";
                dgvBillItems.Columns[4].Width = 120;

                // Add one row for each item in the bill
                foreach (var item in items)
                {
                    dgvBillItems.Rows.Add(
                        item.ProductName,
                        item.UnitPrice,
                        item.Quantity,
                        item.Discount,
                        item.Total
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading bill items: " + ex.Message);
            }
        }
    }
}