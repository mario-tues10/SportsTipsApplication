using Domain.Entities;
namespace Domain.Interfaces
{
    public interface IPredictionRepository
    {
        void InsertIntoPrediction(Prediction prediction);
        void UpdateAccuracy(Prediction prediction);
        void DeleteIntoPrediction(Prediction prediction);
        List<Prediction>? GetPredictions();
        Prediction? GetPredictionById(int id);
        List<Prediction>? GetMatchPredictions(Match match);
        List<Prediction>? GetSportPredictions(Sport sport);
    }
}