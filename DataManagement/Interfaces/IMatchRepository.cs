using DataManagement.Entities;
namespace DataManagement.Interfaces
{
    public interface IMatchRepository
    {
        void InsertIntoMatch(Match match);
        void DeleteIntoMatch(Match match);
        Match? GetMatchById(int id);
        List<Match>? GetAllMatches();
        List<Match>? GetCompetitionMatches(Competition competition);

    }
}
