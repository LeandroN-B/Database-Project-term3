using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Database_Project_LMB.Models;


namespace Database_Project_LMB.Repositories
{
    public class DbUsersRepository : IUserRepository
    {
        private readonly string _connectionString;

        public DbUsersRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LMBdatabase")
                ?? throw new ArgumentNullException(nameof(configuration), "Connection string cannot be null");
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using (Microsoft.Data.SqlClient.SqlConnection connection = new Microsoft.Data.SqlClient.SqlConnection(_connectionString))
            {
                string query = "SELECT UserID, UserName, MobileNumber, Email FROM Users";
                var command = new SqlCommand(query, connection);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(MapUser(reader));
                    }
                }
            }
            return users;
        }

        public User? GetUserByID(int id)
        {
            using (Microsoft.Data.SqlClient.SqlConnection connection = new Microsoft.Data.SqlClient.SqlConnection(_connectionString))
            {
                string query = "SELECT UserID, UserName, MobileNumber, Email FROM Users WHERE UserID = @id";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return MapUser(reader);
                    }
                }
            }
            return null;
        }

        public void AddUser(User user)
        {
            using (Microsoft.Data.SqlClient.SqlConnection connection = new Microsoft.Data.SqlClient.SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Users (UserName, MobileNumber, Email) VALUES (@UserName, @MobileNumber, @Email)";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserName", user.UserName);
                command.Parameters.AddWithValue("@MobileNumber", user.MobileNumber);
                command.Parameters.AddWithValue("@Email", user.Email);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateUser(User user)
        {
            using (Microsoft.Data.SqlClient.SqlConnection connection = new Microsoft.Data.SqlClient.SqlConnection(_connectionString))
            {
                string query = "UPDATE Users SET UserName = @UserName, MobileNumber = @MobileNumber, Email = @Email WHERE UserID = @UserID";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", user.UserID);
                command.Parameters.AddWithValue("@UserName", user.UserName);
                command.Parameters.AddWithValue("@MobileNumber", user.MobileNumber);
                command.Parameters.AddWithValue("@Email", user.Email);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteUser(User user)
        {
            using (Microsoft.Data.SqlClient.SqlConnection connection = new Microsoft.Data.SqlClient.SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Users WHERE UserID = @UserID";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", user.UserID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private User MapUser(SqlDataReader reader)
        {
            return new User
            {
                UserID = reader.GetInt32(0),
                UserName = reader.GetString(1),
                MobileNumber = reader.GetString(2),
                Email = reader.GetString(3)
            };
        }
    }
}
