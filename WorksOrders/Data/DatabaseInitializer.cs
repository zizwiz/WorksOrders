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
                            CustomerName TEXT NOT NULL,
                            Address TEXT,
                            Phone TEXT,
                            Email TEXT,
                            Website TEXT
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