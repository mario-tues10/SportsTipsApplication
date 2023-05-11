using Domain;
using Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BetExpertWeb.Pages
{
    [Authorize]
    public class MatchesModel : PageModel
    {
        public List<Match>? Matches { get; set; }
        private WebService WebHelper;
        public MatchesModel()
        {
            WebHelper = new WebService();
        }
        public void OnGet(int competitionId)
        {
            Matches = WebHelper.GetAllCompetitionMathes(competitionId);
        }
    }
}
