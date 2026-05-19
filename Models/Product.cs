// ============================================================
// FILE: Product.cs
// LAYER: Models (Layer 1 - Data Blueprint)
// 
// PURPOSE:
//   This file is a blueprint (template) that describes what
//   a Product looks like in our system. Think of it like a
//   form with empty boxes — each box is one piece of info
//   about a product.
//
// HOW IT IS USED:
//   When we load products from the database, we fill one
//   Product object for each row. Forms and Repositories use
//   this class to pass product data around the application
//   instead of using loose variables.
//
// CONNECTED TO:
//   - ProductRepository.cs  (fills these objects from database)
//   - ProductsForm.cs       (displays these objects on screen)
//   - BillingForm.cs        (reads price from this object)
// ============================================================

namespace Shopping_mart_Management_system.Models
{
    public class Product
    {
        // The unique ID number of the product in the database
        public int Id { get; set; }

        // The name of the product (e.g. "Lays Chips 50g")
        public string Name { get; set; }

        // The selling price of the product in Pakistani Rupees
        public decimal Price { get; set; }

        // How many units of this product are currently in stock
        public int Stock { get; set; }
    }
}