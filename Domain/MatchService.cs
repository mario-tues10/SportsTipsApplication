using Domain.Entities;
using Domain.Interfaces;
namespace Domain
{ 
    public class MatchService
    {
        private readonly IMatchRepository matchRepository;
        public MatchService(IMatchRepository matchRepository)
        {
            this.matchRepository = matchRepository;
        }
        public void CreateMatch(Competition competition, Match match)
        {
            if(match.StartTime < competition.StartDate || match.StartTime > competition.EndDate)
            {
                throw new Exception("The date of the match is out of the competition's date!");
            }
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
