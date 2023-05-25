using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BetExpertWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Domain;
using DataManagement;
using DataManagement.Entities;
namespace BetExpertWeb.Pages
{
    [Authorize(Roles = "Tipster")]
    public class PredictionsCreationModel : PageModel
    {
        [BindProperty]
        public PredictionCreationViewModel Prediction { get; set; }
        private PredictionService predictionService;
        private TipsterService tipsterService;
        public bool IsSubmitted { get; set; }
        public PredictionsCreationModel()
        {
            predictionService = new PredictionService(new PredictionRepository());
            tipsterService = new TipsterService(new TipsterRepository());
        }
        public void OnGet()
        {
            IsSubmitted = false;
        }
        public IActionResult OnPost(int matchId)
        {
            if (ModelState.IsValid)
            {
                Prediction? prediction = tipsterService.MakePrediction(Prediction.Analysis,
                    Prediction.FinalPrediction, matchId, Convert.ToInt32(User.FindFirst("id").Value));
                predictionService.CreatePrediction(prediction);
;               return RedirectToPage("Competitions");
            }
            else
            {
                ViewData["ErrorMessage"] = "Incorrect data.";
                return Page();
            }
        }

    }
}
