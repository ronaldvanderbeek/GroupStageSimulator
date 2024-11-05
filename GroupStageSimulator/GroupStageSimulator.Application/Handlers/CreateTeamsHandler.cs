using GroupStageSimulator.Application.Services;

namespace GroupStageSimulator.Application.Handlers
{
    public class CreateTeamsHandler(ITeamService teamService) : ICreateTeamsHandler
    {
        public void Handle()
        {
            Console.WriteLine("\nPress Enter to generate teams...");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
            {
                // Loop continues until Enter key is pressed
            }
            CreateTeams();
        }

        private void CreateTeams()
        {
            while (true)
            {
                var teams = teamService.CreateTeams();
                ConsolePrinter.PrintTeams(teams);

                Console.WriteLine("\nPress R to re-generate teams...");
                Console.WriteLine("\n OR Press Enter to continue...");
                if (Console.ReadKey(true).Key == ConsoleKey.R)
                {
                    teamService.DeleteAll();
                    Console.Clear();
                    continue;
                }

                break;
            }
        }
    }
}
