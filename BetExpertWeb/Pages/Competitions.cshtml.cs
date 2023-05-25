using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using DataManagement.Entities;
using DataManagement;
using Domain;
namespace BetExpertWeb.Pages
{
    [Authorize]
    public class CompetitionsModel : PageModel
    {
        public List<Competition>? Competitions { get; set; }
        private CompetitionService competitionService;
        private TipsterService tipsterService;
        public CompetitionsModel() 
        {
            competitionService = new CompetitionService(new CompetitionRepository());
            tipsterService = new TipsterService(new TipsterRepository());
        }
        public void OnGet()
        {
            /*
            if (User.IsInRole("Client"))
            {
                Competitions = competitionService.GetCompetitions();
            }
            if (User.IsInRole("Tipster"))
            {
                try
                {
                    Tipster? loggedTipster = tipsterService.GetMyselfById(Convert.ToInt32(User.FindFirst("id").Value));
                    Competitions = competitionService.GetTipsterCompetitions(loggedTipster);
                }
                catch(Exception)
                {
                    ViewData["ErrorMessage"] = "No tipster!";
                }
               
            }
            */
        }
    }
}
