using Domain.Entities;
using Domain.Interfaces;
using System.Data.SqlClient;
namespace DataManagement
{
    public class UserRepository : IAccountRepository
    {
        protected readonly SqlService sqlService;
        public UserRepository()
        {
            this.sqlService = new SqlService();
        }
        public void InsertIntoAccount(User user) 
        {
            string query = $"insert into [User](username, email, password, role) values(@Username, " +
                $"@Email, @Password, @UserRole); Select Scope_Identity();";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@Username", user.Username);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Password", user.GetPassword());
            cmd.Parameters.AddWithValue("@UserRole", user.UserRole.ToString());
            int res = sqlService.InsertIntoTable(cmd);
            user.SetId(res);
        }
        public void ChangePassword(User user, string newPassword)
        {
            string query = $"update [User] set password = @Password where id = @Id";
            SqlCommand sqlCommand = new SqlCommand(query);
            sqlCommand.Parameters.AddWithValue("@Password", newPassword);
            sqlCommand.Parameters.AddWithValue("@Id", user.GetId());
            sqlService.OperateTable(sqlCommand);
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
            using (SqlConnection sqlConnection = sqlService.CreateConnection())
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
            using (SqlConnection sqlConnection = sqlService.CreateConnection())
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
        public List<User>? GetAllClients()
        {
            List<User>? result = new List<User>();
            using (SqlConnection sqlConnection = sqlService.CreateConnection())
            {
                string query = $"select * from [User] where role = @Role";
                SqlCommand sqlCommand = new SqlCommand(query);
                sqlCommand.Parameters.AddWithValue("@Role", UserRole.Client);
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
