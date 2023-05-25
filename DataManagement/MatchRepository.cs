using DataManagement.Entities;
using DataManagement.Interfaces;
using System.Data.SqlClient;
namespace DataManagement
{
    public class MatchRepository : IMatchRepository
    {
        private readonly SqlService sqlService;
        public MatchRepository()
        {
            this.sqlService = new SqlService();
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
            using (SqlConnection sqlConnection = sqlService.CreateConnection())
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
            using (SqlConnection sqlConnection = sqlService.CreateConnection())
            {
                string query = $"select * from [Match]";
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
        public List<Match>? GetCompetitionMatches(Competition competition)
        {
            List<Match>? result = new List<Match>();
            using (SqlConnection sqlConnection = sqlService.CreateConnection())
            {
                string query = $"select * from [Match] where competition_id = @Id";
                SqlCommand sqlCommand = new SqlCommand(query);
                sqlCommand.Parameters.AddWithValue("@Id", competition.GetId());
                SqlDataReader? reader = sqlService.ReadFromTable(sqlCommand, sqlConnection);
                try
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string firstCompetitior = reader.GetString(1);
                            string secondCompetitior = reader.GetString(2);
                            DateTime startTime = reader.GetDateTime(3);
                            Match match = new Match(firstCompetitior, secondCompetitior, startTime, competition.GetId());
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
    }
}
