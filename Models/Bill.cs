// ============================================================
// FILE: Bill.cs
// LAYER: Models (Layer 1 - Data Blueprint)
//
// PURPOSE:
//   This file describes what a Bill (invoice) looks like in
//   our system. Every time a cashier saves a transaction,
//   one Bill object is created and stored in the database.
//
// HOW IT IS USED:
//   After the cashier clicks SAVE & PRINT BILL, the billing
//   form fills a Bill object with all the totals and sends
//   it to BillRepository to save in the database.
//   The Reports screen loads Bill objects to show past sales.
//
// CONNECTED TO:
//   - BillRepository.cs  (saves and loads bills from database)
//   - BillingForm.cs     (creates and fills bill objects)
//   - ReportsForm.cs     (displays bills in the table)
// ============================================================

namespace Shopping_mart_Management_system.Models
{
    public class Bill
    {
        // The unique ID number of the bill in the database
        public int Id { get; set; }

        // The invoice number shown on the receipt (e.g. "INV-0001")
        public string InvoiceNo { get; set; }

        // The name of the cashier who created this bill
        public string Cashier { get; set; }

        // The total before discount and tax are applied
        public decimal SubTotal { get; set; }

        // The total amount discounted from all items
        public decimal Discount { get; set; }

        // The tax amount applied to this bill
        public decimal Tax { get; set; }

        // The final amount the customer has to pay
        public decimal Total { get; set; }

        // The amount of cash the customer gave the cashier
        public decimal AmountPaid { get; set; }

        // The change returned to the customer
        public decimal Change { get; set; }

        // The date and time this bill was created
        public System.DateTime BillDate { get; set; }
    }
}