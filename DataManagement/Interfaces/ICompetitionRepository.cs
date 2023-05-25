using DataManagement.Entities;
namespace DataManagement.Interfaces
{
    public interface ICompetitionRepository
    {
        void InsertIntoCompetition(Competition competition);
        void DeleteIntoCompetition(Competition competition);
        Competition? GetCompetitionById(int id);
        List<Competition>? GetAllCompetitions();

    }
}
