// ============================================================
// FILE: BillingForm.cs
// LAYER: Forms (Layer 3 - User Interface)
//
// PURPOSE:
//   This is the most important screen in the application.
//   It is used by both Admin and Cashier to create customer
//   bills. Products are selected, quantities and discounts
//   are entered, and the bill is saved to the database.
//
// FLOW:
//   1. Screen loads — products fill the dropdown automatically
//   2. User selects a product — unit price auto-fills
//   3. User enters quantity and optional discount
//   4. User clicks ADD TO BILL — item added to table
//   5. Summary panel updates automatically (subtotal, tax etc.)
//   6. User types amount paid — change shows instantly
//   7. User clicks SAVE & PRINT BILL:
//      → Bill saved to database via BillRepository
//      → Receipt form opens showing full bill details
//   8. Bill stays on screen until RESET BILL is clicked
//
// CONNECTED TO:
//   - ProductRepository.cs  (loads products for dropdown)
//   - BillRepository.cs     (saves bill and gets invoice no.)
//   - SessionManager.cs     (reads cashier name)
//   - ReceiptForm.cs        (opened after bill is saved)
//   - Bill.cs               (model for bill header data)
//   - BillItem.cs           (model for each item in the bill)
// ============================================================

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Shopping_mart_Management_system.Database;
using Shopping_mart_Management_system.Models;

namespace Shopping_mart_Management_system.Forms.Admin
{
    public partial class BillingForm : Form
    {
        // Repositories used to talk to the database
        private ProductRepository _productRepo =
            new ProductRepository();
        private BillRepository _billRepo =
            new BillRepository();

        // A DataTable used to display bill items in the grid
        // Each row = one product added to the current bill
        private DataTable _billItems = new DataTable();

        // Stores the current invoice number (e.g. "INV-0006")
        private string _invoiceNumber = "INV-0001";

        public BillingForm()
        {
            InitializeComponent();

            // Set up the bill items table structure
            // This must run before anything else
            SetupBillTable();
        }

        private void BillingForm_Load(object sender, EventArgs e)
        {
            // Wire up live change calculation events
            txtAmountPaid.TextChanged +=
                new EventHandler(txtAmountPaid_TextChanged);
            txtTax.TextChanged +=
                new EventHandler(txtTax_TextChanged);

            // Load everything needed for billing
            LoadData();
        }

        // ─────────────────────────────────────────────────────
        // LOAD DATA
        // Called when form opens or when navigating back to it.
        // Public so DashboardForm can call it directly.
        // ─────────────────────────────────────────────────────
        public void LoadData()
        {
            LoadProducts();
            GenerateInvoiceNumber();
            UpdateDateTime();
            lblCashierName.Text =
                "Cashier: " + SessionManager.CurrentUserName;
        }

        // ─────────────────────────────────────────────────────
        // SETUP BILL TABLE
        // Creates the columns for the bill items DataTable.
        // The DataTable is bound to the grid on screen.
        // ─────────────────────────────────────────────────────
        private void SetupBillTable()
        {
            // Prevent setting up columns more than once
            if (_billItems.Columns.Count > 0) return;

            // Define the columns for the bill items table
            _billItems.Columns.Add("ProductName", typeof(string));
            _billItems.Columns.Add("UnitPrice", typeof(decimal));
            _billItems.Columns.Add("Quantity", typeof(int));
            _billItems.Columns.Add("Discount", typeof(decimal));
            _billItems.Columns.Add("Total", typeof(decimal));

            // Bind the DataTable to the grid on screen
            dgvBillItems.DataSource = _billItems;

            // Set column header names and widths
            dgvBillItems.Columns["ProductName"].HeaderText = "Product";
            dgvBillItems.Columns["ProductName"].Width = 200;
            dgvBillItems.Columns["UnitPrice"].HeaderText = "Unit Price";
            dgvBillItems.Columns["UnitPrice"].Width = 100;
            dgvBillItems.Columns["Quantity"].HeaderText = "Qty";
            dgvBillItems.Columns["Quantity"].Width = 60;
            dgvBillItems.Columns["Discount"].HeaderText = "Disc.";
            dgvBillItems.Columns["Discount"].Width = 70;
            dgvBillItems.Columns["Total"].HeaderText = "Total";
            dgvBillItems.Columns["Total"].Width = 100;
        }

        // ─────────────────────────────────────────────────────
        // LOAD PRODUCTS
        // Gets all products from the database using
        // ProductRepository and fills the dropdown list.
        // ─────────────────────────────────────────────────────
        private void LoadProducts()
        {
            try
            {
                // Ask ProductRepository for all products
                var products = _productRepo.GetAllProducts();

                cmbProducts.Items.Clear();

                // Add each product to the dropdown list
                // ProductItem is a helper class (see bottom)
                // that shows the product name in the dropdown
                foreach (var p in products)
                {
                    cmbProducts.Items.Add(new ProductItem
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price
                    });
                }

                cmbProducts.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading products: " + ex.Message);
            }
        }

