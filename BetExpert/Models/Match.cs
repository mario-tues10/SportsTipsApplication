namespace BetExpert.Models
{
    public class Match
    {
        private int id;
        private string firstCompetitor;
        private string secondCompetitor;
        private DateTime startTime;
        private int competition_id;
        private List<Prediction> predictions;
        public List<Prediction> Predictions { get { return predictions; } }

        public Match(int id, string firstCompetitor, string secondCompetitor, DateTime startTime, int competition_id)
        {
            this.id = id;
            this.firstCompetitor = firstCompetitor;
            this.secondCompetitor = secondCompetitor;
            this.startTime = startTime;
            this.competition_id = competition_id;
            predictions = new List<Prediction>();
        }
        

       
    }
}
