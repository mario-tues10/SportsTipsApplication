using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataManagement.Entities;
using Domain;
using DataManagement;
using Microsoft.AspNetCore.Authorization;
namespace BetExpertWeb.Pages
{
    [Authorize]
    public class PredictionsModel : PageModel
    {
        [BindProperty]
        public List<Prediction> Predictions { get; set; }
        private PredictionService predictionService;
        private MatchService matchService;
        public PredictionsModel()
        {
            predictionService = new PredictionService(new PredictionRepository());
            matchService = new MatchService(new MatchRepository());
        }
        public void OnGet(int matchId)
        {
            if (User.IsInRole("Client")) {
                try
                {
                    Match? pickedMatch = matchService.GetMyselfById(matchId);
                    Predictions = predictionService.GetMatchPredictions(pickedMatch);
                }               
                catch (Exception)
                {
                    ViewData["ErrorMessage"] = "No match!";
                }
            }
            if (User.IsInRole("Tipster"))
            {
                 RedirectToPage("PredictionsCreation");
            }
        }
    }
}
