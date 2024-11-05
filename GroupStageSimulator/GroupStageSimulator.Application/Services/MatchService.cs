using GroupStageSimulator.Domain;
using GroupStageSimulator.Infrastructure;

namespace GroupStageSimulator.Application.Services
{
    public class MatchService(
        IMatchRepository matchRepository,
        ITeamRepository teamRepository) : IMatchService
    {
        public List<Match> GetAll() => matchRepository.GetAll();
        public void DeleteAll() => matchRepository.DeleteAll();

        public Match PlayMatch(Match match)
        {
            var homeTeam = teamRepository.GetTeamById(match.HomeTeamId);
            var awayTeam = teamRepository.GetTeamById(match.AwayTeamId);

            var (homeGoals, awayGoals) = CalculateOutcome(homeTeam, awayTeam);

            teamRepository.Update(homeTeam.Id, homeTeam.Played, homeTeam.Points, homeTeam.GoalsFor, homeTeam.GoalsAgainst, homeTeam.Win, homeTeam.Draw, homeTeam.Loss);
            teamRepository.Update(awayTeam.Id, awayTeam.Played, awayTeam.Points, awayTeam.GoalsFor, awayTeam.GoalsAgainst, awayTeam.Win, awayTeam.Draw, awayTeam.Loss);

            matchRepository.Update(match.Id, homeGoals, awayGoals);

            return match;
        }

        private static (int homeGoals, int awayGoals) CalculateOutcome(Team teamA, Team teamB)
        {
            // Calculate win probabilities based on average scores
            var teamAScore = teamA.Average;
            var teamBScore = teamB.Average;

            double totalScore = teamAScore + teamBScore;
            var teamAWinProbability = teamAScore / totalScore;
            var teamBWinProbability = teamBScore / totalScore;

            // Determine goals based on probabilities with a luck factor
            var random = new Random();
            var teamAGoals = GenerateGoals(teamAWinProbability, random);
            var teamBGoals = GenerateGoals(teamBWinProbability, random);

            AssignGoals(teamA, teamB, teamAGoals, teamBGoals);
            teamA.Played++;
            teamB.Played++;

            // Determine the match result
            if (teamAGoals > teamBGoals)
            {
                AssignWinLoss(teamA, teamB);
            }
            else if (teamBGoals > teamAGoals)
            {
                AssignWinLoss(teamB, teamA);
            }
            else
            {
                teamA.Draw++;
                teamB.Draw++;
                teamA.Points++;
                teamB.Points++;
            }

            return (teamAGoals, teamBGoals);
        }

        private static void AssignWinLoss(Team winningTeam, Team losingTeam)
        {
            winningTeam.Win++;
            losingTeam.Loss++;
            winningTeam.Points += 3;
        }

        private static void AssignGoals(Team teamA, Team teamB, int teamAGoals, int teamBGoals)
        {
            teamA.GoalsFor += teamAGoals;
            teamB.GoalsFor += teamBGoals;
            teamA.GoalsAgainst += teamBGoals;
            teamB.GoalsAgainst += teamAGoals;
        }

        private static int GenerateGoals(double winProbability, Random random)
        {
            // team scores 0 to 5 goals
            var baseGoals = random.Next(0, 5);

            // Higher win probability means potentially more extra goals
            var maxExtraGoals = (int)Math.Ceiling(winProbability * 3);

            // Add goals by luck. maxExtraGoals is the limit.
            for (var i = 0; i < maxExtraGoals; i++)
            {
                if (random.NextDouble() < winProbability)
                {
                    baseGoals++;
                }
            }

            // Maximum 10 goals
            return Math.Min(baseGoals, 10);
        }
    }
}
