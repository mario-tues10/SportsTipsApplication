using Domain.Entities;
namespace Domain.Interfaces
{
    public interface IClientSuggestions 
    { 
        List<Tipster>? SuggestTipstersBySport(Sport sport);
        List<Prediction>? SportBestTipsterPredictions(Sport sport);
    }
}
