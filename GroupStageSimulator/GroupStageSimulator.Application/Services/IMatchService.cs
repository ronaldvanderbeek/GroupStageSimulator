using GroupStageSimulator.Domain;

namespace GroupStageSimulator.Application.Services;

public interface IMatchService
{
    Match PlayMatch(Match match);
    List<Match> GetAll();
    void DeleteAll();
}