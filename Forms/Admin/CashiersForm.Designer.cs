namespace Shopping_mart_Management_system.Forms.Admin
{
    partial class CashiersForm
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
            btnDeleteCashier = new Button();
            btnAddCashier = new Button();
            txtCashierPassword = new TextBox();
            txtCashierUsername = new TextBox();
            txtFullName = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dgvCashiers = new DataGridView();
            panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCashiers).BeginInit();
            SuspendLayout();
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.White;
            panelForm.Controls.Add(btnDeleteCashier);
            panelForm.Controls.Add(btnAddCashier);
            panelForm.Controls.Add(txtCashierPassword);
            panelForm.Controls.Add(txtCashierUsername);
            panelForm.Controls.Add(txtFullName);
            panelForm.Controls.Add(label4);
            panelForm.Controls.Add(label3);
            panelForm.Controls.Add(label2);
            panelForm.Controls.Add(label1);
            panelForm.Location = new Point(0, 0);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(280, 520);
            panelForm.TabIndex = 1;
            // 
            // btnDeleteCashier
            // 
            btnDeleteCashier.BackColor = Color.FromArgb(220, 80, 80);
            btnDeleteCashier.Cursor = Cursors.Hand;
            btnDeleteCashier.FlatAppearance.BorderSize = 0;
            btnDeleteCashier.FlatStyle = FlatStyle.Flat;
            btnDeleteCashier.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteCashier.ForeColor = Color.White;
            btnDeleteCashier.Location = new Point(20, 315);
            btnDeleteCashier.Name = "btnDeleteCashier";
            btnDeleteCashier.Size = new Size(240, 42);
            btnDeleteCashier.TabIndex = 6;
            btnDeleteCashier.Text = "DELETE SELECTED";
            btnDeleteCashier.UseVisualStyleBackColor = false;
            btnDeleteCashier.Click += btnDeleteCashier_Click;
            // 
            // btnAddCashier
            // 
            btnAddCashier.BackColor = Color.FromArgb(79, 142, 247);
            btnAddCashier.Cursor = Cursors.Hand;
            btnAddCashier.FlatAppearance.BorderSize = 0;
            btnAddCashier.FlatStyle = FlatStyle.Flat;
            btnAddCashier.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddCashier.ForeColor = Color.White;
            btnAddCashier.Location = new Point(20, 260);
            btnAddCashier.Name = "btnAddCashier";
            btnAddCashier.Size = new Size(240, 42);
            btnAddCashier.TabIndex = 5;
            btnAddCashier.Text = "ADD CASHIER";
            btnAddCashier.UseVisualStyleBackColor = false;
            btnAddCashier.Click += btnAddCashier_Click;
            // 
            // txtCashierPassword
            // 
            txtCashierPassword.Font = new Font("Arial Narrow", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCashierPassword.Location = new Point(20, 205);
            txtCashierPassword.Name = "txtCashierPassword";
            txtCashierPassword.PasswordChar = '●';
            txtCashierPassword.Size = new Size(240, 30);
            txtCashierPassword.TabIndex = 4;
            // 
            // txtCashierUsername
            // 
            txtCashierUsername.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCashierUsername.Location = new Point(20, 145);
            txtCashierUsername.Name = "txtCashierUsername";
            txtCashierUsername.Size = new Size(240, 28);
            txtCashierUsername.TabIndex = 3;
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Arial Narrow", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFullName.Location = new Point(20, 85);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(240, 30);
            txtFullName.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Narrow", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(100, 120, 150);
            label4.Location = new Point(20, 185);
            label4.Name = "label4";
            label4.Size = new Size(68, 20);
            label4.TabIndex = 1;
            label4.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Narrow", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(100, 120, 150);
            label3.Location = new Point(20, 125);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 1;
            label3.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Narrow", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(100, 120, 150);
            label2.Location = new Point(20, 65);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 1;
            label2.Text = "Full Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(26, 31, 46);
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(190, 26);
            label1.TabIndex = 0;
            label1.Text = "Add New Cashier";
            // 
            // dgvCashiers
            // 
            dgvCashiers.AllowUserToResizeRows = false;
            dgvCashiers.BackgroundColor = Color.FromArgb(240, 242, 245);
            dgvCashiers.BorderStyle = BorderStyle.None;
            dgvCashiers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCashiers.Location = new Point(295, 0);
            dgvCashiers.Name = "dgvCashiers";
            dgvCashiers.ReadOnly = true;
            dgvCashiers.RowHeadersVisible = false;
            dgvCashiers.RowHeadersWidth = 62;
            dgvCashiers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCashiers.Size = new Size(600, 520);
            dgvCashiers.TabIndex = 2;
            // 
            // CashiersForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 242, 245);
            ClientSize = new Size(878, 544);
            Controls.Add(dgvCashiers);
            Controls.Add(panelForm);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CashiersForm";
            Text = "Cashier Management";
            panelForm.ResumeLayout(false);
            panelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCashiers).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelForm;
        private Label label1;
        private Label label2;
        private TextBox txtCashierUsername;
        private TextBox txtFullName;
        private Label label3;
        private Button btnAddCashier;
        private TextBox txtCashierPassword;
        private Label label4;
        private Button btnDeleteCashier;
        private DataGridView dgvCashiers;
    }
}