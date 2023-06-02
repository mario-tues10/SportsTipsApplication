using System.Data.SqlClient;
namespace Domain.Interfaces
{
    public interface ISqlService
    {
        SqlConnection CreateConnection();
        int InsertIntoTable(SqlCommand sqlCommand);
        int OperateTable(SqlCommand sqlCommand);
        SqlDataReader? ReadFromTable(SqlCommand sqlCommand, SqlConnection sqlConnection);
    }
}
