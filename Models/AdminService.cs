using DataManagement;
using Entites;
namespace Domain
{
    public class AdminService
    {
        public List<Competition> Competitions { get; private set; }
        public List<User> Users { get; private set; }
        public List<Tipster> Tipsters { get; private set; }
        public List<Match> Matches { get; private set; }

        public AdminService()
        {
            try
            {
                Competitions = new List<Competition>(GetData.AllCompetitions());
            }
            catch (ArgumentNullException)
            {
                Competitions = new List<Competition>();
            }
            try
            {
                Users = new List<User>(GetData.AllUsers());
            }
            catch (ArgumentNullException)
            {
                Users = new List<User>();
            }

            try
            {
                Matches = new List<Match>(GetData.AllMatches());
            }
            catch (ArgumentNullException)
            {
                Matches = new List<Match>();
            }
            try
            {
                Tipsters = new List<Tipster>(GetData.AllTipsters());
            }
            catch (ArgumentNullException)
            {
                Tipsters = new List<Tipster>();
            }
        }
        public void AddCompetition(string name, Sport sport, DateTime startDate, DateTime endDate)
        {
            if(endDate < startDate)
            {
                throw new Exception("Your end date is before begin date!");
            }
            Competition newCompetition = new Competition(name, sport, startDate, endDate);
            try
            {
                InsertService.InsertIntoCompetition(newCompetition);
            }
            catch (Exception)
            {
                throw new Exception();
            }
            Competitions.Add(newCompetition);
            
        }
        
        public void RemoveCompetition(int id)
        {
            Competition? competition = GetData.FindCompetitionById(id);
            if (competition == null)
            {
                throw new NullReferenceException("No competition with that id!");
            }
            else
            {
                DeleteService.DeleteFromCompetition(competition);
                Competitions.Remove(competition);
            }
            
        }
        
        public void AddMatch(string firstCompetitior, string secondCompetitior, DateTime startTime, int competitionId)
        {
            if (startTime < DateTime.Now)
            {
                throw new Exception("Match should have been started!");
            }
            Match newMatch = new Match(firstCompetitior, secondCompetitior, startTime, competitionId);
            try
            {
                InsertService.InsertIntoMatch(newMatch);
            }catch(Exception)
            {
                throw new Exception();
            }
            Matches.Add(newMatch);
        }
        
        public void RemoveMatch(int id)
        {
            Match? match = GetData.FindMatchById(id);
            if (match == null)
            {
                throw new NullReferenceException("No match with that id!");
            }
            else
            {
                DeleteService.DeleteFromMatch(match);
                Matches.Remove(match);
            }
        }
        /*
        public void suspendTipster(int id)
        {
            int res = SqlService.SuspendTipster(id);
            if (res == -1)
            {
                throw new Exception("Error in suspending tipster!");
            }
        }
        */
        public List<Competition> AllCompetitions()
        {
            return Competitions;
        }
        public List<Match> AllMatches()
        {
            return Matches;
        }
        public List<Tipster> AllTipsters()
        {
            return Tipsters;
        }
        public List<User> AllUsers()
        {
            return Users;
        }
    }
}
