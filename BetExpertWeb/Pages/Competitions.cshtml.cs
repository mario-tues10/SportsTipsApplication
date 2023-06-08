using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Domain.Entities;
using Domain;
using DataManagement;
using Domain.Logic;
namespace BetExpertWeb.Pages
{
    [Authorize]
    public class CompetitionsModel : PageModel
    {
        public List<Competition>? Competitions { get; set; }
        private CompetitionService competitionService;
        public CompetitionsModel()
        {
            competitionService = new CompetitionService(new CompetitionRepository());
        }
        public void OnGet()
        {
            Competitions = competitionService.GetCompetitions();
        }
    }
}
