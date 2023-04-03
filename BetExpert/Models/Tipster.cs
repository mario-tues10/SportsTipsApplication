namespace BetExpert.Models
{
    public class Tipster : User
    {
        private Sport specialty;
        private decimal successRate;
        private List<Prediction> predictions;
        public List<Prediction> Predictions { get { return predictions; } }

        public Tipster(int id, string username, string email, string password, 
            Sport specialty, decimal successRate, List<Prediction> predictions) : base(id, username, email, password)
        {
            
            this.specialty = specialty;
            this.successRate = successRate;
            this.predictions = predictions;
        }
        public Prediction makePrediction(int id, string analyse, string finalPrediction)
        {
            return new Prediction(id, analyse, finalPrediction);

        }
        public void addPrediction(Prediction prediction)
        {
            this.predictions.Add(prediction);
        }
        public void assignPrediction(Prediction prediction, int match_id)
        {

        }
    }
}
