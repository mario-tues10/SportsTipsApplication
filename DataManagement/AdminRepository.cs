﻿using DataManagement.Interfaces;
using DataManagement.Entities;
using System.Data.SqlClient;
namespace DataManagement
{
    public class AdminRepository : UserRepository, IUserRepository
    {
        public AdminRepository(SqlService sqlService) : base(sqlService) { }
        public new void InsertIntoAccount(User admin)
        {
            base.InsertIntoAccount(admin);
            string query = $"insert into [Admin](admin_id) values(@AdminId)";
            SqlCommand sqlCommand = new SqlCommand(query);
            sqlCommand.Parameters.AddWithValue("@AdminId", admin.GetId());
            sqlService.OperateTable(sqlCommand);
        }

        public new void DeleteIntoAccount(User admin)
        {
            string query = $"delete from [Admin] where id = @Id";
            SqlCommand sqlCommand = new SqlCommand(query);
            sqlCommand.Parameters.AddWithValue("@Id", admin.GetId());
            sqlService.OperateTable(sqlCommand);
            base.DeleteIntoAccount(admin);
        }
        public new Admin? GetAccountById(int id)
        {
            Admin? admin = null;
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
                            admin = new Admin(username, email, password, userRole);
                            admin.SetId(id);
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    return null;
                }
            }
            return admin;
        }
        public new List<Admin>? GetAllAccounts()
        {
            List<Admin>? result = new List<Admin>();
            using (SqlConnection sqlConnection = new SqlConnection(sqlService.connectionString))
            {
                string query = $"select * from [User] inner join [Admin] on [Admin].admin_id = [User].id";
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
                            Admin admin = new Admin(username, email, password, userRole);
                            admin.SetId(id);
                            result.Add(admin);
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
        public void SuspendTipster(Tipster tipster)
        {
            string query = $"update [Tipster] set suspended = '{1}' where id = @Id";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("@Id", tipster.GetId());
            sqlService.OperateTable(sqlCommand);
        }
    }
}
