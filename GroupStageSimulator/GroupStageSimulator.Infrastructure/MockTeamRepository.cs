using System.Runtime.InteropServices.ComTypes;
using GroupStageSimulator.Domain;

namespace GroupStageSimulator.Infrastructure
{
    public class MockTeamRepository : ITeamRepository
    {
        private readonly Dictionary<Guid, Team> _teams = [];
        public Team? GetTeamById(Guid id)
        {
            _teams.TryGetValue(id, out var team);
            return team;
        }

        public List<Team?> GetAll() => _teams.Values.ToList();
        public void Add(Team team)
        {
            _teams.Add(team.Id, team);
        }

        public void DeleteAll()
        {
            _teams.Clear();
        }

        public bool Update(Guid id, int played, int points, int goalsFor, int goalsAgainst, int win, int draw, int loss)
        {
            if (_teams.TryGetValue(id, out var team))
            {
                team.Played = played;
                team.Points = points;
                team.GoalsFor = goalsFor;
                team.GoalsAgainst = goalsAgainst;
                team.Win = win;
                team.Draw = draw;
                team.Loss = loss;
                return true;
            }

            return false;
        }
    }
}