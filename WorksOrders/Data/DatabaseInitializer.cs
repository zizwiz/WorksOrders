using System.Data.SQLite;
using System.IO;
using WorksOrders.Data;

namespace WorkOrderApp.Data
{
    public static class DatabaseInitializer
    {
        public static void Initialize(string dbPath)
        {
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);

                using (var conn = new SQLiteConnection("Data Source=" + dbPath))
                {
                    conn.Open();

                    //-------------------------------------------------------------------
                    string sql = @"
                        CREATE TABLE WorkOrders (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Project TEXT NOT NULL,
                            OrderNumber TEXT NOT NULL,
                            CompanyName TEXT NOT NULL,
                            ContactName TEXT NOT NULL,
                            Address_Line1 TEXT NOT NULL,
                            Address_Line2 TEXT,
                            Address_Line3 TEXT,
                            Town TEXT NOT NULL,
                            Postcode TEXT NOT NULL,
                            Phone_Mobile TEXT NOT NULL,
                            Phone_Office TEXT NOT NULL,
                            Email TEXT NOT NULL,
                            Website TEXT NOT NULL,
                            ProjectStartDate TEXT,
                            ProjectEndDate TEXT,
                            Cost TEXT
                        );
                    ";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    //--------------------------------------------------------------------------------
                    // This is a block from here to marker below. add blocks for new tables
                    // Create WorkOrderFiles table to store attached files
                    string sqlFiles = @"
                        CREATE TABLE WorkOrderFiles (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            WorkOrderId INTEGER NOT NULL,
                            FileName TEXT NOT NULL,
                            FilePath TEXT NOT NULL,
                            FOREIGN KEY (WorkOrderId) REFERENCES WorkOrders(Id)
                        );
                    ";

                    using (var cmd = new SQLiteCommand(sqlFiles, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Bottom of marker
                    //----------------------------------------------------------------------------------
                    string sqlSuppliers = @"
                            CREATE TABLE Suppliers (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                CompanyName TEXT NOT NULL,
                                ContactName TEXT,
                                Address_Line1 TEXT,
                                Address_Line2 TEXT,
                                Address_Line3 TEXT,
                                Town TEXT,
                                Postcode TEXT,
                                Phone_Mobile TEXT,
                                Phone_Office TEXT,
                                Email TEXT,
                                Website TEXT,
                                Category TEXT
                            );
                        ";

                    using (var cmd = new SQLiteCommand(sqlSuppliers, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    //---------------------------------------------------------------------------

                    string sqlUsers = @"
                           CREATE TABLE Users (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Username TEXT NOT NULL UNIQUE,
                            PasswordHash TEXT NOT NULL,
                            Role TEXT NOT NULL
                            );
                    ";

                    using (var cmd = new SQLiteCommand(sqlUsers, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    //passwords stored as SHA256 this is simple and secure for this type of app.

                    string sqlCheck = "SELECT COUNT(*) FROM Users";

                    using (var cmd = new SQLiteCommand(sqlCheck, conn))
                    {
                        long count = (long)cmd.ExecuteScalar();

                        if (count == 0)
                        {
                            string defaultPass = UserRepository.HashPassword("admin");
                            string sqlInsert = @"INSERT INTO Users (Username, PasswordHash, Role)
                             VALUES ('superuser', @PasswordHash, 'Superuser')";

                            using (var cmd2 = new SQLiteCommand(sqlInsert, conn))
                            {
                                cmd2.Parameters.AddWithValue("@PasswordHash", defaultPass);
                                cmd2.ExecuteNonQuery();
                            }
                        }
                    }

                    //---------------------------------------------------------------------------
                    
                }
            }
        }
    }
}