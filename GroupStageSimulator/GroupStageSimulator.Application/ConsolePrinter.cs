using GroupStageSimulator.Domain;
using System.Text;

namespace GroupStageSimulator
{
    public static class ConsolePrinter
    {
        private const int ColWidth1 = 20;
        private const int ColWidth2 = 10;

        public static void PrintTeams(List<Team> teams)
        {
            Console.WriteLine("\nTeams:");
            Console.WriteLine("Name".PadRight(ColWidth1) +
                              "Offense".PadRight(ColWidth1) +
                              "Defense".PadRight(ColWidth1) +
                              "MidField".PadRight(ColWidth1) +
                              "Average".PadRight(ColWidth1));

            Console.WriteLine(new string('-', ColWidth1 * 5));

            foreach (var team in teams)
            {
                Console.WriteLine(
                    team.Name.PadRight(ColWidth1) +
                    team.Offense.ToString().PadRight(ColWidth1) +
                    team.Defense.ToString().PadRight(ColWidth1) +
                    team.MidField.ToString().PadRight(ColWidth1) +
                    team.Average.ToString().PadRight(ColWidth1));
            }
            Console.WriteLine("");
        }

        public static void PrintRounds(List<Round> rounds, List<Team> teams)
        {
            foreach (var round in rounds)
            {
                Console.WriteLine($"\nRound {round.Number}:");
                Console.WriteLine("Home".PadRight(ColWidth1) + "Score".PadRight(ColWidth2) + "Away".PadRight(ColWidth2));
                Console.WriteLine(new string('-', ColWidth1 + ColWidth2 + ColWidth2));
                foreach (var match in round.Matches)
                {
                    Console.WriteLine(
                        teams.First(t => t.Id == match.HomeTeamId).Name.PadRight(ColWidth1) +
                        (match.HomeScore + "-" + match.AwayScore).PadRight(ColWidth2) +
                        teams.First(t => t.Id == match.AwayTeamId).Name.ToString().PadRight(ColWidth1)
                    );
                }
                Console.WriteLine("");
            }
        }

        public static void PrintPositions(List<Team> teams)
        {
            Console.WriteLine("Rankings:");
            Console.WriteLine("Position".PadRight(ColWidth2) +
                              "Name".PadRight(ColWidth1) +
                              "Played".PadRight(ColWidth2) +
                              "Win".PadRight(ColWidth2) +
                              "Draw".PadRight(ColWidth2) +
                              "Loss".PadRight(ColWidth2) +
                              "For".PadRight(ColWidth2) +
                              "Against".PadRight(ColWidth2) +
                              "+/-".PadRight(ColWidth2) +
                              "Points".PadRight(ColWidth2));
            Console.WriteLine(new string('-', ColWidth1 + ColWidth2 * 9));
            foreach (var team in teams.OrderBy(t => t.Position))
            {
                Console.WriteLine(
                    team.Position.ToString().PadRight(ColWidth2) +
                    team.Name.PadRight(ColWidth1) +
                    team.Played.ToString().PadRight(ColWidth2) +
                    team.Win.ToString().PadRight(ColWidth2) +
                    team.Draw.ToString().PadRight(ColWidth2) +
                    team.Loss.ToString().PadRight(ColWidth2) +
                    team.GoalsFor.ToString().PadRight(ColWidth2) +
                    team.GoalsAgainst.ToString().PadRight(ColWidth2) +
                    team.GoalDifference.ToString().PadRight(ColWidth2) +
                    team.Points.ToString().PadRight(ColWidth2));
            }
        }
    }
}
