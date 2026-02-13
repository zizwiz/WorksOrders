using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace WorkOrderApp.Data
{
    public class WorkOrderRepository
    {
        private readonly string _connectionString;

        public WorkOrderRepository(string dbPath)
        {
            _connectionString = "Data Source=" + dbPath + ";Version=3;";
        }

        private SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(_connectionString);
        }

        public void Add(WorkOrder order)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = @"INSERT INTO WorkOrders 
                               (Project, OrderNumber, CompanyName, ContactName, Address_Line1, Address_Line2, 
                                Address_Line3, Town, Postcode, Phone_Mobile, Phone_Office, Email, Website,
                                ProjectStartDate, ProjectEndDate)
                               VALUES (@Project, @OrderNumber, @CompanyName, @ContactName, @Address_Line1, @Address_Line2,
                                        @Address_Line3, @Town, @Postcode, @Phone_Mobile, @Phone_Office ,@Email, 
                                        @Website, @ProjectStartDate, @ProjectEndDate)";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Project", order.Project); 
                    cmd.Parameters.AddWithValue("@OrderNumber", order.OrderNumber);
                    cmd.Parameters.AddWithValue("@CompanyName", order.CompanyName);
                    cmd.Parameters.AddWithValue("@ContactName", order.ContactName);
                    cmd.Parameters.AddWithValue("@Address_Line1", order.Address_Line1);
                    cmd.Parameters.AddWithValue("@Address_Line2", order.Address_Line2);
                    cmd.Parameters.AddWithValue("@Address_Line3", order.Address_Line3);
                    cmd.Parameters.AddWithValue("@Town", order.Town);
                    cmd.Parameters.AddWithValue("@Postcode", order.Postcode);
                    cmd.Parameters.AddWithValue("@Phone_Mobile", order.Phone_Mobile);
                    cmd.Parameters.AddWithValue("@Phone_Office", order.Phone_Office);
                    cmd.Parameters.AddWithValue("@Email", order.Email);
                    cmd.Parameters.AddWithValue("@Website", order.Website);

                    cmd.Parameters.AddWithValue("@ProjectStartDate",
                        order.ProjectStartDate.HasValue ? order.ProjectStartDate.Value.ToString("dd-MMM-yyyy") : null);

                    cmd.Parameters.AddWithValue("@ProjectEndDate",
                        order.ProjectEndDate.HasValue ? order.ProjectEndDate.Value.ToString("dd-MMM-yyyy") : null);

                   cmd.ExecuteNonQuery();
                }
            }
        }

        public List<WorkOrder> Search(string keyword)
        {
            var list = new List<WorkOrder>();

            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = @"SELECT * FROM WorkOrders
                               WHERE Project LIKE @kw OR CompanyName LIKE @kw OR ContactName LIKE @kw 
                                OR Address_Line1 LIKE @kw OR Address_Line2 LIKE @kw OR Address_Line2 LIKE @kw 
                                OR Town LIKE @kw OR Postcode LIKE @kw OR Phone_Mobile LIKE @kw 
                                OR Phone_Office LIKE @kw OR Email LIKE @kw OR Website LIKE @kw
                                OR ProjectStartDate LIKE @kw OR ProjectEndDate LIKE @kw";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var order = new WorkOrder();
                            order.Id = Convert.ToInt32(reader["Id"]);
                            order.Project = reader["Project"].ToString();
                            order.OrderNumber = reader["OrderNumber"].ToString();
                            order.CompanyName = reader["CompanyName"].ToString();
                            order.ContactName = reader["ContactName"].ToString();
                            order.Address_Line1 = reader["Address_Line1"].ToString();
                            order.Address_Line2 = reader["Address_Line2"].ToString();
                            order.Address_Line3 = reader["Address_Line3"].ToString();
                            order.Town = reader["Town"].ToString();
                            order.Postcode = reader["Postcode"].ToString();
                            order.Phone_Mobile = reader["Phone_Mobile"].ToString();
                            order.Phone_Office = reader["Phone_Office"].ToString();
                            order.Email = reader["Email"].ToString();
                            order.Website = reader["Website"].ToString();
                            
                            string start = reader["ProjectStartDate"].ToString();
                            string end = reader["ProjectEndDate"].ToString();

                            order.ProjectStartDate = string.IsNullOrEmpty(start) ? (DateTime?)null : DateTime.Parse(start);
                            order.ProjectEndDate = string.IsNullOrEmpty(end) ? (DateTime?)null : DateTime.Parse(end);

                            list.Add(order);
                        }
                    }
                }
            }

            return list;
        }

        public void Update(WorkOrder order)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = @"UPDATE WorkOrders SET
                               Project=@Project, CompanyName=@CompanyName, ContactName=@ContactName, Address_Line1=@Address_Line1,
                               Address_Line2=@Address_Line2, Address_Line3=@Address_Line3, Town=@Town,
                               Postcode=@Postcode, Phone_Mobile=@Phone_Mobile, Phone_Office=@Phone_Office,
                                Email=@Email, Website=@Website, ProjectStartDate=@ProjectStartDate,
                                ProjectEndDate=@ProjectEndDate
                               WHERE Id=@Id";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", order.Id);
                    cmd.Parameters.AddWithValue("@Project", order.Project);
                    cmd.Parameters.AddWithValue("@CompanyName", order.CompanyName);
                    cmd.Parameters.AddWithValue("@ContactName", order.ContactName);
                    cmd.Parameters.AddWithValue("@Address_Line1", order.Address_Line1);
                    cmd.Parameters.AddWithValue("@Address_Line2", order.Address_Line2);
                    cmd.Parameters.AddWithValue("@Address_Line3", order.Address_Line3);
                    cmd.Parameters.AddWithValue("@Town", order.Town);
                    cmd.Parameters.AddWithValue("@Postcode", order.Postcode);
                    cmd.Parameters.AddWithValue("@Phone_Mobile", order.Phone_Mobile);
                    cmd.Parameters.AddWithValue("@Phone_Office", order.Phone_Office);
                    cmd.Parameters.AddWithValue("@Email", order.Email);
                    cmd.Parameters.AddWithValue("@Website", order.Website);
                    
                    cmd.Parameters.AddWithValue("@ProjectStartDate",
                           order.ProjectStartDate.HasValue ? order.ProjectStartDate.Value.ToString("dd-MMM-yyyy") : null);

                    cmd.Parameters.AddWithValue("@ProjectEndDate",
                        order.ProjectEndDate.HasValue ? order.ProjectEndDate.Value.ToString("dd-MMM-yyyy") : null);

                     cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddAttachmentFile(int workOrderId, string sourceFilePath)
        {
            string attachmentsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Attachments");

            if (!Directory.Exists(attachmentsDir))
                Directory.CreateDirectory(attachmentsDir);

            string fileName = Path.GetFileName(sourceFilePath);
            string destPath = Path.Combine(attachmentsDir, Guid.NewGuid() + "_" + fileName);

            File.Copy(sourceFilePath, destPath);

            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = @"INSERT INTO WorkOrderFiles (WorkOrderId, FileName, FilePath)
                       VALUES (@WorkOrderId, @FileName, @FilePath)";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@WorkOrderId", workOrderId);
                    cmd.Parameters.AddWithValue("@FileName", fileName);
                    cmd.Parameters.AddWithValue("@FilePath", destPath);
                    cmd.ExecuteNonQuery();
                }
            }
        }

      
        //delete record
        public void Delete(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = "DELETE FROM WorkOrders WHERE Id=@Id";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //List all the attachments
        public List<WorkOrderFile> GetFiles(int workOrderId)
        {
            var list = new List<WorkOrderFile>();

            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = @"SELECT Id, FileName, FilePath 
                       FROM WorkOrderFiles 
                       WHERE WorkOrderId = @WorkOrderId";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@WorkOrderId", workOrderId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var file = new WorkOrderFile();
                            file.Id = Convert.ToInt32(reader["Id"]);
                            file.FileName = reader["FileName"].ToString();
                            file.FilePath = reader["FilePath"].ToString();

                            list.Add(file);
                        }
                    }
                }
            }

            return list;
        }

        
        //List all the project notes
        public List<WorkOrderNote> GetNotes(int workOrderId)
        {
            var list = new List<WorkOrderNote>();

            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = @"SELECT Id, WorkOrderId, Timestamp, NoteText
                       FROM WorkOrderNotes
                       WHERE WorkOrderId = @WorkOrderId
                       ORDER BY Timestamp DESC";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@WorkOrderId", workOrderId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var note = new WorkOrderNote();
                            note.Id = Convert.ToInt32(reader["Id"]);
                            note.WorkOrderId = Convert.ToInt32(reader["WorkOrderId"]);
                            note.Timestamp = DateTime.Parse(reader["Timestamp"].ToString());
                            note.NoteText = reader["NoteText"].ToString();

                            list.Add(note);
                        }
                    }
                }
            }

            return list;
        }

        public void DeleteFile(int fileId)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = "DELETE FROM WorkOrderFiles WHERE Id=@Id";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", fileId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Used to create reports
        public List<WorkOrder> GetProjectsBetweenDates(DateTime from, DateTime to)
        {
            var list = new List<WorkOrder>();

            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = @"
            SELECT * FROM WorkOrders
            WHERE 
                (ProjectStartDate IS NOT NULL AND ProjectStartDate >= @From AND ProjectStartDate <= @To)
                OR
                (ProjectEndDate IS NOT NULL AND ProjectEndDate >= @From AND ProjectEndDate <= @To)
        ";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@From", from.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@To", to.ToString("yyyy-MM-dd"));

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var order = new WorkOrder();

                            order.Id = Convert.ToInt32(reader["Id"]);
                            order.OrderNumber = reader["OrderNumber"].ToString();
                            order.CompanyName = reader["CompanyName"].ToString();
                            order.ContactName = reader["ContactName"].ToString();
                            order.Town = reader["Town"].ToString();
                            order.Postcode = reader["Postcode"].ToString();

                            string start = reader["ProjectStartDate"].ToString();
                            string end = reader["ProjectEndDate"].ToString();

                            order.ProjectStartDate = string.IsNullOrEmpty(start) ? (DateTime?)null : DateTime.Parse(start);
                            order.ProjectEndDate = string.IsNullOrEmpty(end) ? (DateTime?)null : DateTime.Parse(end);

                            list.Add(order);
                        }
                    }
                }
            }

            return list;
        }
    }
}