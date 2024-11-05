namespace GroupStageSimulator.Domain.Factories
{
    public static class MatchFactory
    {
        public static Match Create(Guid homeTeamId, Guid awayTeamId) => new() {Id = Guid.NewGuid(), HomeTeamId = homeTeamId, AwayTeamId = awayTeamId };
    }
}
