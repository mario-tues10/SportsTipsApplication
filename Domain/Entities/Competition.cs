namespace Domain.Entities
{
    public class Competition
    {
        private int Id;
        public string Name { get; private set; }
        public Sport CompetitionSport { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public Competition(string name, Sport sport, DateTime startDate, DateTime endDate)
        {
            Name = name;
            CompetitionSport = sport;
            StartDate = startDate;
            EndDate = endDate;
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
