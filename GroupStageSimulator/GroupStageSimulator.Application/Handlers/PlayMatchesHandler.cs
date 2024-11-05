using GroupStageSimulator.Application.Services;

namespace GroupStageSimulator.Application.Handlers
{
    public class PlayMatchesHandler(IRoundService roundService, IMatchService matchService, ITeamService teamService) : IPlayMatchesHandler
    {
        public void Handle()
        {
            Console.WriteLine("\nPress Enter to play matches...");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
            {
                // Loop continues until Enter key is pressed
            }
            PlayMatches();
        }

        private void PlayMatches()
        {
            while (true)
            {
                var rounds = roundService.GetRounds();
                var teams = teamService.GetAll();
                foreach (var round in rounds)
                {
                    foreach (var match in round.Matches)
                    {
                        matchService.PlayMatch(match);
                    }
                }
                ConsolePrinter.PrintRounds(rounds, teams);


                Console.WriteLine("\nPress R to re-play matches...");
                Console.WriteLine("\nOR Press Enter to continue...");
                if (Console.ReadKey(true).Key == ConsoleKey.R)
                {
                    teamService.ResetTeamScores();
                    Console.Clear();
                    continue;
                }

                break;
            }
        }
    }
}
