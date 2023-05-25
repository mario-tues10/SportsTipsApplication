using DataManagement.Interfaces;
using DataManagement.Entities;
namespace Domain
{
    public class PredictionService
    {
        private readonly IPredictionRepository predictionRepository;
        public PredictionService(IPredictionRepository predictionRepository)
        {
            this.predictionRepository = predictionRepository;
        }
        public void CreatePrediction(Prediction prediction)
        {
            predictionRepository.InsertIntoPrediction(prediction);
        }
        public void DeletePrediction(Prediction prediction) 
        { 
            predictionRepository.DeleteIntoPrediction(prediction); 
        }
        public List<Prediction>? GetAllPredictions() 
        {
            return predictionRepository.GetPredictions();
        }
        public Prediction? GetMyselfById(int id)
        {
            return predictionRepository.GetPredictionById(id);
        }
        public List<Prediction>? GetMatchPredictions(Match match)
        {
            return predictionRepository.GetMatchPredictions(match);
        }
        public string GetCreatorUsername(Prediction prediction)
        {
            return predictionRepository.GetCreatorUsername(prediction);
        }

    }

}
