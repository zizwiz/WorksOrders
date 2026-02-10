using System;
using System.Collections.Generic;
using System.Data.SQLite;

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
                               (OrderNumber, CompanyName, ContactName, Address_Line1, Address_Line2, 
                                Address_Line3, Town, Postcode, Phone_Mobile, Phone_Office, Email, Website)
                               VALUES (@OrderNumber, @CompanyName, @ContactName, @Address_Line1, @Address_Line2,
                                        @Address_Line3, @Town, @Postcode, @Phone_Mobile, @Phone_Office ,@Email, 
                                        @Website)";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
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
                               WHERE CompanyName LIKE @kw OR ContactName LIKE @kw OR Address_Line1 LIKE @kw
                               OR Address_Line2 LIKE @kw OR Address_Line2 LIKE @kw OR Town LIKE @kw
                               OR Postcode LIKE @kw OR Phone_Mobile LIKE @kw OR Phone_Office LIKE @kw OR Email LIKE @kw 
                                OR Website LIKE @kw";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var order = new WorkOrder();
                            order.Id = Convert.ToInt32(reader["Id"]);
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
                               CompanyName=@CompanyName, ContactName@ContactName, Address_Line1=@Address_Line1,
                               Address_Line2=@Address_Line2, Address_Line3=@Address_Line3, Town=@Town,
                               Postcode=@Postcode, Phone_Mobile=@Phone_Mobile, Phone_Office=@Phone_Office,
                                Email=@Email, Website=@Website
                               WHERE Id=@Id";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", order.Id);
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

                    cmd.ExecuteNonQuery();
                }
            }
        }

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
    }
}