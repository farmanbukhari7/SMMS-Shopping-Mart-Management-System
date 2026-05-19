// ============================================================
// FILE: ProductsForm.cs
// LAYER: Forms (Layer 3 - User Interface)
//
// PURPOSE:
//   This screen allows the Administrator to manage products.
//   Admin can add new products, update existing ones, and
//   delete products. This screen is NOT accessible to Cashiers.
//
// FLOW:
//   1. Screen loads and shows all products in the table
//   2. Admin clicks a row → fields fill up automatically
//   3. Admin can then:
//      - Change the fields and click UPDATE SELECTED to edit
//      - Click DELETE SELECTED to remove the product
//      - Clear fields and fill new info → ADD PRODUCT
//      - Click CLEAR to reset all fields
//
// CONNECTED TO:
//   - ProductRepository.cs  (handles all database operations)
//   - Product.cs            (model used to pass product data)
//   - DashboardForm.cs      (loads this form in content panel)
// ============================================================

using System;
using System.Windows.Forms;
using Shopping_mart_Management_system.Database;
using Shopping_mart_Management_system.Models;

namespace Shopping_mart_Management_system.Forms.Admin
{
    public partial class ProductsForm : Form
    {
        // Repository that handles all Product database operations
        private ProductRepository _productRepo = new ProductRepository();

        // Stores the ID of the product selected in the table.
        // -1 means no product is selected.
        private int _selectedProductId = -1;

        public ProductsForm()
        {
            InitializeComponent();
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            // Load all products when the form opens
            LoadData();

            // Wire up the row click event so clicking a row
            // fills the input fields automatically
            dgvProducts.CellClick +=
                new DataGridViewCellEventHandler(DgvProducts_CellClick);
        }

        // ─────────────────────────────────────────────────────
        // LOAD DATA
        // Loads all products from the database and shows
        // them in the table. Called on load and after changes.
        // Public so DashboardForm can call it directly.
        // ─────────────────────────────────────────────────────
        public void LoadData()
        {
            try
            {
                // Ask ProductRepository for all products
                var products = _productRepo.GetAllProducts();

                // Clear and reload the table
                dgvProducts.DataSource = null;
                dgvProducts.Rows.Clear();

                // Set up column headers
                dgvProducts.ColumnCount = 4;
                dgvProducts.Columns[0].Name = "ID";
                dgvProducts.Columns[0].Width = 50;
                dgvProducts.Columns[1].Name = "Product Name";
                dgvProducts.Columns[1].Width = 220;
                dgvProducts.Columns[2].Name = "Price (Rs.)";
                dgvProducts.Columns[2].Width = 120;
                dgvProducts.Columns[3].Name = "Stock";
                dgvProducts.Columns[3].Width = 100;

                // Add one row for each product in the list
                foreach (var product in products)
                {
                    dgvProducts.Rows.Add(
                        product.Id,
                        product.Name,
                        product.Price,
                        product.Stock
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message);
            }
        }

        // ─────────────────────────────────────────────────────
        // ROW CLICKED IN TABLE
        // When the admin clicks a row in the product table,
        // the product details fill into the input fields
        // so the admin can easily edit or delete it.
        // ─────────────────────────────────────────────────────
        private void DgvProducts_CellClick(object sender,
            DataGridViewCellEventArgs e)
        {
            // Make sure a valid row was clicked (not the header)
            if (e.RowIndex >= 0)
            {
                var row = dgvProducts.Rows[e.RowIndex];

                // Remember which product is selected
                _selectedProductId =
                    Convert.ToInt32(row.Cells[0].Value);

                // Fill the input fields with the selected
                // product's current details
                txtProductName.Text =
                    row.Cells[1].Value.ToString();
                txtPrice.Text =
                    row.Cells[2].Value.ToString();
                txtStock.Text =
                    row.Cells[3].Value.ToString();
            }
        }

        // ─────────────────────────────────────────────────────
        // ADD PRODUCT BUTTON CLICKED
        // Reads input fields, creates a Product object,
        // and saves it to the database via ProductRepository.
        // ─────────────────────────────────────────────────────
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            // Validate — make sure no field is empty
            if (string.IsNullOrEmpty(txtProductName.Text) ||
                string.IsNullOrEmpty(txtPrice.Text) ||
                string.IsNullOrEmpty(txtStock.Text))
            {
                MessageBox.Show(
                    "Please fill in all fields.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Validate — price and stock must be valid numbers
            if (!decimal.TryParse(txtPrice.Text, out decimal price) ||
                !int.TryParse(txtStock.Text, out int stock))
            {
                MessageBox.Show(
                    "Price and Stock must be valid numbers!",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Create a Product object with the entered details
            var product = new Product
            {
                Name = txtProductName.Text.Trim(),
                Price = price,
                Stock = stock
            };

            // Ask ProductRepository to save it to the database
            bool saved = _productRepo.AddProduct(product);

            if (saved)
            {
                MessageBox.Show(
                    "Product added successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                ClearFields();
                LoadData();
            }
            else
            {
                MessageBox.Show(
                    "Failed to add product.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────
        // UPDATE PRODUCT BUTTON CLICKED
        // Updates the selected product's details in the DB.
        // The admin must click a row first to select a product.
        // ─────────────────────────────────────────────────────
        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            // Make sure a product is selected
            if (_selectedProductId == -1)
            {
                MessageBox.Show(
                    "Please click a product row first to select it.",
                    "No Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Validate numbers
            if (!decimal.TryParse(txtPrice.Text, out decimal price) ||
                !int.TryParse(txtStock.Text, out int stock))
            {
                MessageBox.Show(
                    "Price and Stock must be valid numbers!",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Create a Product object with the updated details
            // including the ID of the product to update
            var product = new Product
            {
                Id = _selectedProductId,
                Name = txtProductName.Text.Trim(),
                Price = price,
                Stock = stock
            };

            // Ask ProductRepository to update this product
            bool updated = _productRepo.UpdateProduct(product);

            if (updated)
            {
                MessageBox.Show(
                    "Product updated successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                ClearFields();
                LoadData();
            }
            else
            {
                MessageBox.Show(
                    "Failed to update product.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────
        // DELETE PRODUCT BUTTON CLICKED
        // Deletes the selected product from the database.
        // The admin must click a row first to select a product.
        // ─────────────────────────────────────────────────────
        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            // Make sure a product is selected
            if (_selectedProductId == -1)
            {
                MessageBox.Show(
                    "Please click a product row first to select it.",
                    "No Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Ask for confirmation before deleting
            var confirm = MessageBox.Show(
                "Are you sure you want to delete this product?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                // Ask ProductRepository to delete this product
                bool deleted = _productRepo.DeleteProduct(
                    _selectedProductId);

                if (deleted)
                {
                    MessageBox.Show(
                        "Product deleted successfully.",
                        "Deleted",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ClearFields();
                    LoadData();
                }
                else
                {
                    MessageBox.Show(
                        "Failed to delete product.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        // ─────────────────────────────────────────────────────
        // CLEAR BUTTON CLICKED
        // Clears all input fields and deselects any product
        // ─────────────────────────────────────────────────────
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        // ─────────────────────────────────────────────────────
        // CLEAR FIELDS
        // Resets all input fields and the selected product ID
        // ─────────────────────────────────────────────────────
        private void ClearFields()
        {
            txtProductName.Clear();
            txtPrice.Clear();
            txtStock.Clear();

            // Reset selection — no product is selected anymore
            _selectedProductId = -1;
        }
    }
}