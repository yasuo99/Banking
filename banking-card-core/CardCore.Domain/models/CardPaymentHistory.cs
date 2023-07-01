using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardCore.Domain.Models
{
    public class CardPaymentHistory
    {
        [Key]
        public int Id { get; set; }
        public int CardId { get; set; }
        [ForeignKey(nameof(CardId))]
        public virtual Card? Card { get; set; }
        public double Amount { get; set; }
        public double Fee { get; set; }
        public DateTime TransactionAt { get; set; }
    }
}