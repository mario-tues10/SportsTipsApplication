using Entites;
using System.Data.SqlClient;
using System.Data;
namespace DataManagement
{
    public class SqlService
    {
        private static readonly string connectionString = "Server = mssqlstud.fhict.local; Database=dbi502277;User Id = dbi502277; Password=logaritam25;";
        public static int InsertIntoTable(SqlCommand sqlCommand)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {

                    sqlConnection.Open();
                }
                catch (SqlException)
                {
                    return -1;
                }
                catch (InvalidOperationException)
                {
                    return -1;
                }
                int result = -1;
                try
                {
                    sqlCommand.Connection = sqlConnection;
                    result = Convert.ToInt32(sqlCommand.ExecuteScalar());
                }
                catch (Exception)
                {
                    return -1;
                }
                return result;
            }
        }
        public static int CrudFromTable(SqlCommand sqlCommand)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {

                    sqlConnection.Open();
                }
                catch (SqlException)
                {
                    return -1;
                }
                catch (InvalidOperationException)
                {
                    return -1;
                }
                int result = -1;
                try
                {
                    sqlCommand.Connection = sqlConnection;
                    int res = sqlCommand.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    return -1;
                }
                return result;
            }
        }
        public static SqlDataReader? ReadFromTable(SqlCommand sqlCommand, SqlConnection sqlConnection)
        {
            try
            {
                sqlConnection.Open();
            }
            catch (SqlException)
            {
                return null;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
            SqlDataReader reader = null;
            try
            {
                sqlCommand.Connection = sqlConnection;
                reader = sqlCommand.ExecuteReader();
            }
            catch (Exception)
            {
                return null;
            }
            return reader;
        }
        /*
        public static int SuspendTipster(int id)
        {
            string query = $"update [Tipster] set suspended = '{1}' where id = @Id";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            return CrudIntoTable(sqlCommand);
        }
        */
    }
}