        // ─────────────────────────────────────────────────────
        // GENERATE INVOICE NUMBER
        // Asks BillRepository for the next invoice number
        // and displays it at the top of the billing screen.
        // ─────────────────────────────────────────────────────
        private void GenerateInvoiceNumber()
        {
            try
            {
                _invoiceNumber =
                    _billRepo.GetNextInvoiceNumber();
                lblInvoiceNo.Text =
                    "Invoice: #" + _invoiceNumber;
            }
            catch
            {
                lblInvoiceNo.Text = "Invoice: #INV-0001";
            }
        }

        // Updates the date and time label on the screen
        private void UpdateDateTime()
        {
            lblDateTime.Text = "Date: " +
                DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
        }

        // ─────────────────────────────────────────────────────
        // PRODUCT SELECTED FROM DROPDOWN
        // When the user selects a product from the dropdown,
        // the unit price automatically fills in the text box.
        // ─────────────────────────────────────────────────────
        private void cmbProducts_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            if (cmbProducts.SelectedItem is ProductItem p)
                txtUnitPrice.Text = p.Price.ToString("F2");
        }

        // ─────────────────────────────────────────────────────
        // ADD TO BILL BUTTON CLICKED
        // Validates input then adds the selected product
        // as a new row in the bill items table.
        // Totals are recalculated automatically after adding.
        // ─────────────────────────────────────────────────────
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            // Make sure a product is selected
            if (cmbProducts.SelectedItem == null)
            {
                MessageBox.Show(
                    "Please select a product.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Validate quantity
            if (!int.TryParse(txtQuantity.Text, out int qty)
                || qty <= 0)
            {
                MessageBox.Show(
                    "Please enter a valid quantity.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Get discount — default to 0 if empty or invalid
            if (!decimal.TryParse(
                txtDiscount.Text, out decimal disc))
                disc = 0;

            var product = (ProductItem)cmbProducts.SelectedItem;

            // Calculate the total for this line item
            // Formula: (Price - Discount) x Quantity
            decimal total = (product.Price - disc) * qty;

            // Add a new row to the bill items DataTable
            DataRow newRow = _billItems.NewRow();
            newRow["ProductName"] = product.Name;
            newRow["UnitPrice"] = product.Price;
            newRow["Quantity"] = qty;
            newRow["Discount"] = disc;
            newRow["Total"] = total;
            _billItems.Rows.Add(newRow);

            // Update the summary panel totals
            CalculateTotals();

            // Reset input fields for the next item
            txtQuantity.Text = "1";
            txtDiscount.Text = "0";
            txtUnitPrice.Text = "";
            cmbProducts.SelectedIndex = -1;
        }

        // ─────────────────────────────────────────────────────
        // REMOVE ITEM BUTTON CLICKED
        // Removes the selected row from the bill items table.
        // ─────────────────────────────────────────────────────
        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvBillItems.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select an item to remove.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int index = dgvBillItems.SelectedRows[0].Index;
            _billItems.Rows[index].Delete();
            CalculateTotals();
        }

        // ─────────────────────────────────────────────────────
        // CALCULATE TOTALS
        // Loops through all rows in the bill items table and
        // calculates subtotal, discount, tax, and total.
        // Updates all labels in the summary panel.
        // ─────────────────────────────────────────────────────
        private void CalculateTotals()
        {
            decimal subTotal = 0;
            decimal totalDiscount = 0;

            // Add up values from every row in the bill
            foreach (DataRow row in _billItems.Rows)
            {
                decimal unitPrice =
                    Convert.ToDecimal(row["UnitPrice"]);
                int qty =
                    Convert.ToInt32(row["Quantity"]);
                decimal disc =
                    Convert.ToDecimal(row["Discount"]);

                subTotal += unitPrice * qty;
                totalDiscount += disc * qty;
            }

            // Calculate tax on the discounted amount
            decimal taxPercent = 0;
            decimal.TryParse(txtTax.Text, out taxPercent);
            decimal taxAmount =
                (subTotal - totalDiscount) * taxPercent / 100;
            decimal total =
                subTotal - totalDiscount + taxAmount;

            // Update the labels in the summary panel
            lblSubTotal.Text = "Rs. " + subTotal.ToString("F2");
            lblDiscount.Text = "Rs. " + totalDiscount.ToString("F2");
            lblTaxAmount.Text = "Rs. " + taxAmount.ToString("F2");
            lblTotal.Text = "Rs. " + total.ToString("F2");

            // Recalculate change with updated total
            CalculateChange();
        }

        // ─────────────────────────────────────────────────────
        // CALCULATE CHANGE
        // Calculates how much change to return to the customer.
        // Runs every time the Amount Paid field changes.
        // ─────────────────────────────────────────────────────
        private void CalculateChange()
        {
            try
            {
                string totalText =
                    lblTotal.Text.Replace("Rs. ", "").Trim();

                if (decimal.TryParse(totalText, out decimal total)
                    && decimal.TryParse(
                        txtAmountPaid.Text.Trim(), out decimal paid))
                {
                    decimal change = paid - total;
                    lblChange.Text = "Rs. " + change.ToString("F2");

                    // Green if enough paid, red if not enough
                    lblChange.ForeColor = change >= 0 ?
                        System.Drawing.Color.FromArgb(40, 167, 69) :
                        System.Drawing.Color.FromArgb(220, 80, 80);
                }
                else
                {
                    lblChange.Text = "Rs. 0.00";
                }
            }
            catch { }
        }

        // These run every time the user types in these boxes
        private void txtAmountPaid_TextChanged(
            object sender, EventArgs e) => CalculateChange();

        private void txtTax_TextChanged(
            object sender, EventArgs e) => CalculateTotals();

        // ─────────────────────────────────────────────────────
        // SAVE & PRINT BILL BUTTON CLICKED
        // Validates the bill, builds Bill and BillItem objects,
        // saves everything to the database via BillRepository,
        // then opens the ReceiptForm to show the receipt.
        // ─────────────────────────────────────────────────────
        private void btnSaveBill_Click(object sender, EventArgs e)
        {
            // Bill must have at least one item
            if (_billItems.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Please add items to the bill first.",
                    "Empty Bill",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Amount paid must be entered
            if (!decimal.TryParse(
                txtAmountPaid.Text, out decimal paid))
            {
                MessageBox.Show(
                    "Please enter the amount paid.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            decimal total = decimal.Parse(
                lblTotal.Text.Replace("Rs. ", ""));

            // Amount paid must cover the total
            if (paid < total)
            {
                MessageBox.Show(
                    "Amount paid is less than total bill!",
                    "Insufficient Amount",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Parse all summary values
            decimal subTotal = decimal.Parse(
                lblSubTotal.Text.Replace("Rs. ", ""));
            decimal discount = decimal.Parse(
                lblDiscount.Text.Replace("Rs. ", ""));
            decimal tax = decimal.Parse(
                lblTaxAmount.Text.Replace("Rs. ", ""));
            decimal change = paid - total;

            // Build the Bill object (header information)
            var bill = new Bill
            {
                InvoiceNo = _invoiceNumber,
                Cashier = SessionManager.CurrentUserName,
                SubTotal = subTotal,
                Discount = discount,
                Tax = tax,
                Total = total,
                AmountPaid = paid,
                Change = change
            };

            // Build the list of BillItem objects
            // One BillItem for each row in the table
            var items = new List<BillItem>();
            foreach (DataRow row in _billItems.Rows)
            {
                items.Add(new BillItem
                {
                    ProductName = row["ProductName"].ToString(),
                    UnitPrice = Convert.ToDecimal(row["UnitPrice"]),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    Discount = Convert.ToDecimal(row["Discount"]),
                    Total = Convert.ToDecimal(row["Total"])
                });
            }

            // Ask BillRepository to save the bill and all items
            bool saved = _billRepo.SaveBill(bill, items);

            if (saved)
            {
                // Get tax percentage for receipt display
                decimal taxPct = 0;
                decimal.TryParse(txtTax.Text, out taxPct);

                // Open the receipt form to show the bill
                var receipt = new ReceiptForm();
                receipt.LoadReceipt(
                    _invoiceNumber,
                    SessionManager.CurrentUserName,
                    DateTime.Now,
                    _billItems,
                    subTotal, discount,
                    taxPct, tax,
                    total, paid, change);
                receipt.ShowDialog();

                // Bill stays on screen until Reset is clicked
            }
            else
            {
                MessageBox.Show(
                    "Error saving bill. Please try again.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────
        // RESET BILL BUTTON CLICKED
        // Clears all items and resets the billing screen
        // ready for a new customer transaction.
        // ─────────────────────────────────────────────────────
        private void btnResetBill_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Reset the current bill? All items will be cleared.",
                "Confirm Reset",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
                ResetBill();
        }

        // Clears everything and prepares for a fresh bill
        private void ResetBill()
        {
            _billItems.Clear();
            txtAmountPaid.Clear();
            txtQuantity.Text = "1";
            txtDiscount.Text = "0";
            txtTax.Text = "5";
            txtUnitPrice.Text = "";
            cmbProducts.SelectedIndex = -1;
            lblSubTotal.Text = "Rs. 0.00";
            lblDiscount.Text = "Rs. 0.00";
            lblTaxAmount.Text = "Rs. 0.00";
            lblTotal.Text = "Rs. 0.00";
            lblChange.Text = "Rs. 0.00";

            // Generate a new invoice number for next bill
            GenerateInvoiceNumber();
            UpdateDateTime();
        }
    }

    // ─────────────────────────────────────────────────────────
    // HELPER CLASS: ProductItem
    // Used to display products in the ComboBox dropdown.
    // The ComboBox shows the Name property as the visible text
    // but we can also access Id and Price when needed.
    // ─────────────────────────────────────────────────────────
    public class ProductItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        // This makes the ComboBox show the product name
        public override string ToString() => Name;
    }
}