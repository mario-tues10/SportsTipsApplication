using Entites;
using System.Data.SqlClient;
namespace DataManagement
{
    public class GetData
    {
        private static readonly string connectionString = "Server = mssqlstud.fhict.local; Database=dbi502277;User Id = dbi502277; Password=logaritam25;";
        public static List<Competition>? AllCompetitions()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string query = $"select * from [Competition]";
                SqlCommand sqlCommand = new SqlCommand(query);
                SqlDataReader? reader = SqlService.ReadFromTable(sqlCommand, sqlConnection);
                List<Competition>? result = new List<Competition>();
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
                    return result;

                }catch(NullReferenceException)
                {
                    return null;
                }
            }
        }
        public static List<Prediction>? AllTipsterPredictions(int tipsterId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string query = $"select * from [Prediction] where tipster_id = @Id";
                SqlCommand sqlCommand = new SqlCommand(query);
                sqlCommand.Parameters.AddWithValue("@Id", tipsterId);
                SqlDataReader? reader = SqlService.ReadFromTable(sqlCommand, sqlConnection);
                List<Prediction>? result = new List<Prediction>();
                try
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string analyse = reader.GetString(1);
                            string finalPrediction = reader.GetString(2);
                            int tipster_id = reader.GetInt32(3);
                            int match_id = reader.GetInt32(4);
                            Prediction prediction = new Prediction(analyse, finalPrediction, tipster_id, match_id);
                            prediction.SetId(id);
                            result.Add(prediction);
                        }

                    }
                    return result;
                }
                catch (NullReferenceException) 
                { 
                    return null; 
                }
            }
        }
        public static List<Prediction>? AllMatchPredictions(int matchId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string query = $"select * from [Prediction] where match_id = @Id";
                SqlCommand sqlCommand = new SqlCommand(query);
                sqlCommand.Parameters.AddWithValue("@Id", matchId);
                SqlDataReader? reader = SqlService.ReadFromTable(sqlCommand, sqlConnection);
                List<Prediction>? result = new List<Prediction>();
                try
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            int id = reader.GetInt32(0);
                            string analyse = reader.GetString(1);
                            string finalPrediction = reader.GetString(2);
                            int tipster_id = reader.GetInt32(3);
                            int match_id = reader.GetInt32(4);
                            Prediction prediction = new Prediction(analyse, finalPrediction, tipster_id, match_id);
                            prediction.SetId(id);
                            result.Add(prediction);
                        }

                    }
                    return result;
                }
                catch (NullReferenceException)
                {
                    return null;
                }
            }
        }
        public static List<Match>? AllMatches()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                {
                    string query = $"select * from [Match]";
                    SqlCommand sqlCommand = new SqlCommand(query);
                    SqlDataReader? reader = SqlService.ReadFromTable(sqlCommand, sqlConnection); ;
                    List<Match>? result = new List<Match>();
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
                                int competition_id = reader.GetInt32(4);
                                Match match = new Match(firstCompetitor, secondCompetitor, startTime, competition_id);
                                match.SetId(id);
                                result.Add(match);
                            }
                        }
                        return result;

                    }
                    catch (NullReferenceException)
                    {
                        return null;
                    }
                }
            }
        }
        public static List<Admin>? AllAdmins()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string query = $"select * from [User] inner join [Admin] on [Admin].admin_id = [User].id";
                SqlCommand sqlCommand = new SqlCommand(query);
                SqlDataReader? reader = SqlService.ReadFromTable(sqlCommand, sqlConnection);
                List<Admin>? result = new List<Admin>();
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
                            Admin admin = new Admin(username, email, password);
                            admin.SetId(id);
                            result.Add(admin);
                        }
                    }
                    return result;

                }catch(NullReferenceException)
                {
                    return null;
                }
            }
        }
        public static List<Tipster>? AllTipsters()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string query = $"select * from [User] inner join [Tipster] on [Tipster].tipster_id = [User].id";
                SqlCommand sqlCommand = new SqlCommand(query);   
                SqlDataReader? reader = SqlService.ReadFromTable(sqlCommand, sqlConnection);
                List<Tipster>? result = new List<Tipster>();
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
                            Sport specialty = Enum.Parse<Sport>(reader.GetString(4));
                            decimal successRate = reader.GetDecimal(5);
                            Tipster tipster = new Tipster(username, email, password, specialty, successRate);
                            tipster.SetId(id);
                        }
                    }
                    return result;
                }catch(NullReferenceException)
                {
                    return null;
                }
            }

        }
        public static List<User>? AllUsers()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string query = $"select * from [User]";
                SqlCommand sqlCommand = new SqlCommand(query);
                SqlDataReader? reader = SqlService.ReadFromTable(sqlCommand, sqlConnection);
                List<User>? result = new List<User>();
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
                            User user = new User(username, email, password);
                            user.SetId(id);
                            result.Add(user);
                        }
                    }
                    return result;
                }
                catch (NullReferenceException)
                {
                    return null;
                }
            }
        }

        
        public static Competition? FindCompetitionById(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                Competition? competition = null;
                try
                {
                    string query = $"select * from [Competition] where id = @Id";
                    SqlCommand sqlCommand = new SqlCommand(query);
                    sqlCommand.Parameters.AddWithValue("@Id", id);
                    SqlDataReader? reader = SqlService.ReadFromTable(sqlCommand, sqlConnection);
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
                return competition;
            }
        }
        public static Match? FindMatchById(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            { 
                Match? match = null;
                try
                {
                    string query = $"select * from [Match] where id = @Id";
                    SqlCommand sqlCommand = new SqlCommand(query);
                    sqlCommand.Parameters.AddWithValue("@Id", id);
                    SqlDataReader? reader = SqlService.ReadFromTable(sqlCommand, sqlConnection);
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string firstCompetitor = reader.GetString(1);
                            string secondCompetitor = reader.GetString(2);
                            DateTime startTime = reader.GetDateTime(3);
                            int competition_id = reader.GetInt32(4);
                            match = new Match(firstCompetitor, secondCompetitor, startTime, competition_id);
                            match.SetId(id);
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    return null;
                }
                return match;
            }
        }
        public static Tipster? FindTipsterById(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                Tipster? tipster = null;
                try
                {
                    string query = $"select * from [Tispter] where id = @Id";
                    SqlCommand sqlCommand = new SqlCommand(query);
                    sqlCommand.Parameters.AddWithValue("@Id", id);
                    SqlDataReader? reader = SqlService.ReadFromTable(sqlCommand, sqlConnection);
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string username = reader.GetString(1);
                            string email = reader.GetString(2);
                            string password = reader.GetString(3);
                            Sport specialty = Enum.Parse<Sport>(reader.GetString(4));
                            decimal successRate = reader.GetDecimal(5);
                            tipster = new Tipster(username, email, password, specialty, successRate);
                            tipster.SetId(id);
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    return null;
                }
                
                return tipster;
            }
        }
        public static User? FindUserById(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                User? user = null;
                try
                {
                    string query = $"select * from [User] where id = @Id";
                    SqlCommand sqlCommand = new SqlCommand(query);
                    sqlCommand.Parameters.AddWithValue("@Id", id);
                    SqlDataReader? reader = SqlService.ReadFromTable(sqlCommand, sqlConnection);
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string username = reader.GetString(1);
                            string email = reader.GetString(2);
                            string password = reader.GetString(3);
                            user = new User(username, email, password);
                            user.SetId(id);
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    return null;
                }
                return user;
            }
        }
    }
}
