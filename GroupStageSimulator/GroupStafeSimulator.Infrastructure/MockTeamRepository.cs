using GroupStageSimulator.Domain;

namespace GroupStafeSimulator.Infrastructure
{
    public class MockTeamRepository
    {
        private readonly List<Team> _teams =
        [
            new Team(),
            new Team(),
            new Team(),
            new Team(),
            new Team()
        ];

        public Team GetProductById(Guid id) => _teams.FirstOrDefault(p => p.Id == id);
        public IEnumerable<Team> GetAllProducts() => _teams;
    }
}
