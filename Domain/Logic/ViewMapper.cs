using Domain.DVOs;
using Domain.Entities;
using Domain.Interfaces;
namespace Domain.Logic
{
    public class ViewMapper
    {
        private readonly IPredictionRepository predictionRepository;
        private readonly ITipsterRepository tipsterRepository;
        private readonly IAccountRepository userRepository; 

        public ViewMapper(IPredictionRepository predictionRepository, ITipsterRepository tipsterRepository,
            IAccountRepository accountRepository)
        {
            this.predictionRepository = predictionRepository;
            this.tipsterRepository = tipsterRepository;
            this.userRepository = accountRepository;
        }
        public List<PredictionDVO>? MapPredictions(Match match) 
        {
            try
            {
                List<Prediction>? Predictions = predictionRepository.GetMatchPredictions(match);
                List<PredictionDVO> mappedPredictions = new List<PredictionDVO>();
                foreach(Prediction prediction in Predictions)
                {
                    Tipster? currentTipster = tipsterRepository.GetCreator(prediction);
                    mappedPredictions.Add(new PredictionDVO(currentTipster.Username, currentTipster.SuccessRate,
                        prediction.Analyse, prediction.FinalPrediction));
                }
                return mappedPredictions;
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("No data!");
            }

        }
        public ProfileDVO? MapProfile(int id, string role)
        {
            switch (role)
            {
                case "Client":
                    User? client = userRepository.GetAccountById(id);
                    ProfileDVO? clientDVO = new ProfileDVO(client.Username, client.Email, role, null);
                    return clientDVO;
                case "Tipster":
                    Tipster? tipster = tipsterRepository.GetAccountById(id);
                    ProfileDVO? tipsterDVO = new ProfileDVO(tipster.Username, tipster.Email, role,
                        tipster.SuccessRate);
                    return tipsterDVO;
                default: return null; 
            }
        }
    }
}
