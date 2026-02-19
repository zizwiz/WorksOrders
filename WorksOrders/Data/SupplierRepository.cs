using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using WorksOrders.Data;

namespace WorkOrderApp.Data
{
    public class SupplierRepository
    {
        private readonly string _connectionString;

        public SupplierRepository(string dbPath)
        {
            _connectionString = "Data Source=" + dbPath + ";Version=3;";
        }

        private SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(_connectionString);
        }

        public List<Supplier> GetSuppliers()
        {
            var list = new List<Supplier>();

            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = "SELECT * FROM Suppliers ORDER BY CompanyName";

                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var s = new Supplier();
                        s.Id = Convert.ToInt32(reader["Id"]);
                        s.CompanyName = reader["CompanyName"].ToString();
                        s.ContactName = reader["ContactName"].ToString();
                        s.Address_Line1 = reader["Address_Line1"].ToString();
                        s.Address_Line2 = reader["Address_Line2"].ToString();
                        s.Address_Line3 = reader["Address_Line3"].ToString();
                        s.Town = reader["Town"].ToString();
                        s.Postcode = reader["Postcode"].ToString();
                        s.Phone_Mobile = reader["Phone_Mobile"].ToString();
                        s.Phone_Office = reader["Phone_Office"].ToString();
                        s.Email = reader["Email"].ToString();
                        s.Website = reader["Website"].ToString();
                        s.Category = reader["Category"].ToString();

                        list.Add(s);
                    }
                }
            }

            return list;
        }


        public void AddSupplier(Supplier s)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = @"
            INSERT INTO Suppliers
            (CompanyName, ContactName, Address_Line1, Address_Line2, Address_Line3,
             Town, Postcode, Phone_Mobile, Phone_Office, Email, Website, Category)
            VALUES
            (@CompanyName, @ContactName, @Address_Line1, @Address_Line2, @Address_Line3,
             @Town, @Postcode, @Phone_Mobile, @Phone_Office, @Email, @Website, @Category)
        ";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CompanyName", s.CompanyName);
                    cmd.Parameters.AddWithValue("@ContactName", s.ContactName);
                    cmd.Parameters.AddWithValue("@Address_Line1", s.Address_Line1);
                    cmd.Parameters.AddWithValue("@Address_Line2", s.Address_Line2);
                    cmd.Parameters.AddWithValue("@Address_Line3", s.Address_Line3);
                    cmd.Parameters.AddWithValue("@Town", s.Town);
                    cmd.Parameters.AddWithValue("@Postcode", s.Postcode);
                    cmd.Parameters.AddWithValue("@Phone_Mobile", s.Phone_Mobile);
                    cmd.Parameters.AddWithValue("@Phone_Office", s.Phone_Office);
                    cmd.Parameters.AddWithValue("@Email", s.Email);
                    cmd.Parameters.AddWithValue("@Website", s.Website);
                    cmd.Parameters.AddWithValue("@Category", s.Category);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateSupplier(Supplier s)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = @"
                    UPDATE Suppliers SET
                        CompanyName=@CompanyName,
                        ContactName=@ContactName,
                        Address_Line1=@Address_Line1,
                        Address_Line2=@Address_Line2,
                        Address_Line3=@Address_Line3,
                        Town=@Town,
                        Postcode=@Postcode,
                        Phone_Mobile=@Phone_Mobile,
                        Phone_Office=@Phone_Office,
                        Email=@Email,
                        Website=@Website,
                        Category=@Category
                    WHERE Id=@Id
                ";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", s.Id);
                    cmd.Parameters.AddWithValue("@CompanyName", s.CompanyName);
                    cmd.Parameters.AddWithValue("@ContactName", s.ContactName);
                    cmd.Parameters.AddWithValue("@Address_Line1", s.Address_Line1);
                    cmd.Parameters.AddWithValue("@Address_Line2", s.Address_Line2);
                    cmd.Parameters.AddWithValue("@Address_Line3", s.Address_Line3);
                    cmd.Parameters.AddWithValue("@Town", s.Town);
                    cmd.Parameters.AddWithValue("@Postcode", s.Postcode);
                    cmd.Parameters.AddWithValue("@Phone_Mobile", s.Phone_Mobile);
                    cmd.Parameters.AddWithValue("@Phone_Office", s.Phone_Office);
                    cmd.Parameters.AddWithValue("@Email", s.Email);
                    cmd.Parameters.AddWithValue("@Website", s.Website);
                    cmd.Parameters.AddWithValue("@Category", s.Category);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteSupplier(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = "DELETE FROM Suppliers WHERE Id=@Id";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Supplier> SearchSuppliers(string keyword)
        {
            var list = new List<Supplier>();

            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT * FROM Suppliers
                    WHERE CompanyName LIKE @kw
                       OR ContactName LIKE @kw
                       OR Town LIKE @kw
                       OR Postcode LIKE @kw
                       OR Email LIKE @kw
                        OR Category LIKE @kw
                    ORDER BY CompanyName
                ";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var s = new Supplier();
                            s.Id = Convert.ToInt32(reader["Id"]);
                            s.CompanyName = reader["CompanyName"].ToString();
                            s.ContactName = reader["ContactName"].ToString();
                            s.Address_Line1 = reader["Address_Line1"].ToString();
                            s.Address_Line2 = reader["Address_Line2"].ToString();
                            s.Address_Line3 = reader["Address_Line3"].ToString();
                            s.Town = reader["Town"].ToString();
                            s.Postcode = reader["Postcode"].ToString();
                            s.Phone_Mobile = reader["Phone_Mobile"].ToString();
                            s.Phone_Office = reader["Phone_Office"].ToString();
                            s.Email = reader["Email"].ToString();
                            s.Website = reader["Website"].ToString();
                            s.Category = reader["Category"].ToString();

                            list.Add(s);
                        }
                    }
                }
            }

            return list;
        }

        public void AddSupplierAttachment(int supplierId, string sourceFile)
        {
            string baseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SupplierAttachments");
            string supplierDir = Path.Combine(baseDir, supplierId.ToString());

            if (!Directory.Exists(supplierDir))
                Directory.CreateDirectory(supplierDir);

            string fileName = Path.GetFileName(sourceFile);
            string destPath = Path.Combine(supplierDir, Guid.NewGuid() + "_" + fileName);

            File.Copy(sourceFile, destPath);

            MessageBox.Show("Attachment added.");
        }

        //List all the attachments
        public List<SupplierAttachment> GetFiles(int Id)
        {
            var list = new List<SupplierAttachment>();

            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = @"SELECT Id, FileName, FilePath 
                       FROM Suppliers 
                       WHERE Id = @Id
";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var file = new SupplierAttachment();
                            file.FileName = reader["FileName"].ToString();
                            file.FilePath = reader["FilePath"].ToString();

                            list.Add(file);
                        }
                    }
                }
            }

            return list;
        }

    }
}