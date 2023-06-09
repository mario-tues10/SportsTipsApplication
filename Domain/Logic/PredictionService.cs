using Domain.Entities;
using Domain.Interfaces;
namespace Domain.Logic
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
        // Decides randomly for now if tipster's prediction is true or false.
        public void DecidePrediction(Prediction prediction)
        {
            Random random = new Random();
            int isGuessed = random.Next(0, 100);
            if(isGuessed % 2 == 0) {
                predictionRepository.UpdateAccuracy(prediction);
            }
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
    }

}
