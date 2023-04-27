using System.ComponentModel.DataAnnotations;

namespace BetExpertWeb.Models
{
    public class PredictionViewModel
    {
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        [Required(ErrorMessage = "Please enter your analyze.")]
        [MaxLength(500, ErrorMessage = "Your analysis is too long.")]
        public string Analysis { get; set; }
        [Required(ErrorMessage = "Please enter your final prediction.")]
        [MaxLength(50, ErrorMessage = "Your final prediction is too long.")]
        public string FinalPrediction { get; set; }
    }
}
