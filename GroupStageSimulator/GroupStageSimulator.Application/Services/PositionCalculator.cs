using GroupStageSimulator.Domain;

namespace GroupStageSimulator.Application.Services
{
    public static class PositionCalculator
    {
        public static void CalculatePositions(List<Team> teams, List<Match> matches)
        {
            var sortedTeams = teams
                .OrderByDescending(team => team.Points)
                .ThenByDescending(team => team.GoalDifference)
                .ThenByDescending(team => team.GoalsFor)
                .ThenBy(team => team.GoalsAgainst)
                .ThenByDescending(team => GetHeadToHeadWin(team, teams, matches))
                .ToList();

            // Assign positions based on the sorted order
            for (var i = 0; i < sortedTeams.Count; i++)
            {
                sortedTeams[i].Position = i + 1;
            }

            // Update the original list with he positions of the sorted list
            foreach (var team in teams)
            {
                team.Position = sortedTeams.FirstOrDefault(t => t.Id == team.Id)?.Position ?? 0;
            }
        }

        public static int GetHeadToHeadWin(Team team, List<Team> teams, List<Match> matches)
        {
            // Find all tied teams.
            var tiedTeams = teams
                .Where(t => t.Points == team.Points &&
                            t.GoalDifference == team.GoalDifference &&
                            t.GoalsFor == team.GoalsFor &&
                            t.GoalsAgainst == team.GoalsAgainst)
                .Select(t => t.Id)
                .ToHashSet();

            // Check if the current team has a head-to-head win against each tied team
            foreach (var opponentId in tiedTeams.Where(o => o != team.Id))
            {
                var wonAgainstOpponent = matches.Any(
                    m => m.HomeTeamId == team.Id && m.AwayTeamId == opponentId && m.HomeScore > m.AwayScore ||
                    m.AwayTeamId == team.Id && m.HomeTeamId == opponentId && m.HomeScore < m.AwayScore);
                if (wonAgainstOpponent)
                {
                    return 1;
                }
            }

            // If no win against any tied team, return 0
            return 0;
        }
    }
}
