namespace Domain.Entities
{ 
    public class Match
    {
        private int Id;
        public string FirstCompetitor { get; private set; }
        public string SecondCompetitor { get; private set; }
        public DateTime StartTime { get; private set; }
        public int CompetitionId { get; private set; }
        public Match(string firstCompetitor, string secondCompetitor, DateTime startTime, int competition_id)
        {
            FirstCompetitor = firstCompetitor;
            SecondCompetitor = secondCompetitor;
            StartTime = startTime;
            CompetitionId = competition_id;
        }
        public int GetId()
        {
            return Id;
        }
        public void SetId(int id)
        {
            Id = id;
        }

    }
}
