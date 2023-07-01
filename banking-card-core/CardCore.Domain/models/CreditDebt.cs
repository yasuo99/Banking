using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardCore.Domain.Models
{
    public class CreditDebt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime LastPayDate { get; set; }
        public int CreditCardId { get; set; }
        [ForeignKey(nameof(CreditCardId))]
        public virtual CreditCard CreditCard { get; set; }
    }
}