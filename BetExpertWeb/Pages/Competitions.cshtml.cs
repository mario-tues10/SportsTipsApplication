using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using DataManagement.Entities;
using DataManagement.Interfaces;
using DataManagement;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace BetExpertWeb.Pages
{
    [Authorize]
    public class CompetitionsModel : PageModel
    {
        public List<Competition>? Competitions { get; set; }
        private readonly ICompetitionRepository competitionRepository;
        public CompetitionsModel() 
        {
            competitionRepository = new CompetitionRepository(new SqlService());
        }
        public void OnGet()
        {
            if (User.IsInRole("Client"))
            {
                Competitions = competitionRepository.GetAllCompetitions();
            }
            if (User.IsInRole("Tipster"))
            {
                Competitions = competitionRepository.GetTipsterCompetitions(new TipsterRepository(new SqlService()),
                    Convert.ToInt32(User.FindFirst("id")));
            }
        }
    }
}
