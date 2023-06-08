using Domain.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataManagement;
using Domain.Logic;
namespace BetExpertWeb.Pages
{
    public class SuggestedTipstersModel : PageModel
    {
        public Dictionary<Sport, List<Tipster>?> BestTipsters { get; set; }
        public ClientSuggestions ClientSuggestions { get; set; }
        public SuggestedTipstersModel()
        {
            ClientSuggestions = new ClientSuggestions(new TipsterRepository(), new PredictionRepository());
        }
        public void OnGet()
        {
            try
            {
                BestTipsters.Add(Sport.Football, ClientSuggestions.SuggestTipstersBySport(Sport.Football));
                BestTipsters.Add(Sport.Tennis, ClientSuggestions.SuggestTipstersBySport(Sport.Tennis));
                BestTipsters.Add(Sport.Basketball, ClientSuggestions.SuggestTipstersBySport(Sport.Basketball));
            }
            catch (Exception)
            {
                BestTipsters = null;
            }
        }
    }
}
