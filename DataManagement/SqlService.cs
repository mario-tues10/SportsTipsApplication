using System.Data.SqlClient;
namespace DataManagement
{
    public class SqlService
    {
        public readonly string connectionString = "Server = mssqlstud.fhict.local; Database=dbi502277;" +
            "User Id = dbi502277; Password=logaritam25;";
        public int InsertIntoTable(SqlCommand sqlCommand)
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
        public int OperateTable(SqlCommand sqlCommand)
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
        public SqlDataReader? ReadFromTable(SqlCommand sqlCommand, SqlConnection sqlConnection)
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
    }
}

