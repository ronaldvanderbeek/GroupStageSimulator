using GroupStageSimulator.Domain;

namespace GroupStageSimulator.Application.Services;

public interface IRoundService
{
    List<Round> CreateRoundsAndMatches(List<Guid> teamIds);
    List<Round> GetRounds();
    void DeleteAll();
}