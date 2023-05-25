using System.Data.SqlClient;
namespace DataManagement.Interfaces
{
    public interface ISqlService
    {
        SqlConnection CreateConnection();
        int InsertIntoTable(SqlCommand sqlCommand);
        int OperateTable(SqlCommand sqlCommand);
        SqlDataReader? ReadFromTable(SqlCommand sqlCommand, SqlConnection sqlConnection);
    }
}
