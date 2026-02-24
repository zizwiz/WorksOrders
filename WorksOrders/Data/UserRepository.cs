using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;

namespace WorksOrders.Data
{
    public class UserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string dbPath)
        {
            _connectionString = "Data Source=" + dbPath + ";Version=3;";
        }

        private SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(_connectionString);
        }

        public static string HashPassword(string password)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "");
            }
        }

        public void AddUser(AppUser user)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = @"INSERT INTO Users (Username, PasswordHash, Role)
                       VALUES (@Username, @PasswordHash, @Role)";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                    cmd.Parameters.AddWithValue("@Role", user.Role);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public AppUser ValidateLogin(string username, string password)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = @"SELECT * FROM Users WHERE Username=@Username";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedHash = reader["PasswordHash"].ToString();
                            string enteredHash = HashPassword(password);

                            if (storedHash == enteredHash)
                            {
                                return new AppUser
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Username = reader["Username"].ToString(),
                                    Role = reader["Role"].ToString()
                                };
                            }
                        }
                    }
                }
            }

            return null;
        }

        public List<AppUser> GetAppUsers()
        {
            var list = new List<AppUser>();

            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = "SELECT * FROM Users ORDER BY Username";

                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var s = new AppUser();
                        s.Id = Convert.ToInt32(reader["Id"]);
                        s.Username = reader["Username"].ToString();
                        s.PasswordHash = reader["PasswordHash"].ToString();
                        s.Role = reader["Role"].ToString();

                        list.Add(s);
                    }
                }
            }

            return list;
        }

    }
}
