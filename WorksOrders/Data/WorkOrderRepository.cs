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
                               (OrderNumber, CustomerName, Address, Phone, Email, Website)
                               VALUES (@OrderNumber, @CustomerName, @Address, @Phone, @Email, @Website)";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderNumber", order.OrderNumber);
                    cmd.Parameters.AddWithValue("@CustomerName", order.CustomerName);
                    cmd.Parameters.AddWithValue("@Address", order.Address);
                    cmd.Parameters.AddWithValue("@Phone", order.Phone);
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
                               WHERE CustomerName LIKE @kw OR Address LIKE @kw
                               OR Phone LIKE @kw OR Email LIKE @kw OR Website LIKE @kw";

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
                            order.CustomerName = reader["CustomerName"].ToString();
                            order.Address = reader["Address"].ToString();
                            order.Phone = reader["Phone"].ToString();
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
                               CustomerName=@CustomerName, Address=@Address,
                               Phone=@Phone, Email=@Email, Website=@Website
                               WHERE Id=@Id";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", order.Id);
                    cmd.Parameters.AddWithValue("@CustomerName", order.CustomerName);
                    cmd.Parameters.AddWithValue("@Address", order.Address);
                    cmd.Parameters.AddWithValue("@Phone", order.Phone);
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