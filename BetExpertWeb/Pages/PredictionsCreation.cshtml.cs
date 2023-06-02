using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BetExpertWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Domain;
using DataManagement;
using Domain.Entities;
namespace BetExpertWeb.Pages
{
    [Authorize]
    public class PredictionsCreationModel : PageModel
    {
        [BindProperty]
        public PredictionCreationViewModel Prediction { get; set; }
        private PredictionService predictionService;
        private MatchService matchService;
        public bool IsSubmitted { get; set; }
        public PredictionsCreationModel()
        {
            Prediction = new PredictionCreationViewModel();
            predictionService = new PredictionService(new PredictionRepository());
            matchService = new MatchService(new MatchRepository());
        }
        public void OnGet(int matchId)
        {
            try
            {
                Match? match = matchService.GetMyselfById(matchId);
                Prediction.HomeTeam = match.FirstCompetitor;
                Prediction.AwayTeam = match.SecondCompetitor;
            }
            catch (NullReferenceException)
            {
                ViewData["ErrorMessage"] = "No match!";
            }
        }
        public IActionResult OnPost(int matchId)
        {
            if (ModelState.IsValid)
            {
                Prediction? prediction = new Prediction(Prediction.Analysis,
                    Prediction.FinalPrediction, DateTime.Now, matchId, Convert.ToInt32(User.FindFirst("id").Value));
                predictionService.CreatePrediction(prediction);
                IsSubmitted = true;
;               return RedirectToPage("Competitions");
            }
            else
            {
                return Page();
            }
        }

    }
}
