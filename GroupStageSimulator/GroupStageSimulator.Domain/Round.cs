namespace GroupStageSimulator.Domain
{
    public class Round
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public List<Match>? Matches { get; set; }
    }
}
