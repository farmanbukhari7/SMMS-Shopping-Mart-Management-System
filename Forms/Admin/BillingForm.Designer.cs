namespace Shopping_mart_Management_system.Forms.Admin
{
    partial class BillingForm
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
            panelInfo = new Panel();
            lblCashierName = new Label();
            lblDateTime = new Label();
            lblInvoiceNo = new Label();
            panelAddItem = new Panel();
            btnRemoveItem = new Button();
            btnAddItem = new Button();
            txtDiscount = new TextBox();
            label4 = new Label();
            txtQuantity = new TextBox();
            label3 = new Label();
            txtUnitPrice = new TextBox();
            label2 = new Label();
            cmbProducts = new ComboBox();
            label1 = new Label();
            dgvBillItems = new DataGridView();
            panelSummary = new Panel();
            btnResetBill = new Button();
            btnSaveBill = new Button();
            lblChange = new Label();
            lblChangeTitle = new Label();
            txtAmountPaid = new TextBox();
            label8 = new Label();
            lblTotal = new Label();
            lblTotalTitle = new Label();
            panel1 = new Panel();
            lblTaxAmount = new Label();
            txtTax = new TextBox();
            label6 = new Label();
            lblDiscount = new Label();
            lblDiscountTitle = new Label();
            lblSubTotal = new Label();
            lblSubTotalTitle = new Label();
            label5 = new Label();
            panelInfo.SuspendLayout();
            panelAddItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBillItems).BeginInit();
            panelSummary.SuspendLayout();
            SuspendLayout();
            // 
            // panelInfo
            // 
            panelInfo.BackColor = Color.White;
            panelInfo.Controls.Add(lblCashierName);
            panelInfo.Controls.Add(lblDateTime);
            panelInfo.Controls.Add(lblInvoiceNo);
            panelInfo.Location = new Point(0, 0);
            panelInfo.Name = "panelInfo";
            panelInfo.Size = new Size(900, 70);
            panelInfo.TabIndex = 0;
            // 
            // lblCashierName
            // 
            lblCashierName.AutoSize = true;
            lblCashierName.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCashierName.ForeColor = Color.FromArgb(100, 120, 150);
            lblCashierName.Location = new Point(700, 25);
            lblCashierName.Name = "lblCashierName";
            lblCashierName.Size = new Size(110, 22);
            lblCashierName.TabIndex = 2;
            lblCashierName.Text = "Cashier: Admin";
            // 
            // lblDateTime
            // 
            lblDateTime.AutoSize = true;
            lblDateTime.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDateTime.ForeColor = Color.FromArgb(100, 120, 150);
            lblDateTime.Location = new Point(15, 40);
            lblDateTime.Name = "lblDateTime";
            lblDateTime.Size = new Size(120, 22);
            lblDateTime.TabIndex = 1;
            lblDateTime.Text = "Date: 01/01/2026";
            // 
            // lblInvoiceNo
            // 
            lblInvoiceNo.AutoSize = true;
            lblInvoiceNo.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInvoiceNo.ForeColor = Color.FromArgb(79, 142, 247);
            lblInvoiceNo.Location = new Point(15, 12);
            lblInvoiceNo.Name = "lblInvoiceNo";
            lblInvoiceNo.Size = new Size(183, 24);
            lblInvoiceNo.TabIndex = 0;
            lblInvoiceNo.Text = "Invoice: #INV-0001";
            // 
            // panelAddItem
            // 
            panelAddItem.BackColor = Color.FromArgb(26, 31, 46);
            panelAddItem.Controls.Add(btnRemoveItem);
            panelAddItem.Controls.Add(btnAddItem);
            panelAddItem.Controls.Add(txtDiscount);
            panelAddItem.Controls.Add(label4);
            panelAddItem.Controls.Add(txtQuantity);
            panelAddItem.Controls.Add(label3);
            panelAddItem.Controls.Add(txtUnitPrice);
            panelAddItem.Controls.Add(label2);
            panelAddItem.Controls.Add(cmbProducts);
            panelAddItem.Controls.Add(label1);
            panelAddItem.Location = new Point(0, 70);
            panelAddItem.Name = "panelAddItem";
            panelAddItem.Size = new Size(900, 80);
            panelAddItem.TabIndex = 1;
            // 
            // btnRemoveItem
            // 
            btnRemoveItem.BackColor = Color.FromArgb(180, 60, 60);
            btnRemoveItem.Cursor = Cursors.Hand;
            btnRemoveItem.FlatAppearance.BorderSize = 0;
            btnRemoveItem.FlatStyle = FlatStyle.Flat;
            btnRemoveItem.Font = new Font("Arial", 8F, FontStyle.Bold);
            btnRemoveItem.ForeColor = Color.White;
            btnRemoveItem.Location = new Point(690, 22);
            btnRemoveItem.Name = "btnRemoveItem";
            btnRemoveItem.Size = new Size(100, 38);
            btnRemoveItem.TabIndex = 9;
            btnRemoveItem.Text = "REMOVE";
            btnRemoveItem.UseVisualStyleBackColor = false;
            btnRemoveItem.Click += btnRemoveItem_Click;
            // 
            // btnAddItem
            // 
            btnAddItem.BackColor = Color.FromArgb(79, 142, 247);
            btnAddItem.Cursor = Cursors.Hand;
            btnAddItem.FlatAppearance.BorderSize = 0;
            btnAddItem.FlatStyle = FlatStyle.Flat;
            btnAddItem.Font = new Font("Arial", 8F, FontStyle.Bold);
            btnAddItem.ForeColor = Color.White;
            btnAddItem.Location = new Point(550, 22);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(130, 38);
            btnAddItem.TabIndex = 8;
            btnAddItem.Text = "ADD TO BILL";
            btnAddItem.UseVisualStyleBackColor = false;
            btnAddItem.Click += btnAddItem_Click;
            // 
            // txtDiscount
            // 
            txtDiscount.Font = new Font("Arial Narrow", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDiscount.Location = new Point(455, 30);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Size = new Size(80, 30);
            txtDiscount.TabIndex = 7;
            txtDiscount.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(455, 10);
            label4.Name = "label4";
            label4.Size = new Size(100, 22);
            label4.TabIndex = 6;
            label4.Text = "Discount/Item:";
            // 
            // txtQuantity
            // 
            txtQuantity.Font = new Font("Arial Narrow", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtQuantity.Location = new Point(360, 30);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(80, 30);
            txtQuantity.TabIndex = 5;
            txtQuantity.Text = "1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(360, 10);
            label3.Name = "label3";
            label3.Size = new Size(65, 22);
            label3.TabIndex = 4;
            label3.Text = "Quantity:";
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.BackColor = Color.FromArgb(50, 60, 80);
            txtUnitPrice.Font = new Font("Arial Narrow", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUnitPrice.ForeColor = Color.White;
            txtUnitPrice.Location = new Point(245, 30);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.ReadOnly = true;
            txtUnitPrice.Size = new Size(100, 30);
            txtUnitPrice.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(245, 10);
            label2.Name = "label2";
            label2.Size = new Size(76, 22);
            label2.TabIndex = 2;
            label2.Text = "Unit Price:";
            // 
            // cmbProducts
            // 
            cmbProducts.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProducts.Font = new Font("Arial Narrow", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbProducts.FormattingEnabled = true;
            cmbProducts.Location = new Point(10, 30);
            cmbProducts.Name = "cmbProducts";
            cmbProducts.Size = new Size(220, 32);
            cmbProducts.TabIndex = 1;
            cmbProducts.SelectedIndexChanged += cmbProducts_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(10, 10);
            label1.Name = "label1";
            label1.Size = new Size(63, 22);
            label1.TabIndex = 0;
            label1.Text = "Product:";
            // 
            // dgvBillItems
            // 
            dgvBillItems.AllowUserToAddRows = false;
            dgvBillItems.BackgroundColor = Color.White;
            dgvBillItems.BorderStyle = BorderStyle.None;
            dgvBillItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBillItems.Location = new Point(0, 150);
            dgvBillItems.Name = "dgvBillItems";
            dgvBillItems.ReadOnly = true;
            dgvBillItems.RowHeadersVisible = false;
            dgvBillItems.RowHeadersWidth = 62;
            dgvBillItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBillItems.Size = new Size(620, 310);
            dgvBillItems.TabIndex = 2;
            // 
            // panelSummary
            // 
            panelSummary.BackColor = Color.White;
            panelSummary.Controls.Add(btnResetBill);
            panelSummary.Controls.Add(btnSaveBill);
            panelSummary.Controls.Add(lblChange);
            panelSummary.Controls.Add(lblChangeTitle);
            panelSummary.Controls.Add(txtAmountPaid);
            panelSummary.Controls.Add(label8);
            panelSummary.Controls.Add(lblTotal);
            panelSummary.Controls.Add(lblTotalTitle);
            panelSummary.Controls.Add(panel1);
            panelSummary.Controls.Add(lblTaxAmount);
            panelSummary.Controls.Add(txtTax);
            panelSummary.Controls.Add(label6);
            panelSummary.Controls.Add(lblDiscount);
            panelSummary.Controls.Add(lblDiscountTitle);
            panelSummary.Controls.Add(lblSubTotal);
            panelSummary.Controls.Add(lblSubTotalTitle);
            panelSummary.Controls.Add(label5);
            panelSummary.Location = new Point(625, 150);
            panelSummary.Name = "panelSummary";
            panelSummary.Size = new Size(275, 460);
            panelSummary.TabIndex = 3;
            // 
            // btnResetBill
            // 
            btnResetBill.BackColor = Color.FromArgb(220, 80, 80);
            btnResetBill.FlatAppearance.BorderSize = 0;
            btnResetBill.FlatStyle = FlatStyle.Flat;
            btnResetBill.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnResetBill.ForeColor = Color.White;
            btnResetBill.Location = new Point(15, 395);
            btnResetBill.Name = "btnResetBill";
            btnResetBill.Size = new Size(245, 40);
            btnResetBill.TabIndex = 16;
            btnResetBill.Text = "RESET BILL";
            btnResetBill.UseVisualStyleBackColor = false;
            btnResetBill.Click += btnResetBill_Click;
            // 
            // btnSaveBill
            // 
            btnSaveBill.BackColor = Color.FromArgb(40, 167, 69);
            btnSaveBill.Cursor = Cursors.Hand;
            btnSaveBill.FlatAppearance.BorderSize = 0;
            btnSaveBill.FlatStyle = FlatStyle.Flat;
            btnSaveBill.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaveBill.ForeColor = Color.White;
            btnSaveBill.Location = new Point(15, 340);
            btnSaveBill.Name = "btnSaveBill";
            btnSaveBill.Size = new Size(245, 45);
            btnSaveBill.TabIndex = 15;
            btnSaveBill.Text = "SAVE & PRINT BILL";
            btnSaveBill.UseVisualStyleBackColor = false;
            btnSaveBill.Click += btnSaveBill_Click;
            // 
            // lblChange
            // 
            lblChange.AutoSize = true;
            lblChange.Font = new Font("Arial", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblChange.ForeColor = Color.FromArgb(40, 167, 69);
            lblChange.Location = new Point(150, 295);
            lblChange.Name = "lblChange";
            lblChange.Size = new Size(94, 26);
            lblChange.TabIndex = 14;
            lblChange.Text = "Rs. 0.00";
            // 
            // lblChangeTitle
            // 
            lblChangeTitle.AutoSize = true;
            lblChangeTitle.Location = new Point(15, 295);
            lblChangeTitle.Name = "lblChangeTitle";
            lblChangeTitle.Size = new Size(76, 25);
            lblChangeTitle.TabIndex = 13;
            lblChangeTitle.Text = "Change:";
            // 
            // txtAmountPaid
            // 
            txtAmountPaid.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAmountPaid.Location = new Point(15, 248);
            txtAmountPaid.Name = "txtAmountPaid";
            txtAmountPaid.Size = new Size(240, 35);
            txtAmountPaid.TabIndex = 12;
            txtAmountPaid.TextChanged += txtAmountPaid_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(15, 225);
            label8.Name = "label8";
            label8.Size = new Size(119, 25);
            label8.TabIndex = 11;
            label8.Text = "Amount Paid:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Arial", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = Color.FromArgb(79, 142, 247);
            lblTotal.Location = new Point(130, 180);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(109, 30);
            lblTotal.TabIndex = 10;
            lblTotal.Text = "Rs. 0.00";
            // 
            // lblTotalTitle
            // 
            lblTotalTitle.AutoSize = true;
            lblTotalTitle.Font = new Font("Arial", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalTitle.Location = new Point(15, 180);
            lblTotalTitle.Name = "lblTotalTitle";
            lblTotalTitle.Size = new Size(108, 30);
            lblTotalTitle.TabIndex = 9;
            lblTotalTitle.Text = "TOTAL:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(220, 225, 235);
            panel1.Location = new Point(15, 165);
            panel1.Name = "panel1";
            panel1.Size = new Size(245, 2);
            panel1.TabIndex = 8;
            // 
            // lblTaxAmount
            // 
            lblTaxAmount.AutoSize = true;
            lblTaxAmount.Location = new Point(150, 130);
            lblTaxAmount.Name = "lblTaxAmount";
            lblTaxAmount.Size = new Size(74, 25);
            lblTaxAmount.TabIndex = 7;
            lblTaxAmount.Text = "Rs. 0.00";
            // 
            // txtTax
            // 
            txtTax.Font = new Font("Arial Narrow", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTax.Location = new Point(80, 127);
            txtTax.Name = "txtTax";
            txtTax.Size = new Size(60, 30);
            txtTax.TabIndex = 6;
            txtTax.Text = "5";
            txtTax.TextChanged += txtTax_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 130);
            label6.Name = "label6";
            label6.Size = new Size(60, 25);
            label6.TabIndex = 5;
            label6.Text = "Tax %:";
            // 
            // lblDiscount
            // 
            lblDiscount.AutoSize = true;
            lblDiscount.Location = new Point(150, 95);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(74, 25);
            lblDiscount.TabIndex = 4;
            lblDiscount.Text = "Rs. 0.00";
            // 
            // lblDiscountTitle
            // 
            lblDiscountTitle.AutoSize = true;
            lblDiscountTitle.Location = new Point(15, 95);
            lblDiscountTitle.Name = "lblDiscountTitle";
            lblDiscountTitle.Size = new Size(86, 25);
            lblDiscountTitle.TabIndex = 3;
            lblDiscountTitle.Text = "Discount:";
            // 
            // lblSubTotal
            // 
            lblSubTotal.AutoSize = true;
            lblSubTotal.Location = new Point(150, 60);
            lblSubTotal.Name = "lblSubTotal";
            lblSubTotal.Size = new Size(74, 25);
            lblSubTotal.TabIndex = 2;
            lblSubTotal.Text = "Rs. 0.00";
            // 
            // lblSubTotalTitle
            // 
            lblSubTotalTitle.AutoSize = true;
            lblSubTotalTitle.Location = new Point(15, 60);
            lblSubTotalTitle.Name = "lblSubTotalTitle";
            lblSubTotalTitle.Size = new Size(89, 25);
            lblSubTotalTitle.TabIndex = 1;
            lblSubTotalTitle.Text = "Sub Total:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(26, 31, 46);
            label5.Location = new Point(15, 15);
            label5.Name = "label5";
            label5.Size = new Size(128, 21);
            label5.TabIndex = 0;
            label5.Text = "Bill Summary";
            // 
            // BillingForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 242, 245);
            ClientSize = new Size(878, 594);
            Controls.Add(panelSummary);
            Controls.Add(dgvBillItems);
            Controls.Add(panelAddItem);
            Controls.Add(panelInfo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "BillingForm";
            Text = "Billing";
            panelInfo.ResumeLayout(false);
            panelInfo.PerformLayout();
            panelAddItem.ResumeLayout(false);
            panelAddItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBillItems).EndInit();
            panelSummary.ResumeLayout(false);
            panelSummary.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelInfo;
        private Label lblInvoiceNo;
        private Label lblCashierName;
        private Label lblDateTime;
        private Panel panelAddItem;
        private Label label2;
        private ComboBox cmbProducts;
        private Label label1;
        private TextBox txtQuantity;
        private Label label3;
        private TextBox txtUnitPrice;
        private TextBox txtDiscount;
        private Label label4;
        private Button btnAddItem;
        private Button btnRemoveItem;
        private DataGridView dgvBillItems;
        private Panel panelSummary;
        private Label lblSubTotalTitle;
        private Label label5;
        private TextBox txtTax;
        private Label label6;
        private Label lblDiscount;
        private Label lblDiscountTitle;
        private Label lblSubTotal;
        private Label lblTotalTitle;
        private Panel panel1;
        private Label lblTaxAmount;
        private Label lblChangeTitle;
        private TextBox txtAmountPaid;
        private Label label8;
        private Label lblTotal;
        private Button btnSaveBill;
        private Label lblChange;
        private Button btnResetBill;
    }
}