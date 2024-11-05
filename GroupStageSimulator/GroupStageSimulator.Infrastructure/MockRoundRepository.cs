using GroupStageSimulator.Domain;

namespace GroupStageSimulator.Infrastructure
{
    public class MockRoundRepository : IRoundRepository
    {
        private readonly List<Round> _rounds = [];
        public void Add(Round round)
        {
           _rounds.Add(round);
        }

        public List<Round> GetAll()
        {
            return _rounds;
        }

        public void DeleteAll()
        {
            _rounds.Clear();
        }
    }
}