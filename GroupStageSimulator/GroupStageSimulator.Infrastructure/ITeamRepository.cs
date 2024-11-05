using GroupStageSimulator.Domain;

namespace GroupStageSimulator.Infrastructure;

public interface ITeamRepository
{
    void Add(Team team);
    Team? GetTeamById(Guid id);
    List<Team?> GetAll();
    bool Update(Guid id, int played, int points, int goalsFor, int goalsAgainst, int win, int draw, int loss);
    void DeleteAll();
}