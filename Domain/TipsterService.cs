using DataManagement.Interfaces;
using DataManagement.Entities;
using DataManagement;

namespace Domain
{
    public class TipsterService
    {
        private readonly ITipsterRepository tipsterRepository;
        public TipsterService(ITipsterRepository tipsterRepository)
        {
            this.tipsterRepository = tipsterRepository;
        }
        public Prediction MakePrediction(string analysis, string finalPrediction, int matchId, int tipsterId)
        {
            return new Prediction(analysis, finalPrediction, DateTime.Now, tipsterId, matchId);
        }
        public List<Prediction>? GetPredictions(Tipster tipster)
        {
            return tipsterRepository.GetPredictions(tipster);
        }
        public Tipster? GetMyselfById(int id)
        {
            return tipsterRepository.GetAccountById(id);
        }
        public List<Tipster>? GetTipsters()
        {
            return tipsterRepository.GetAllAccounts();
        }
        public int LastPredictionDays(Tipster tipster)
        {
            try
            {
                List<Prediction>? Predictions = tipsterRepository.GetPredictions(tipster);
                Predictions.Sort((x, y) => DateTime.Compare(y.CreationTime, x.CreationTime));
                TimeSpan timeSpan = DateTime.Now.Subtract(Predictions[0].CreationTime);
                return timeSpan.Days;
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Predictions list is empty!");
            }
            catch (ArgumentOutOfRangeException)
            {
                return 0;
            }
        }
        public void DeleteAccount(Tipster tipster)
        {
            tipsterRepository.DeleteIntoAccount(tipster);
        }
    }
}
