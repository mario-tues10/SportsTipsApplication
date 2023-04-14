using Microsoft.AspNetCore.Mvc.RazorPages;
using Entites;
using DataManagement;
namespace BetExpertWeb.Pages
{
    public class CompetitionsModel : PageModel
    {
        public List<Competition>? Competitions { get; set; }
        public int CompetitionId { get; set; }  
        public void OnGet()
        {
            Competitions = GetData.AllCompetitions();
        }
    }
}
