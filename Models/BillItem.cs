// ============================================================
// FILE: BillItem.cs
// LAYER: Models (Layer 1 - Data Blueprint)
//
// PURPOSE:
//   This file describes one individual item (product line)
//   inside a bill. For example, if a customer buys 3 products,
//   there will be 3 BillItem objects — one for each product.
//
// EXAMPLE:
//   Bill #INV-0001 contains:
//     BillItem 1 → Lays Chips, Qty: 2, Price: 50, Total: 100
//     BillItem 2 → Coca-Cola, Qty: 1, Price: 40, Total: 40
//
// HOW IT IS USED:
//   When a cashier adds a product to the bill, a BillItem
//   object is created. All BillItems are saved to the
//   bill_items table in the database when the bill is saved.
//
// CONNECTED TO:
//   - BillRepository.cs  (saves bill items to database)
//   - BillingForm.cs     (creates bill item objects)
//   - ReportsForm.cs     (shows items of a selected bill)
//   - ReceiptForm.cs     (displays items on the receipt)
// ============================================================

namespace Shopping_mart_Management_system.Models
{
    public class BillItem
    {
        // The unique ID of this bill item in the database
        public int Id { get; set; }

        // The ID of the bill this item belongs to
        // This links the item back to its parent bill
        public int BillId { get; set; }

        // The name of the product at the time of sale
        // (stored separately so if product name changes later,
        //  the receipt still shows the original name)
        public string ProductName { get; set; }

        // The price per unit of this product
        public decimal UnitPrice { get; set; }

        // How many units of this product were purchased
        public int Quantity { get; set; }

        // The discount applied per unit of this product
        public decimal Discount { get; set; }

        // The total cost for this line item
        // Formula: (UnitPrice - Discount) * Quantity
        public decimal Total { get; set; }
    }
}