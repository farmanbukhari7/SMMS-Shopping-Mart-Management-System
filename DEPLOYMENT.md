# SMMS Deployment Guide
## Shopping Mart Management System

---

## System Requirements

| Component | Requirement |
|-----------|-------------|
| Operating System | Windows 7 / 8 / 10 / 11 (64-bit recommended) |
| .NET Runtime | .NET 6.0 or later |
| Database | MySQL Server 8.0 or later |
| RAM | 2 GB minimum (4 GB recommended) |
| Storage | 500 MB free space |
| Display | 1024 x 768 resolution or higher |

---

## Step-by-Step Installation on a New Machine

### Step 1 — Install .NET Runtime
- Go to: https://dotnet.microsoft.com/en-us/download
- Download and install .NET 6.0 Runtime or later
- Run the installer and follow the steps

### Step 2 — Install MySQL Server 8.0
- Go to: https://dev.mysql.com/downloads/installer/
- Download MySQL Installer for Windows
- Run the installer
- Choose "Developer Default" setup type
- During configuration set a root password
- Write your password down — you will need it to run SMMS

### Step 3 — Run the Application

#### Option A — Run from Visual Studio:
1. Open the .sln file in Visual Studio 2022
2. Press F5 or click the green Play button
3. The First Time Setup popup will appear
4. Enter your MySQL root password
5. Click CONNECT & START
6. Database is created automatically
7. Login screen opens

#### Option B — Run the .exe directly:
1. Navigate to: bin → Debug → net10.0-windows
2. Double-click: Shopping mart Management system.exe
3. The First Time Setup popup will appear
4. Enter your MySQL root password
5. Click CONNECT & START
6. Database is created automatically
7. Login screen opens

---

## Database Migration

The application handles database migration automatically.

When you run the app for the first time:
- A popup asks for your MySQL root password
- The system automatically creates the database: MartBillingDB
- All tables are created automatically:
  - users
  - products
  - bills
  - bill_items
- Default admin account is created automatically
- Sample products are inserted automatically

No manual SQL scripts need to be run.

If you prefer to set up the database manually, a script is provided:
- File: MartBillingDB_Setup.sql
- Open MySQL Workbench
- File → Open SQL Script → select MartBillingDB_Setup.sql
- Click the lightning bolt to run it

---

## Default Login Credentials

| Role | Username | Password |
|------|----------|----------|
| Administrator | admin | admin123 |

You can add Cashier accounts from inside the application
after logging in as Admin → Cashiers section.

---

## Configuration

The application saves your MySQL password in a local file:
- File name: db_settings.txt
- Location: same folder as the .exe file

This file is created automatically on first run.
If you need to change the MySQL password later,
simply delete db_settings.txt and restart the app.
The setup popup will appear again.

---

## Troubleshooting

| Problem | Solution |
|---------|----------|
| Setup popup shows wrong password error | Check MySQL Server is running. Re-enter correct password. |
| App closes immediately on startup | Make sure .NET Runtime is installed |
| Cannot connect to database | Open MySQL Workbench and verify MySQL Server is running |
| Products showing duplicates | Run the cleanup SQL in MySQL Workbench |

---

## Cross-Platform Compatibility

The application is built for Windows using .NET 10 Windows Forms.
It is compatible with:
- Windows 7 (64-bit)
- Windows 8 / 8.1
- Windows 10
- Windows 11

---

## Project Structure
Shopping mart Management system/
│
├── Database/               Layer 2: Data Access (Repository Pattern)
│   ├── DbConnection.cs     MySQL connection string and auto-setup
│   ├── BaseRepository.cs   Abstract base with GetConnection()
│   ├── UserRepository.cs   All user/cashier database operations
│   ├── ProductRepository.cs All product database operations
│   ├── BillRepository.cs   All billing and reports operations
│   └── SessionManager.cs   Stores logged-in user session data
│
├── Models/                 Layer 1: Data Blueprints
│   ├── Product.cs
│   ├── User.cs
│   ├── Bill.cs
│   └── BillItem.cs
│
├── Forms/                  Layer 3: User Interface
│   ├── Auth/               Login and setup screens
│   ├── Admin/              Admin-only screens
│   └── Cashier/            Cashier-only screens
│
├── MartBillingDB_Setup.sql  Manual database setup script
├── README.txt               Setup and usage guide
└── DEPLOYMENT.md            This file

---

## Git Repository

Repository: https://github.com/farmanbukhari7/SMMS-Shopping-Mart

---

*Developed by: Farman Haider Bukhari | Ag#: 2024-ag-6593 | UAF Department of Computer Science*