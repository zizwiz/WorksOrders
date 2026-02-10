using System.Data.SQLite;
using System.IO;

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

                    string sql = @"
                        CREATE TABLE WorkOrders (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
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
                            Website TEXT NOT NULL
                        );
                    ";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}