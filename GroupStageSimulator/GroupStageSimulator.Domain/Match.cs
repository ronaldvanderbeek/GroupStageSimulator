namespace GroupStageSimulator.Domain
{
    public class Match
    {
        public Guid Id { get; set; }
        public Guid RoundId { get; set; }
        public Guid HomeTeamId { get; set; }
        public Guid AwayTeamId { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
    }
}
