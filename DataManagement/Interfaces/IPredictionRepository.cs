using DataManagement.Entities;

namespace DataManagement.Interfaces
{
    public interface IPredictionRepository
    {
        void InsertIntoPrediction(Prediction prediction);
        void DeleteIntoPrediction(Prediction prediction);
        List<Prediction>? GetPredictions();
        Prediction? GetPredictionById(int id);
        List<Prediction>? GetMatchPredictions(Match match);
        string GetCreatorUsername(Prediction prediction);
    }
}