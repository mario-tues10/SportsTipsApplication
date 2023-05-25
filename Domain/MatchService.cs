using DataManagement.Interfaces;
using DataManagement.Entities;
using DataManagement;

namespace Domain
{ 
    public class MatchService
    {
        private readonly IMatchRepository matchRepository;
        public MatchService(IMatchRepository matchRepository)
        {
            this.matchRepository = matchRepository;
        }
        public void CreateMatch(Match match)
        {
            matchRepository.InsertIntoMatch(match);
        }
        public void DeleteMatch(Match match)
        {
            matchRepository.DeleteIntoMatch(match);
        }
        public List<Match>? GetMatches()
        {
            return matchRepository.GetAllMatches();
        }
        public List<Match>? GetMatches(Competition competition)
        {
            return matchRepository.GetCompetitionMatches(competition);
        }
        public Match? GetMyselfById(int id)
        {
            return matchRepository.GetMatchById(id);
        }

    }
}
