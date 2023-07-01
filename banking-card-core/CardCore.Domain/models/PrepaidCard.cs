namespace CardCore.Domain.Models
{
    public class PrepaidCard
    {
        public double CurrentCredit { get; set; }
        public bool IsAvailable => CurrentCredit > 0;
    }
}