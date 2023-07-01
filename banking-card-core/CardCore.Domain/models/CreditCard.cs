namespace CardCore.Domain.Models
{
    public class CreditCard: Card
    {
        public double MaxCredit { get; set; }
        public double CurrentCredit { get; set; }
        public virtual ICollection<CreditDebt> CreditDebts {get;set;}
    }
}