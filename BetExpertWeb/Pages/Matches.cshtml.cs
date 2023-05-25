using DataManagement.Entities;
using DataManagement;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace BetExpertWeb.Pages
{
    [Authorize]
    public class MatchesModel : PageModel
    {
        public List<Match>? Matches { get; set; }
        public MatchService matchService;
        public CompetitionService competitionService;
        public MatchesModel()
        {
            matchService = new MatchService(new MatchRepository());
            competitionService = new CompetitionService(new CompetitionRepository());
        }
        public void OnGet(int competitionId)
        {
            try
            {
                Competition? pickedCompetition = competitionService.GetMyselfById(competitionId);
                Matches = matchService.GetMatches(pickedCompetition);
            }
            catch(Exception) 
            {
                ViewData["ErrorMessage"] = "No competition!";
            }
        }
    }
}
