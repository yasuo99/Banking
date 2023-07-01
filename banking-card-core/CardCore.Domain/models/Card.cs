using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CardCore.Domain.Models.BaseModels;

namespace CardCore.Domain.Models
{
    public class Card : BaseEntity
    {
        public Card()
        {
            ChildCards = new HashSet<Card>();
        }
        public string CardHolderNo { get; set; }
        public string CardHolderName { get; set; }
        public DateTime ExpiredDate { get; set; }
        public string CardExpiredDate => ExpiredDate.ToString("MMyy");

        public string CustomerIDNo { get; set; }
        public string CardType { get; set; }
        public int? CardParentId { get; set; }
        public virtual Card CardParent { get; set; }
        public bool IsChildCard => CardParentId.HasValue;
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }

        public virtual ICollection<Card> ChildCards { get; set; }
    }
}