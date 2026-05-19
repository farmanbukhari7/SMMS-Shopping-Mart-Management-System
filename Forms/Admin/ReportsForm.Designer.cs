namespace Shopping_mart_Management_system.Forms.Admin
{
    partial class ReportsForm
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
            label1 = new Label();
            dgvBills = new DataGridView();
            label2 = new Label();
            dgvBillItems = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvBills).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBillItems).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(26, 31, 46);
            label1.Location = new Point(15, 15);
            label1.Name = "label1";
            label1.Size = new Size(148, 29);
            label1.TabIndex = 0;
            label1.Text = "Bills Report";
            // 
            // dgvBills
            // 
            dgvBills.AllowUserToAddRows = false;
            dgvBills.BackgroundColor = Color.White;
            dgvBills.BorderStyle = BorderStyle.None;
            dgvBills.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBills.Location = new Point(15, 50);
            dgvBills.Name = "dgvBills";
            dgvBills.ReadOnly = true;
            dgvBills.RowHeadersVisible = false;
            dgvBills.RowHeadersWidth = 62;
            dgvBills.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBills.Size = new Size(860, 220);
            dgvBills.TabIndex = 1;
            dgvBills.CellClick += dgvBills_CellClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(26, 31, 46);
            label2.Location = new Point(15, 285);
            label2.Name = "label2";
            label2.Size = new Size(422, 24);
            label2.TabIndex = 2;
            label2.Text = "Bill Items (click a bill above to see its items)";
            // 
            // dgvBillItems
            // 
            dgvBillItems.AllowUserToAddRows = false;
            dgvBillItems.BackgroundColor = Color.White;
            dgvBillItems.BorderStyle = BorderStyle.None;
            dgvBillItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBillItems.Location = new Point(15, 315);
            dgvBillItems.Name = "dgvBillItems";
            dgvBillItems.ReadOnly = true;
            dgvBillItems.RowHeadersVisible = false;
            dgvBillItems.RowHeadersWidth = 62;
            dgvBillItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBillItems.Size = new Size(860, 250);
            dgvBillItems.TabIndex = 3;
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 242, 245);
            ClientSize = new Size(878, 544);
            Controls.Add(dgvBillItems);
            Controls.Add(label2);
            Controls.Add(dgvBills);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ReportsForm";
            Text = "Reports";
            Load += ReportsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBills).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBillItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvBills;
        private Label label2;
        private DataGridView dgvBillItems;
    }
}