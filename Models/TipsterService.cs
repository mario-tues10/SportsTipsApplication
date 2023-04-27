using DataManagement;
using Entites;
namespace Domain
{
    public class TipsterService
    {
        public List<Tipster> Tipsters { get; private set; }
        public TipsterService()
        {
            try
            {
                Tipsters = GetData.AllTipsters();
            }catch(Exception)
            {
                Tipsters = new List<Tipster>();
            }
        }
        public Tipster? GetMyself(int tipsterId)
        {
            return GetData.FindTipsterById(tipsterId);
        }
        /*
        public void AddPrediction(string analyse, string finalPrediction, int tipsterId, int matchId)
        {
            Prediction prediction = new Prediction(analyse, finalPrediction, tipsterId, matchId);
            InsertService.InsertIntoPrediction(prediction);
            Predictions.Add(prediction);
            
        }
        */
    }
}
