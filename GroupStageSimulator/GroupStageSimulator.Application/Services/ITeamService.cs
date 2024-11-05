using GroupStageSimulator.Domain;

namespace GroupStageSimulator.Application.Services;

public interface ITeamService
{
    Team GetTeam(Guid id);
    List<Team> GetAll();
    List<Team> CreateTeams();
    void CalculatePosition(List<Team> teams, List<Match> matches);
    void DeleteAll();
    void ResetTeamScores();
}