using System;
using System.Data;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Shopping_mart_Management_system.Forms.Admin
{
    public partial class ReceiptForm : Form
    {
        private string receiptText = "";

        public ReceiptForm()
        {
            InitializeComponent();
        }

        public void LoadReceipt(
            string invoiceNo,
            string cashierName,
            DateTime billDate,
            DataTable items,
            decimal subTotal,
            decimal discount,
            decimal taxPercent,
            decimal taxAmount,
            decimal total,
            decimal amountPaid,
            decimal change)
        {
            string line = new string('-', 40);
            string doubleLine = new string('=', 40);

            var sb = new System.Text.StringBuilder();

            // Header
            sb.AppendLine(Center("SMMS", 40));
            sb.AppendLine(Center("Shopping Mart Management System", 40));
            sb.AppendLine(Center("Tel: 0300-0000000", 40));
            sb.AppendLine(doubleLine);

            // Bill info
            sb.AppendLine($"Invoice : {invoiceNo}");
            sb.AppendLine($"Date    : {billDate:dd/MM/yyyy}");
            sb.AppendLine($"Time    : {billDate:hh:mm tt}");
            sb.AppendLine($"Cashier : {cashierName}");
            sb.AppendLine(doubleLine);

            // Column headers
            sb.AppendLine(
                $"{"Product",-18}" +
                $"{"Qty",4}" +
                $"{"Price",8}" +
                $"{"Total",8}");
            sb.AppendLine(line);

            // Items
            foreach (DataRow row in items.Rows)
            {
                string name = row["ProductName"].ToString() ?? "";
                if (name.Length > 17) name = name.Substring(0, 17);
                int qty = Convert.ToInt32(row["Quantity"]);
                decimal price = Convert.ToDecimal(row["UnitPrice"]);
                decimal disc = Convert.ToDecimal(row["Discount"]);
                decimal rowTotal = Convert.ToDecimal(row["Total"]);

                sb.AppendLine(
                    $"{name,-18}" +
                    $"{qty,4}" +
                    $"{price,8:F2}" +
                    $"{rowTotal,8:F2}");

                if (disc > 0)
                    sb.AppendLine(
                        $"  Discount: Rs.{disc:F2}/item");
            }

            sb.AppendLine(line);

            // Totals
            sb.AppendLine($"{"Sub Total:",-25}Rs.{subTotal,8:F2}");

            if (discount > 0)
                sb.AppendLine($"{"Discount:",-25}Rs.{discount,8:F2}");

            sb.AppendLine(
                $"{"Tax (" + taxPercent + "%):",-25}" +
                $"Rs.{taxAmount,8:F2}");

            sb.AppendLine(doubleLine);
            sb.AppendLine($"{"TOTAL:",-25}Rs.{total,8:F2}");
            sb.AppendLine(doubleLine);
            sb.AppendLine($"{"Amount Paid:",-25}Rs.{amountPaid,8:F2}");
            sb.AppendLine($"{"Change:",-25}Rs.{change,8:F2}");
            sb.AppendLine(doubleLine);

            // Footer
            sb.AppendLine();
            sb.AppendLine(Center("Thank you for shopping!", 40));
            sb.AppendLine(Center("Please come again!", 40));
            sb.AppendLine(doubleLine);

            receiptText = sb.ToString();
            rtbReceipt.Text = receiptText;
        }

        private string Center(string text, int width)
        {
            if (text.Length >= width) return text;
            int spaces = (width - text.Length) / 2;
            return new string(' ', spaces) + text;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var pd = new PrintDocument();
            pd.PrintPage += (s, ev) =>
            {
                ev.Graphics!.DrawString(
                    receiptText,
                    new System.Drawing.Font("Courier New", 8),
                    System.Drawing.Brushes.Black,
                    ev.MarginBounds);
            };

            var preview = new PrintPreviewDialog();
            preview.Document = pd;
            preview.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}