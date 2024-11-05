using GroupStageSimulator.Domain;
using GroupStageSimulator.Domain.Factories;
using GroupStageSimulator.Infrastructure;

namespace GroupStageSimulator.Application.Services
{
    public class RoundService(
        IRoundRepository roundRepository,
        IMatchRepository matchRepository
        ) : IRoundService
    {
        public List<Round> CreateRoundsAndMatches(List<Guid> teamIds)
        {
            // create rounds
            var rounds = CreateAndAddRounds();

            // create matches
            var matches = new List<Match>
            {
                MatchFactory.Create(teamIds[0], teamIds[1]),
                MatchFactory.Create(teamIds[0], teamIds[2]),
                MatchFactory.Create(teamIds[0], teamIds[3]),
                MatchFactory.Create(teamIds[1], teamIds[2]),
                MatchFactory.Create(teamIds[1], teamIds[3]),
                MatchFactory.Create(teamIds[2], teamIds[3])
            };

            var random = new Random();
            var randomizedMatches = matches.OrderBy(_ => random.Next()).ToList();

            // A team may only play one match per round. Create a dictionary to see if a match with the team is already added to the round.
            var teamAndRoundsDictionary = teamIds.ToDictionary(team => team, _ => new HashSet<int>());

            // Assign matches to rounds ensuring each team plays only once per round
            foreach (var match in randomizedMatches)
            {
                foreach (var round in rounds)
                {
                    // Check if both teams in the match are not already present in the current round
                    if (!teamAndRoundsDictionary[match.HomeTeamId].Contains(round.Number) &&
                        !teamAndRoundsDictionary[match.AwayTeamId].Contains(round.Number))
                    {
                        match.RoundId = round.Id;
                        matchRepository.Add(match);
                        round.Matches.Add(match);
                        teamAndRoundsDictionary[match.HomeTeamId].Add(round.Number);
                        teamAndRoundsDictionary[match.AwayTeamId].Add(round.Number);
                        break;
                    }
                }
            }

            return rounds;
        }

        public void DeleteAll()
        {
            roundRepository.DeleteAll();
        }

        public List<Round> GetRounds()
        {
            return roundRepository.GetAll();
        }

        private List<Round> CreateAndAddRounds()
        {
            var rounds = new List<Round>
            {
                RoundFactory.Create(1),
                RoundFactory.Create(2),
                RoundFactory.Create(3)
            };

            foreach (var round in rounds)
            {
                roundRepository.Add(round);
            }

            return rounds;
        }
    }
}
