namespace Domain.Entities
{
    public class Prediction
    {
        private int Id;
        public string Analyse { get; private set; }
        public string FinalPrediction { get; private set; }
        public DateTime CreationTime { get; private set; }
        private bool guessed;
        public bool Guessed
        {
            get { return guessed; }
            set { guessed = value; }
        }
        public Sport PredictionSport { get; private set; }
        public int TipsterId { get; private set; }
        public int MatchId { get; private set; }
        public Prediction(string analyse, string finalPrediction, DateTime creationTime, bool guessed, Sport predictionSport,
            int tipsterId, int matchId)
        {
            Analyse = analyse;
            FinalPrediction = finalPrediction;
            CreationTime = creationTime;
            this.guessed = guessed;
            PredictionSport = predictionSport;
            TipsterId = tipsterId;
            MatchId = matchId;

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
