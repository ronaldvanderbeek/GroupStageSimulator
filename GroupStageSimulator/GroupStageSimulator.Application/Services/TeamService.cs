using GroupStageSimulator.Domain;
using GroupStageSimulator.Domain.Factories;
using GroupStageSimulator.Infrastructure;

namespace GroupStageSimulator.Application.Services
{
    public class TeamService(ITeamRepository teamRepository) : ITeamService
    {
        private static readonly string[] TeamNames = ["FC Knudde", "FC Bal op het dak", "Kelder klasse15", "VV Derde helft"];
        public Team GetTeam(Guid id) => teamRepository.GetTeamById(id);

        public List<Team> GetAll() => teamRepository.GetAll();

        public void DeleteAll() => teamRepository.DeleteAll();

        public List<Team> CreateTeams()
        {
            var teams = new List<Team>();
            foreach (var name in TeamNames)
            {
                var team = TeamFactory.Create(name);
                teams.Add(team);

                teamRepository.Add(team);
            }

            return teams;
        }

        public void ResetTeamScores()
        {
            var teams = teamRepository.GetAll();
            foreach (var team in teams)
            {
                teamRepository.Update(team.Id, 0, 0, 0, 0, 0, 0, 0);
            }
        }

        public void CalculatePosition(List<Team> teams, List<Match> matches)
        {
            PositionCalculator.CalculatePositions(teams, matches);
        }
    }
}
