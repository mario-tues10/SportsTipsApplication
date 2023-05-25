using DataManagement.Interfaces;
using DataManagement.Entities;
namespace Domain
{
    public class CompetitionService
    {
        private readonly ICompetitionRepository competitionRepository;
        public CompetitionService(ICompetitionRepository competitionRepository)
        {
            this.competitionRepository = competitionRepository;
        }
        public void CreateCompetition(Competition competition)
        {
            competitionRepository.InsertIntoCompetition(competition);
        }
        public void DeleteCompetition(Competition competition)
        {
            competitionRepository.DeleteIntoCompetition(competition);
        }
        public List<Competition>? GetCompetitions()
        {
            return competitionRepository.GetAllCompetitions();
        }
        public Competition? GetMyselfById(int id) 
        { 
            return competitionRepository.GetCompetitionById(id);
        }

    }
}
