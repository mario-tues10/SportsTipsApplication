using DataManagement;
using Entites;
namespace Domain
{
    public class TipsterService
    {
        public List<Prediction> Predictions { get; private set; }
        public Tipster CurrentTipster { get; private set; }
        public TipsterService(Tipster tipster)
        {
            CurrentTipster = tipster;
            Predictions = new List<Prediction>();
        } 
        /*
        public void FillInformation()
        {
            Predictions = GetData.AllTipsterPredictions(CurrentTipster.Id);
        }
        public void AddPrediction(string analyse, string finalPrediction, int tipsterId, int matchId)
        {
            Prediction prediction = new Prediction(analyse, finalPrediction, tipsterId, matchId);
            int res = InsertService.InsertIntoPrediction(prediction);
            if (res == -1)
            {
                throw new Exception("Error in inserting prediction!");
            }
            else 
            { 
                Predictions.Add(prediction);
            }
        }
        */
    }
}
