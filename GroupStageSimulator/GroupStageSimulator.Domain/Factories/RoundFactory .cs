namespace GroupStageSimulator.Domain.Factories
{
    public static class RoundFactory
    {
        //public static Round Create(int number, List<Match> matches) => new() { Number = number, Matches = matches };
        public static Round Create(int number) => new() { Id = Guid.NewGuid(), Number = number, Matches = new List<Match>() };

    }
}
