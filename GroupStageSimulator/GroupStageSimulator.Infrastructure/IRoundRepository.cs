using GroupStageSimulator.Domain;

namespace GroupStageSimulator.Infrastructure
{
    public interface IRoundRepository
    {
        void Add(Round round);
        List<Round> GetAll();
        void DeleteAll();
    }
}
