╔══════════════════════════════════════════════════════════════╗
║         SMMS - Shopping Mart Management System               ║
║              Developed by: Farman Haider Bukhari             ║
║                    Ag#: 2024-ag-6593                         ║
╚══════════════════════════════════════════════════════════════╝

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
 BEFORE YOU RUN — REQUIREMENTS
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

 1. MySQL Server 8.0 must be installed on your computer
    Download from: https://dev.mysql.com/downloads/installer/
    Choose: Developer Default setup during installation

 2. .NET 10 Runtime must be installed
    Download from: https://dotnet.microsoft.com/en-us/download

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
 HOW TO RUN THE PROJECT
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

 OPTION A — Run from Visual Studio:
   1. Open the .sln file in Visual Studio 2022
   2. Press F5 or click the green Play button
   3. A popup will appear asking for your MySQL password
   4. Enter your MySQL root password and click CONNECT & START
   5. The database is created automatically — no extra steps!

 OPTION B — Run the .exe directly:
   1. Go to this folder:
      bin → Debug → net10.0-windows
   2. Double-click:
      "Shopping mart Management system.exe"
   3. A popup will appear asking for your MySQL password
   4. Enter your MySQL root password and click CONNECT & START
   5. The database is created automatically — no extra steps!

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
 FIRST TIME SETUP POPUP
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

 When you run the app for the first time you will see a popup:

 ┌─────────────────────────────────────┐
 │  First Time Setup                   │
 │                                     │
 │  MySQL Root Password: [________]    │
 │                                     │
 │  [ CONNECT & START ]                │
 └─────────────────────────────────────┘

 → Enter your MySQL root password (the one you set during
   MySQL installation) and click CONNECT & START

 → If you did not set a password during installation,
   just leave the box EMPTY and click CONNECT & START

 → The database, tables, and sample data are created
   automatically. You will NOT see this popup again.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
 LOGIN CREDENTIALS
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

 Admin Account:
   Username : admin
   Password : admin123

 Note: You can add Cashier accounts from the Admin Dashboard
       under the Cashiers section after logging in.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
 APPLICATION FEATURES
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

 Admin can access:
   ✔ Dashboard    — View total products, cashiers, bills, revenue
   ✔ Cashiers     — Add and delete cashier accounts
   ✔ Products     — Add, update, and delete products
   ✔ Billing      — Create customer bills and print receipts
   ✔ Reports      — View all past transactions

 Cashier can access:
   ✔ Billing only — Create customer bills and print receipts

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
 TECHNOLOGY USED
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

   Language  : C# (.NET 10 Windows Forms)
   Database  : MySQL Server 8.0
   IDE       : Microsoft Visual Studio 2022
   Connector : MySql.Data NuGet Package v9.7.0

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
 FOLDER STRUCTURE
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

 Shopping mart Management system
 │
 ├── Database/         Layer 2: Database connection & repositories
 │   ├── DbConnection.cs
 │   ├── BaseRepository.cs
 │   ├── UserRepository.cs
 │   ├── ProductRepository.cs
 │   ├── BillRepository.cs
 │   └── SessionManager.cs
 │
 ├── Models/           Layer 1: Data blueprints
 │   ├── Product.cs
 │   ├── User.cs
 │   ├── Bill.cs
 │   └── BillItem.cs
 │
 ├── Forms/            Layer 3: User interface screens
 │   ├── Auth/
 │   │   ├── LoginForm.cs
 │   │   └── FirstTimeSetupForm.cs
 │   ├── Admin/
 │   │   ├── DashboardForm.cs
 │   │   ├── CashiersForm.cs
 │   │   ├── ProductsForm.cs
 │   │   ├── BillingForm.cs
 │   │   ├── ReportsForm.cs
 │   │   └── ReceiptForm.cs
 │   └── Cashier/
 │       └── CashierDashboardForm.cs
 │
 └── Resources/        Logos and images