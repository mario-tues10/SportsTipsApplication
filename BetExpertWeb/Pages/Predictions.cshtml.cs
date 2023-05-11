using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BetExpertWeb.Models;
using Domain;

namespace BetExpertWeb.Pages
{
    public class PredictionsModel : PageModel
    {
        [BindProperty]
        public PredictionViewModel Prediction { get; set; }
        private WebService WebHelper;
        public bool PredictionSubmitted { get; private set; }
        public PredictionsModel()
        {
            WebHelper = new WebService();
        }
        public void OnGet()
        {
            PredictionSubmitted = false;
        }
        public IActionResult OnPost(int matchId)
        {
            if (ModelState.IsValid)
            {
                PredictionSubmitted = true;
                int tipsterCreatorId = Convert.ToInt32(User.FindFirst("id").Value);
                WebHelper.AddPrediction(Prediction.Analysis, Prediction.FinalPrediction, tipsterCreatorId, matchId);
                return new RedirectToPageResult("SuccessfulPrediction");
            }
            else
            {
                ViewData["ErrorMessage"] = "Incorrect data.";
                return Page();
            }
        }

    }
}
