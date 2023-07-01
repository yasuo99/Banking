namespace CardCore.Domain.Models
{
    public class BIN
    {
        public string Bin { get; set; }
        public CardType CardType { get; set; }
        public virtual ICollection<Product> Products{get;set;}
    }
}