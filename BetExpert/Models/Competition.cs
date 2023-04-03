namespace BetExpert.Models
{
    public class Competition
    {
        private int id;
        private string name;
        private Sport sport;
        private DateTime startDate;
        private DateTime endDate;
        private List<Match> matches;

        public Competition(int id, string name, Sport sport, DateTime endDate)
        {
            this.id = id;
            this.name = name;
            this.sport = sport;
            this.startDate = DateTime.Now;
            this.endDate = endDate;
            matches = new List<Match>();
        }

    }
}
