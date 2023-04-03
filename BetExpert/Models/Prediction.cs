namespace BetExpert.Models
{
    public class Prediction
    {
        private int id;
        private string analyse;
        private string finalPrediction;
        public Prediction(int id, string analyse, string finalPrediction)
        {
            this.id = id;
            this.analyse = analyse;
            this.finalPrediction = finalPrediction;
        }
    }
}
