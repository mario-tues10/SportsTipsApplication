using Entites;
using System.Data.SqlClient;
namespace DataManagement
{
    public class InsertService
    {
        public static void InsertIntoUser(User user)
        {
            string query = $"insert into [User](username, email, password) values(@Username, " +
                $"@Email, @Password); Select Scope_Identity();";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@Username", user.Username);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            int res = SqlService.InsertIntoTable(cmd);
            user.SetId(res);
        }
        public static void InsertIntoAdmin(Admin admin)
        {
            InsertIntoUser(admin);
            string query = $"insert into [Admin](admin_id) values(@AdminId)";
            SqlCommand sqlCommand = new SqlCommand(query);
            sqlCommand.Parameters.AddWithValue("@AdminId", admin.GetId());
            SqlService.CrudFromTable(sqlCommand);
        }
        
        public static void InsertIntoTipster(Tipster tipster)
        {
            InsertIntoUser(tipster);
            string query = $"insert into [Tipster](tipster_id, specialty, successRate, suspended) " +
                $"values(@TipsterId, @Specialty, @SuccessRate, @Suspended)";
            SqlCommand sqlCommand = new SqlCommand(query);
            sqlCommand.Parameters.AddWithValue("@TipsterId", tipster.GetId());
            sqlCommand.Parameters.AddWithValue("@Specialty", tipster.Specialty.ToString());
            sqlCommand.Parameters.AddWithValue("@SuccessRate", tipster.SuccessRate);
            sqlCommand.Parameters.AddWithValue("@Suspended", 0);
            SqlService.CrudFromTable(sqlCommand);
        }
        
        public static void InsertIntoMatch(Match match)
        {
            string query = $"insert into [Match](firstCompetitor, secondCompetitor, startTime, competition_id)" +
                $"values(@FirstCompetitior, @SecondCompetitor, @StartTime, @CompetitionId); Select Scope_Identity();";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@FirstCompetitior", match.FirstCompetitor);
            cmd.Parameters.AddWithValue("@SecondCompetitor", match.SecondCompetitor);
            cmd.Parameters.AddWithValue("@StartTime", match.StartTime);
            cmd.Parameters.AddWithValue("@CompetitionId", match.CompetitionId);
            int res = SqlService.InsertIntoTable(cmd);
            match.SetId(res);
        }
        public static void InsertIntoCompetition(Competition competition)
        {
            string query = $"insert into [Competition](name, sport, startDate, endDate) values(@Name, @Sport, " +
                $"@StartDate, @EndDate); Select Scope_Identity();";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@Name", competition.Name);
            cmd.Parameters.AddWithValue("@Sport", competition.CompetitionSport.ToString());
            cmd.Parameters.AddWithValue("@StartDate", competition.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", competition.EndDate);
            int res = SqlService.InsertIntoTable(cmd);
            competition.SetId(res);
        }
        public static void InsertIntoPrediction(Prediction prediction)
        {
            string query = $"insert into [Prediction](analyse, finalPrediction, tipster_id, match_id) values(@Analyse, " +
                $"@FinalPrediction, @TipsterId, @MatchId)";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue ("@Analyse", prediction.Analyse);
            cmd.Parameters.AddWithValue("@FinalPrediciton", prediction.FinalPrediction);
            cmd.Parameters.AddWithValue("@TipsterId", prediction.TipsterId);
            cmd.Parameters.AddWithValue("@MatchId", prediction.MatchId);
            int res = SqlService.InsertIntoTable(cmd);
            prediction.SetId(res);
        }
        
    }
}
