using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BetExpertWeb.Models;
using Entites;

namespace BetExpertWeb.Pages
{
    public class PredictionsModel : PageModel
    {
        [BindProperty]
        public PredictionViewModel Prediction { get; set; }
        public bool PredictionSubmitted { get; private set; }
        public void OnGet()
        {
            PredictionSubmitted = false;
        }

    }
}
