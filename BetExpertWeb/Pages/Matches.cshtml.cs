using DataManagement;
using Entites;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BetExpertWeb.Pages
{
    public class MatchesModel : PageModel
    {
        public List<Match>? Matches { get; set; }
        public void OnGet(int competitionId)
        {
            Matches = GetData.AllCompetitionMatches(competitionId);
        }
    }
}
