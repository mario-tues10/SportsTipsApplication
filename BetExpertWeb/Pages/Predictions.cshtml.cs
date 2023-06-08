using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Entities;
using Domain;
using DataManagement;
using Microsoft.AspNetCore.Authorization;
using Domain.DVOs;
using Domain.Logic;
namespace BetExpertWeb.Pages
{
    [Authorize]
    public class PredictionsModel : PageModel
    { 
        public List<PredictionDVO>? Predictions { get; set; }
        private MatchService matchService;
        private ViewMapper viewMapper;
        public PredictionsModel()
        {
            matchService = new MatchService(new MatchRepository());
            viewMapper = new ViewMapper(new PredictionRepository(), new TipsterRepository(),
                new UserRepository());
        }
        public void OnGet(int matchId)
        {
            try
            {
                Match? pickedMatch = matchService.GetMyselfById(matchId);
                Predictions = viewMapper.MapPredictions(pickedMatch);
            }
            catch (Exception)
            {
                ViewData["ErrorMessage"] = "No match!";
            }
        }
    }
}
