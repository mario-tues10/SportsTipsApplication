using DataManagement.Interfaces;
using DataManagement.Entities;
using System.Data.SqlClient;
namespace DataManagement
{
    public class MatchRepository : IMatchRepository
    {
        public readonly SqlService sqlService;
        public MatchRepository(SqlService sqlService)
        {
            this.sqlService = sqlService;
        }
        public void InsertIntoMatch(Match match)
        {
            string query = $"insert into [Match](firstCompetitor, secondCompetitor, startTime, competition_id)" +
                $"values(@FirstCompetitior, @SecondCompetitor, @StartTime, @CompetitionId); Select Scope_Identity();";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@FirstCompetitior", match.FirstCompetitor);
            cmd.Parameters.AddWithValue("@SecondCompetitor", match.SecondCompetitor);
            cmd.Parameters.AddWithValue("@StartTime", match.StartTime);
            cmd.Parameters.AddWithValue("@CompetitionId", match.CompetitionId);
            int res = sqlService.InsertIntoTable(cmd);
            match.SetId(res);
        }
        public void DeleteIntoMatch(Match match)
        {

            string query = $"delete from [Competition] where id = @Id";
            SqlCommand sqlCommand = new SqlCommand(query);
            sqlCommand.Parameters.AddWithValue("@Id", match.GetId());
            sqlService.OperateTable(sqlCommand);
        }
        public Match? GetMatchById(int id)
        {
            Match? match = null;
            using (SqlConnection sqlConnection = new SqlConnection(sqlService.connectionString))
            {
                try
                {
                    string query = $"select * from [Match] where id = @Id";
                    SqlCommand sqlCommand = new SqlCommand(query);
                    sqlCommand.Parameters.AddWithValue("@Id", id);
                    SqlDataReader? reader = sqlService.ReadFromTable(sqlCommand, sqlConnection);
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string firstCompetitor = reader.GetString(1);
                            string secondCompetitor = reader.GetString(2);
                            DateTime startTime = reader.GetDateTime(3);
                            int competitionId = reader.GetInt32(4);
                            match = new Match(firstCompetitor, secondCompetitor, startTime, competitionId);
                            match.SetId(id);
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    return null;
                }
            }
            return match;
        }
        public List<Match>? GetAllMatches()
        {
            List<Match>? result = new List<Match>();
            using (SqlConnection sqlConnection = new SqlConnection(sqlService.connectionString))
            {
                string query = $"select * from [Competition]";
                SqlCommand sqlCommand = new SqlCommand(query);
                SqlDataReader? reader = sqlService.ReadFromTable(sqlCommand, sqlConnection);
                try
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string firstCompetitor = reader.GetString(1);
                            string secondCompetitor = reader.GetString(2);
                            DateTime startTime = reader.GetDateTime(3);
                            int competitionId = reader.GetInt32(4);
                            Match match = new Match(firstCompetitor, secondCompetitor, startTime, competitionId);
                            match.SetId(id);
                            result.Add(match);
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
        public List<Prediction>? GetMatchPredictions(Match match)
        {
            List<Prediction>? result = new List<Prediction>();
            using (SqlConnection sqlConnection = new SqlConnection(sqlService.connectionString))
            {
                string query = $"select * from [Prediction] where match_id = @Id";
                SqlCommand sqlCommand = new SqlCommand(query);
                sqlCommand.Parameters.AddWithValue("@Id", match.GetId());
                SqlDataReader? reader = sqlService.ReadFromTable(sqlCommand, sqlConnection);
                try
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string analyze = reader.GetString(1);
                            string finalPrediction = reader.GetString(2);
                            int matchId = reader.GetInt32(3);
                            int tipsterId = reader.GetInt32(4);
                            Prediction prediction = new Prediction(analyze, finalPrediction, tipsterId, matchId);
                            prediction.SetId(id);
                            result.Add(prediction);
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
