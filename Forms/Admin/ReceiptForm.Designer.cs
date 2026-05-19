namespace Shopping_mart_Management_system.Forms.Admin
{
    partial class ReceiptForm
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
            rtbReceipt = new RichTextBox();
            btnPrint = new Button();
            btnClose = new Button();
            SuspendLayout();
            // 
            // rtbReceipt
            // 
            rtbReceipt.BackColor = Color.White;
            rtbReceipt.BorderStyle = BorderStyle.None;
            rtbReceipt.Font = new Font("Courier New", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtbReceipt.Location = new Point(15, 10);
            rtbReceipt.Name = "rtbReceipt";
            rtbReceipt.ReadOnly = true;
            rtbReceipt.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbReceipt.Size = new Size(380, 480);
            rtbReceipt.TabIndex = 1;
            rtbReceipt.Text = "";
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.FromArgb(79, 142, 247);
            btnPrint.Cursor = Cursors.Hand;
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(15, 500);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(180, 45);
            btnPrint.TabIndex = 2;
            btnPrint.Text = "🖨️ PRINT";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(220, 80, 80);
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(210, 500);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(180, 45);
            btnClose.TabIndex = 3;
            btnClose.Text = "✖ CLOSE";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // ReceiptForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(398, 594);
            Controls.Add(btnClose);
            Controls.Add(btnPrint);
            Controls.Add(rtbReceipt);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ReceiptForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bill Receipt";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox rtbReceipt;
        private Button btnPrint;
        private Button btnClose;
    }
}