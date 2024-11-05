namespace GroupStageSimulator.Domain
{
    public class Team
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Offense { get; set; }
        public int Defense { get; set; }
        public int MidField { get; set; }
        public int Average => (Offense + Defense + MidField) / 3;

        // used for standings
        public int Played { get; set; }
        public int Win { get; set; }
        public int Draw { get; set; }
        public int Loss { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference => GoalsFor - GoalsAgainst;
        public int Points { get; set; }
        public int Position { get; set; }
    }
}
