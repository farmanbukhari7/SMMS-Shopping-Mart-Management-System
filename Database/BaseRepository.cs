// ============================================================
// FILE: BaseRepository.cs
// LAYER: Database (Layer 2 - Data Access)
//
// PURPOSE:
//   This is the PARENT class for all Repository files.
//   It contains one shared method — GetConnection() — that
//   every repository uses to connect to the database.
//
//   Instead of writing the same connection code in every
//   repository file, we write it once here and all other
//   repositories inherit (borrow) it automatically.
//
// SIMPLE ANALOGY:
//   Think of BaseRepository as a master key that opens
//   the database door. All repository files get a copy
//   of this master key by inheriting from this class.
//
// CONNECTED TO:
//   - DbConnection.cs        (reads the connection string)
//   - UserRepository.cs      (inherits from this class)
//   - ProductRepository.cs   (inherits from this class)
//   - BillRepository.cs      (inherits from this class)
// ============================================================

using MySql.Data.MySqlClient;

namespace Shopping_mart_Management_system.Database
{
    public abstract class BaseRepository
    {
        // This method creates and returns a new connection
        // to the MySQL database using the connection string
        // stored in DbConnection.cs
        //
        // Every repository calls this method whenever it
        // needs to talk to the database.
        protected MySqlConnection GetConnection()
        {
            // Create a new connection using the address
            // and password from DbConnection.cs
            return new MySqlConnection(DbConnection.ConnectionString);
        }
    }
}