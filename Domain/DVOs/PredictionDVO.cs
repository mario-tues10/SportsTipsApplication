namespace Domain.DVOs
{
    public class PredictionDVO
    {
        public string TipsterUsername { get; private set; }
        public decimal TipsterSuccess { get; private set; }
        public string Analyse { get; private set; }
        public string FinalPrediction { get; private set; }
        public PredictionDVO(string tipsterUsername, decimal tipsterSuccess, string analyse, string finalPrediction)
        {
            TipsterUsername = tipsterUsername;
            TipsterSuccess = tipsterSuccess;
            Analyse = analyse;
            FinalPrediction = finalPrediction;
        }
    }
}
