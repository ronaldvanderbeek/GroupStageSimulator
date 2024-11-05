using GroupStageSimulator.Domain;

namespace GroupStageSimulator.Infrastructure;

public interface IMatchRepository
{
    List<Match> GetAll();
    Match Add(Match match);
    bool Update(Guid id, int homeScore, int awayScore);
    void DeleteAll();
}