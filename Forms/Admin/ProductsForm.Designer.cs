namespace Shopping_mart_Management_system.Forms.Admin
{
    partial class ProductsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelForm = new Panel();
            btnClear = new Button();
            btnDeleteProduct = new Button();
            btnUpdateProduct = new Button();
            btnAddProduct = new Button();
            txtStock = new TextBox();
            txtPrice = new TextBox();
            txtProductName = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dgvProducts = new DataGridView();
            panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.White;
            panelForm.Controls.Add(btnClear);
            panelForm.Controls.Add(btnDeleteProduct);
            panelForm.Controls.Add(btnUpdateProduct);
            panelForm.Controls.Add(btnAddProduct);
            panelForm.Controls.Add(txtStock);
            panelForm.Controls.Add(txtPrice);
            panelForm.Controls.Add(txtProductName);
            panelForm.Controls.Add(label4);
            panelForm.Controls.Add(label3);
            panelForm.Controls.Add(label2);
            panelForm.Controls.Add(label1);
            panelForm.Location = new Point(0, 0);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(280, 600);
            panelForm.TabIndex = 0;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(240, 242, 245);
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.FromArgb(100, 120, 150);
            btnClear.Location = new Point(20, 425);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(240, 35);
            btnClear.TabIndex = 6;
            btnClear.Text = "CLEAR";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnDeleteProduct
            // 
            btnDeleteProduct.BackColor = Color.FromArgb(220, 80, 80);
            btnDeleteProduct.Cursor = Cursors.Hand;
            btnDeleteProduct.FlatAppearance.BorderSize = 0;
            btnDeleteProduct.FlatStyle = FlatStyle.Flat;
            btnDeleteProduct.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteProduct.ForeColor = Color.White;
            btnDeleteProduct.Location = new Point(20, 370);
            btnDeleteProduct.Name = "btnDeleteProduct";
            btnDeleteProduct.Size = new Size(240, 42);
            btnDeleteProduct.TabIndex = 5;
            btnDeleteProduct.Text = "DELETE SELECTED";
            btnDeleteProduct.UseVisualStyleBackColor = false;
            btnDeleteProduct.Click += btnDeleteProduct_Click;
            // 
            // btnUpdateProduct
            // 
            btnUpdateProduct.BackColor = Color.FromArgb(40, 167, 69);
            btnUpdateProduct.Cursor = Cursors.Hand;
            btnUpdateProduct.FlatAppearance.BorderSize = 0;
            btnUpdateProduct.FlatStyle = FlatStyle.Flat;
            btnUpdateProduct.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdateProduct.ForeColor = Color.White;
            btnUpdateProduct.Location = new Point(20, 315);
            btnUpdateProduct.Name = "btnUpdateProduct";
            btnUpdateProduct.Size = new Size(240, 42);
            btnUpdateProduct.TabIndex = 4;
            btnUpdateProduct.Text = "UPDATE SELECTED";
            btnUpdateProduct.UseVisualStyleBackColor = false;
            btnUpdateProduct.Click += btnUpdateProduct_Click;
            // 
            // btnAddProduct
            // 
            btnAddProduct.BackColor = Color.FromArgb(79, 142, 247);
            btnAddProduct.Cursor = Cursors.Hand;
            btnAddProduct.FlatAppearance.BorderSize = 0;
            btnAddProduct.FlatStyle = FlatStyle.Flat;
            btnAddProduct.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddProduct.ForeColor = Color.White;
            btnAddProduct.Location = new Point(20, 260);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(240, 42);
            btnAddProduct.TabIndex = 3;
            btnAddProduct.Text = "ADD PRODUCT";
            btnAddProduct.UseVisualStyleBackColor = false;
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // txtStock
            // 
            txtStock.Font = new Font("Arial Narrow", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStock.Location = new Point(20, 205);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(240, 30);
            txtStock.TabIndex = 2;
            // 
            // txtPrice
            // 
            txtPrice.Font = new Font("Arial Narrow", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPrice.Location = new Point(20, 145);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(240, 30);
            txtPrice.TabIndex = 2;
            // 
            // txtProductName
            // 
            txtProductName.Font = new Font("Arial Narrow", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProductName.Location = new Point(20, 85);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(240, 30);
            txtProductName.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Narrow", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(100, 120, 150);
            label4.Location = new Point(20, 185);
            label4.Name = "label4";
            label4.Size = new Size(94, 20);
            label4.TabIndex = 1;
            label4.Text = "Stock Quantity";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Narrow", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(100, 120, 150);
            label3.Location = new Point(20, 125);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 1;
            label3.Text = "Price (Rs.)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Narrow", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(100, 120, 150);
            label2.Location = new Point(20, 65);
            label2.Name = "label2";
            label2.Size = new Size(94, 20);
            label2.TabIndex = 1;
            label2.Text = "Product Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(26, 31, 46);
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(198, 26);
            label1.TabIndex = 0;
            label1.Text = "Add / Edit Product";
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.BackgroundColor = Color.FromArgb(240, 242, 245);
            dgvProducts.BorderStyle = BorderStyle.None;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(295, 0);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.RowHeadersWidth = 62;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(600, 600);
            dgvProducts.TabIndex = 1;
            dgvProducts.CellClick += DgvProducts_CellClick;
            // 
            // ProductsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 242, 245);
            ClientSize = new Size(878, 544);
            Controls.Add(dgvProducts);
            Controls.Add(panelForm);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProductsForm";
            Text = "Products Management";
            panelForm.ResumeLayout(false);
            panelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelForm;
        private Label label1;
        private TextBox txtProductName;
        private Label label3;
        private Label label2;
        private Button btnAddProduct;
        private TextBox txtStock;
        private TextBox txtPrice;
        private Label label4;
        private Button btnDeleteProduct;
        private Button btnUpdateProduct;
        private Button btnClear;
        private DataGridView dgvProducts;
    }
}