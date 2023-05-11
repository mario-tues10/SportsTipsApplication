using DataManagement.Interfaces;
using DataManagement.Entities;
using System.Data.SqlClient;
namespace DataManagement
{
    public class CompetitionRepository : ICompetitionRepository
    {
        public readonly SqlService sqlService;
        public CompetitionRepository(SqlService sqlService)
        {
            this.sqlService = sqlService;
        }
        public void InsertIntoCompetition(Competition competition)
        {
            string query = $"insert into [Competition](name, sport, startDate, endDate) values(@Name, @Sport, " +
                $"@StartDate, @EndDate); Select Scope_Identity();";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@Name", competition.Name);
            cmd.Parameters.AddWithValue("@Sport", competition.CompetitionSport.ToString());
            cmd.Parameters.AddWithValue("@StartDate", competition.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", competition.EndDate);
            int res = sqlService.InsertIntoTable(cmd);
            competition.SetId(res);
        }
        public void DeleteIntoCompetition(Competition competition)
        {

            string query = $"delete from [Competition] where id = @Id";
            SqlCommand sqlCommand = new SqlCommand(query);
            sqlCommand.Parameters.AddWithValue("@Id", competition.GetId());
            sqlService.OperateTable(sqlCommand);
        }
        public Competition? GetCompetitionById(int id)
        {
            Competition? competition = null;
            using (SqlConnection sqlConnection = new SqlConnection(sqlService.connectionString))
            {
                try
                {
                    string query = $"select * from [Competition] where id = @Id";
                    SqlCommand sqlCommand = new SqlCommand(query);
                    sqlCommand.Parameters.AddWithValue("@Id", id);
                    SqlDataReader? reader = sqlService.ReadFromTable(sqlCommand, sqlConnection);
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString(1);
                            Sport sport = Enum.Parse<Sport>(reader.GetString(2));
                            DateTime startDate = reader.GetDateTime(3);
                            DateTime endDate = reader.GetDateTime(4);
                            competition = new Competition(name, sport, startDate, endDate);
                            competition.SetId(id);
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    return null;
                }
            }
            return competition;
        }
        public List<Competition>? GetAllCompetitions()
        {
            List<Competition>? result = new List<Competition>();
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
                            string name = reader.GetString(1);
                            Sport sport = Enum.Parse<Sport>(reader.GetString(2));
                            DateTime startDate = reader.GetDateTime(3);
                            DateTime endDate = reader.GetDateTime(4);
                            Competition competition = new Competition(name, sport, startDate, endDate);
                            competition.SetId(id);
                            result.Add(competition);
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
            using (SqlConnection sqlConnection = new SqlConnection(sqlService.connectionString))
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
        public List<Competition>? GetTipsterCompetitions(IUserRepository userRepository, int tipsterId)
        {
            Tipster? tipster = (Tipster?)userRepository.GetAccountById(tipsterId);
            List<Competition>? result = new List<Competition>();
            using (SqlConnection sqlConnection = new SqlConnection(sqlService.connectionString))
            {
                string query = $"select * from [Competition] where sport = @Sport";
                SqlCommand sqlCommand = new SqlCommand(query);
                sqlCommand.Parameters.AddWithValue("@Sport", tipster.Specialty);
                SqlDataReader? reader = sqlService.ReadFromTable(sqlCommand, sqlConnection);
                try
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            Sport sport = Enum.Parse<Sport>(reader.GetString(2));
                            DateTime startDate = reader.GetDateTime(3);
                            DateTime endDate = reader.GetDateTime(4);
                            Competition competition = new Competition(name, sport, startDate, endDate);
                            competition.SetId(id);
                            result.Add(competition);
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
