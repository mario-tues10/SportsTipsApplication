using Microsoft.AspNetCore.Mvc.RazorPages;
using Entites;
using Microsoft.AspNetCore.Authorization;
using Domain;
namespace BetExpertWeb.Pages
{
    [Authorize]
    public class CompetitionsModel : PageModel
    {
        public List<Competition>? Competitions { get; set; }
        public void OnGet()
        {
            if (User.IsInRole("Client"))
            {
                Competitions = WebHelper.GetAllCompetitions();
            }
            if (User.IsInRole("Tipster")){
                Tipster? tipster = WebHelper.GetTipster(Convert.ToInt32(User.FindFirst("id").Value));
                if (tipster != null)
                {
                    Competitions = WebHelper.TispterSpecialtyCompetitions(tipster.Specialty.ToString());
                }
            }
        }
    }
}
