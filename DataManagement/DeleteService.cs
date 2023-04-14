using Entites;
using System.Data.SqlClient;

namespace DataManagement
{
    public class DeleteService
    {
        public static void DeleteFromPrediction(Prediction prediction)
        {
            string query = $"delete from [Prediction] where id = @Id";
            SqlCommand sqlCommand = new SqlCommand(query);
            sqlCommand.Parameters.AddWithValue("@Id", prediction.GetId());
            SqlService.CrudFromTable(sqlCommand);
        }
        public static void DeleteFromMatch(Match match)
        {
            string query = $"delete from [Match] where id = @Id";
            SqlCommand sqlCommand = new SqlCommand(query);
            sqlCommand.Parameters.AddWithValue("@Id", match.GetId());
            SqlService.CrudFromTable(sqlCommand);
        }
        public static void DeleteFromTipster(Tipster tipster)
        {
            string query = $"delete from [Tipster] where id = @Id";
            SqlCommand sqlCommand = new SqlCommand(query);
            sqlCommand.Parameters.AddWithValue("@Id", tipster.GetId());
            SqlService.CrudFromTable(sqlCommand);
        }
        
        public static void DeleteFromCompetition(Competition competition)
        {
            string query = $"delete from [Competition] where id = @Id";
            SqlCommand sqlCommand = new SqlCommand(query);
            sqlCommand.Parameters.AddWithValue("@Id", competition.GetId());
            SqlService.CrudFromTable(sqlCommand);
        }
    }
}
