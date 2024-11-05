using System;

namespace GroupStageSimulator.Domain.Factories
{
    public static class TeamFactory
    {
        public static Team Create(string name)
        {
            return new Team
            {
                Id = Guid.NewGuid(),
                Name = name,
                MidField = GenerateRandomNumberBetweenZeroAndOneHundred(),
                Offense = GenerateRandomNumberBetweenZeroAndOneHundred(),
                Defense = GenerateRandomNumberBetweenZeroAndOneHundred()
            };
        }

        private static int GenerateRandomNumberBetweenZeroAndOneHundred()
        {
            var random = new Random();
            return random.Next(1, 101);
        }
    }
}
