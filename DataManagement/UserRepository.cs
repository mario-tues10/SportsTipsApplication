﻿using DataManagement.Interfaces;
using DataManagement.Entities;
using System.Data.SqlClient;
namespace DataManagement
{
    public class UserRepository : IUserRepository
    {
        public readonly SqlService sqlService;
        public UserRepository(SqlService sqlService)
        {
            this.sqlService = sqlService;
        }
        public void InsertIntoAccount(User user) 
        {
            string query = $"insert into [User](username, email, password, role) values(@Username, " +
                $"@Email, @Password, @UserRole); Select Scope_Identity();";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@Username", user.Username);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@UserRole", user.UserRole.ToString());
            int res = sqlService.InsertIntoTable(cmd);
            user.SetId(res);
        }
        public void DeleteIntoAccount(User user)
        {
            string query = $"delete from [User] where id = @Id";
            SqlCommand sqlCommand = new SqlCommand(query);
            sqlCommand.Parameters.AddWithValue("@Id", user.GetId());
            sqlService.OperateTable(sqlCommand);
        }
        public User? GetAccountById(int id)
        {
            User? user = null;
            using (SqlConnection sqlConnection = new SqlConnection(sqlService.connectionString))
            {
                try
                {
                    string query = $"select * from [User] where id = @Id";
                    SqlCommand sqlCommand = new SqlCommand(query);
                    sqlCommand.Parameters.AddWithValue("@Id", id);
                    SqlDataReader? reader = sqlService.ReadFromTable(sqlCommand, sqlConnection);
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string username = reader.GetString(1);
                            string email = reader.GetString(2);
                            string password = reader.GetString(3);
                            UserRole userRole = Enum.Parse<UserRole>(reader.GetString(4));
                            user = new User(username, email, password, userRole);
                            user.SetId(id);
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    return null;
                }
            }
            return user;
        }
        public List<User>? GetAllAccounts()
        {
            List<User>? result = new List<User>();
            using (SqlConnection sqlConnection = new SqlConnection(sqlService.connectionString))
            {
                string query = $"select * from [User]";
                SqlCommand sqlCommand = new SqlCommand(query);
                SqlDataReader? reader = sqlService.ReadFromTable(sqlCommand, sqlConnection);
                try
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string username = reader.GetString(1);
                            string email = reader.GetString(2);
                            string password = reader.GetString(3);
                            UserRole userRole = Enum.Parse<UserRole>(reader.GetString(4));
                            User user = new User(username, email, password, userRole);
                            user.SetId(id);
                            result.Add(user);
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    return null;
                }
            }
            return result;
        }

    }
}