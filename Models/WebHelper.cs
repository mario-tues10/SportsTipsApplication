using DataManagement;
using Entites;
namespace Domain
{
    public class WebHelper
    {
        public static List<Competition>? GetAllCompetitions()
        {
            return GetData.AllCompetitions();
        }
        public static List<Match>? GetAllCompetitionMathes(int competitionId)
        {
            return GetData.AllCompetitionMatches(competitionId);
        }
        public static List<Competition>? TispterSpecialtyCompetitions(string sportSpecialty)
        {
            return GetData.TipsterSpecialtyCompetitions(sportSpecialty);
        }
        public static Tipster? GetTipster(int tipsterId)
        {
            return GetData.FindTipsterById(tipsterId);
        } 
    }
}
