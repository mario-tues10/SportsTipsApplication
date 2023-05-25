using System.ComponentModel.DataAnnotations;
namespace BetExpertWeb.Models
{
    public class PredictionCreationViewModel
    {

        [Required(ErrorMessage = "Error in home team.")]
        public string HomeTeam { get; set; }

        [Required(ErrorMessage = "Error in away team.")]
        public string AwayTeam { get; set; }
        [Required(ErrorMessage = "Please enter your analyze.")]
        [MaxLength(500, ErrorMessage = "Your analysis is too long.")]
        public string Analysis { get; set; }
        [Required(ErrorMessage = "Please enter your final prediction.")]
        [MaxLength(50, ErrorMessage = "Your final prediction is too long.")]
        public string FinalPrediction { get; set; }
    }
}
