using GroupStageSimulator.Application.Services;

namespace GroupStageSimulator.Application.Handlers
{
    public class PositionHandler(ITeamService teamService, IMatchService matchService) : IPositionHandler
    {
        public void Handle()
        {
            var teams = teamService.GetAll();
            var matches = matchService.GetAll();
            teamService.CalculatePosition(teams.ToList(), matches);
            ConsolePrinter.PrintPositions(teams);
        }
    }
}
