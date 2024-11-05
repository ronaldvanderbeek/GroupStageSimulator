using GroupStageSimulator.Application.Services;

namespace GroupStageSimulator.Application.Handlers
{
    public class CreateRoundsHandler(
        IRoundService roundService,
        ITeamService teamService,
        IMatchService matchService)
        : ICreateRoundsHandler
    {
        public void Handle()
        {
            Console.WriteLine("\nPress Enter to generate rounds...");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
            {
                // Loop continues until Enter key is pressed
            }
            CreateRounds();
        }

        private void CreateRounds()
        {
            while (true)
            {
                var teams = teamService.GetAll();
                var teamIds = teams.Select(t => t.Id).ToList();
                var rounds = roundService.CreateRoundsAndMatches(teamIds);

                ConsolePrinter.PrintRounds(rounds, teams);

                Console.WriteLine("\nPress R to re-generate rounds...");
                Console.WriteLine("\nOR Press Enter to continue...");
                if (Console.ReadKey(true).Key == ConsoleKey.R)
                {
                    matchService.DeleteAll();
                    roundService.DeleteAll();
                    Console.Clear();
                    continue;
                }

                break;
            }
        }
    }
}
