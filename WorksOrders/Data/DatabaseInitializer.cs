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
                            Notes TEXT
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
                    // Create WorkOrderFiles table to store notes
                    string sqlNotes = @"
                        CREATE TABLE WorkOrderNotes (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            WorkOrderId INTEGER NOT NULL,
                            Timestamp TEXT NOT NULL,
                            NoteText TEXT NOT NULL,
                            FOREIGN KEY (WorkOrderId) REFERENCES WorkOrders(Id)
                        );
                    ";

                    using (var cmd = new SQLiteCommand(sqlNotes, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    //------------------------------------------------------------------------------------
                }
            }
        }
    }
}