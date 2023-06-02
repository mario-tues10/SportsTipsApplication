using System.ComponentModel.DataAnnotations;
namespace BetExpertWeb.Models
{
    public class PredictionViewModel
    {
        [Required(ErrorMessage = "No tipster username")]
        public string TipsterUsername { get; set; }
        [Required(ErrorMessage = "No success for this tipster.")]
        public decimal TipsterSuccess { get; set; }
        [Required(ErrorMessage = "No tipster analysis.")]
        [MaxLength(500, ErrorMessage = "Your analysis is too long.")]
        public string Analysis { get; set; }
        [Required(ErrorMessage = "No tipster final prediction.")]
        [MaxLength(50, ErrorMessage = "Your final prediction is too long.")]
        public string FinalPrediction { get; set; }
    }
}
