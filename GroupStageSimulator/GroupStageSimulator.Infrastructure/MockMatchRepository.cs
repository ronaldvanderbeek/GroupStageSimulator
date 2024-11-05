using GroupStageSimulator.Domain;

namespace GroupStageSimulator.Infrastructure
{
    public class MockMatchRepository : IMatchRepository
    {
        private Dictionary<Guid, Match> _matches = [];
        public Match Add(Match match)
        {
            _matches.Add(match.Id, match);
            return match;
        }

        public List<Match> GetAll() => _matches.Values.ToList();

        public bool Update(Guid id, int homeScore, int awayScore)
        {
            if (_matches.TryGetValue(id, out var match))
            {
                match.HomeScore = homeScore;
                match.AwayScore = awayScore;
                return true;
            }

            return false;
        }

        public void DeleteAll()
        {
            _matches.Clear();
        }
    }
}