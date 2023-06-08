using Domain.Entities;
using Domain.Interfaces;
namespace Domain.Logic
{
    public class ClientSuggestions : IClientSuggestions
    {
        private readonly ITipsterRepository tipsterRepository;
        private readonly IPredictionRepository predictionRepository;
        public ClientSuggestions(ITipsterRepository tipsterRepository, IPredictionRepository predictionRepository)
        {
            this.tipsterRepository = tipsterRepository;
            this.predictionRepository = predictionRepository;
        }
        private decimal CalculateTipsterSuccessRateForSport(Tipster tipster, Sport sport)
        {
            List<Prediction>? Predictions = tipsterRepository.GetPredictions(tipster);
            List<Prediction> sportPredictions = new List<Prediction>();
            int guessedRight = 0;
            foreach(Prediction prediction in Predictions) {
                if (prediction != null )
                {
                    if (prediction.PredictionSport == sport)
                    {
                        sportPredictions.Add(prediction);
                        if (prediction.Guessed)
                        {
                            guessedRight++;
                        }
                    }
                    
                }
            }
            try
            {
                decimal successRate = guessedRight / sportPredictions.Count;
                return successRate;
            }
            catch (Exception)
            {
                return 0;
            }
           
        }
        public List<Tipster>? SuggestTipstersBySport(Sport sport)
        {
            List<Tipster>? Tipsters = tipsterRepository.GetAllAccounts();
            Tipsters.Sort((x, y) => decimal.Compare(this.CalculateTipsterSuccessRateForSport(x, sport), 
                this.CalculateTipsterSuccessRateForSport(y, sport)));
            return Tipsters;
            
        }
        public List<Prediction>? SportBestTipsterPredictions(Sport sport)
        {
            List<Prediction>? Predictions = predictionRepository.GetSportPredictions(sport);
            Predictions.Sort((x, y) => decimal.Compare(CalculateTipsterSuccessRateForSport(
                tipsterRepository.GetCreator(x), sport), CalculateTipsterSuccessRateForSport(tipsterRepository.GetCreator(y), sport)));
            return Predictions;
        }

    }
}
