using Domain.Entities;
using Domain.Interfaces;
using System.Data.SqlClient;
using Match = Domain.Entities.Match;
namespace DataManagement
{
    public class PredictionRepository : IPredictionRepository
    {
        private readonly SqlService sqlService;
        public PredictionRepository()
        {
            this.sqlService = new SqlService();
        }
        public void InsertIntoPrediction(Prediction prediction)
        {
            string query = $"insert into [Prediction](analysis, finalPrediction, creationDate, guessed, sport, tipster_id, match_id)" +
                $"values(@Analysis, @FinalPrediction, @CreationTime, @Guessed, @Sport, @TipsterId, @MatchId); Select Scope_Identity();";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@Analysis", prediction.Analyse);
            cmd.Parameters.AddWithValue("@FinalPrediction", prediction.FinalPrediction);
            cmd.Parameters.AddWithValue("@CreationTime", DateTime.Now);
            cmd.Parameters.AddWithValue("@Guessed", 0);
            cmd.Parameters.AddWithValue("@Sport", prediction.PredictionSport);
            cmd.Parameters.AddWithValue("@TipsterId", prediction.TipsterId);
            cmd.Parameters.AddWithValue("@MatchId", prediction.MatchId);
            int res = sqlService.InsertIntoTable(cmd);
            prediction.SetId(res);
        }
        public void UpdateAccuracy(Prediction prediction)
        {
            string query = $"update [Prediction] set guessed = '{1}' where id = @Id";
            SqlCommand sqlCommand = new SqlCommand(query);
            sqlCommand.Parameters.AddWithValue("@Id", prediction.GetId());
            sqlService.OperateTable(sqlCommand);
        }
        public void DeleteIntoPrediction(Prediction prediction)
        {
            string query = $"delete from [Prediction] where id = @Id";
            SqlCommand sqlCommand = new SqlCommand(query);
            sqlCommand.Parameters.AddWithValue("@Id", prediction.GetId());
            sqlService.OperateTable(sqlCommand);
        }
        public List<Prediction>? GetPredictions()
        {
            List<Prediction>? result = new List<Prediction>();
            using (SqlConnection sqlConnection = sqlService.CreateConnection())
            {
                string query = $"select * from [Prediction]";
                SqlCommand sqlCommand = new SqlCommand(query);
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
                            DateTime creationTime = reader.GetDateTime(3);
                            bool guessed = Convert.ToBoolean(reader.GetByte(4));
                            Sport sport = Enum.Parse<Sport>(reader.GetString(5));
                            int matchId = reader.GetInt32(6);
                            int tipsterId = reader.GetInt32(7);
                            Prediction prediction = new Prediction(analyze, finalPrediction, 
                                creationTime, guessed, sport, tipsterId, matchId);
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
        public Prediction? GetPredictionById(int id)
        {
            Prediction? prediction = null;
            using (SqlConnection sqlConnection = sqlService.CreateConnection())
            {
                string query = $"select * from [Prediction] where id = @Id";
                SqlCommand sqlCommand = new SqlCommand(query);
                sqlCommand.Parameters.AddWithValue("@Id", id);
                SqlDataReader? reader = sqlService.ReadFromTable(sqlCommand, sqlConnection);
                try
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string analyze = reader.GetString(1);
                            string finalPrediction = reader.GetString(2);
                            DateTime creationTime = reader.GetDateTime(3);
                            bool guessed = Convert.ToBoolean(reader.GetByte(4));
                            Sport sport = Enum.Parse<Sport>(reader.GetString(5));
                            int matchId = reader.GetInt32(6);
                            int tipsterId = reader.GetInt32(7);
                            prediction = new Prediction(analyze, finalPrediction, 
                                creationTime, guessed, sport, tipsterId, matchId);
                            prediction.SetId(id);
                        }

                    }
                }
                catch (NullReferenceException)
                {
                    return null;
                }
            }
            return prediction;
        }
        public List<Prediction>? GetMatchPredictions(Match match)
        {
            List<Prediction>? result = new List<Prediction>();
            using (SqlConnection sqlConnection = sqlService.CreateConnection())
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
                            DateTime creationTime = reader.GetDateTime(3);
                            bool guessed = Convert.ToBoolean(reader.GetByte(4));
                            Sport sport = Enum.Parse<Sport>(reader.GetString(5));
                            int matchId = reader.GetInt32(6);
                            int tipsterId = reader.GetInt32(7);
                            Prediction prediction = new Prediction(analyze, finalPrediction, 
                                creationTime, guessed, sport, tipsterId, matchId);
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
        public List<Prediction>? GetSportPredictions(Sport sport)
        {
            List<Prediction>? result = new List<Prediction>();
            using (SqlConnection sqlConnection = sqlService.CreateConnection())
            {
                string query = $"select * from [Prediction] where sport = @Sport";
                SqlCommand sqlCommand = new SqlCommand(query);
                sqlCommand.Parameters.AddWithValue("@Sport", sport.ToString());
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
                            DateTime creationTime = reader.GetDateTime(3);
                            bool guessed = Convert.ToBoolean(reader.GetByte(4));
                            Sport predictionSport = Enum.Parse<Sport>(reader.GetString(5));
                            int matchId = reader.GetInt32(6);
                            int tipsterId = reader.GetInt32(7);
                            Prediction prediction = new Prediction(analyze, finalPrediction,
                                creationTime, guessed, predictionSport, tipsterId, matchId);
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
        /*
        public List<Prediction>? SortedPredictions(Match match)
        {
            List<Prediction>? result = new List<Prediction>();
            using (SqlConnection sqlConnection = sqlService.CreateConnection())
            {
                string query = $"select * from [Prediction] " +
                    $" inner join [Tipster] on [Prediction].tipster_id = [Tipster].tipster_id" +
                    $" where match_id = @Id";
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
                            DateTime creationTime = reader.GetDateTime(3);
                            bool guessed = Convert.ToBoolean(reader.GetByte(4));
                            Sport sport = Enum.Parse<Sport>(reader.GetString(5));
                            int matchId = reader.GetInt32(6);
                            int tipsterId = reader.GetInt32(7);
                            Prediction prediction = new Prediction(analyze, finalPrediction,
                                creationTime, guessed, sport, tipsterId, matchId);
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
        */
    }
}
