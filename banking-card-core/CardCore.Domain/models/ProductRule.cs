using System.ComponentModel.DataAnnotations.Schema;

namespace CardCore.Domain.Models
{
    public class ProductRule
    {
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }
        public int RuleId { get; set; }
        [ForeignKey(nameof(RuleId))]
        public virtual Rule Rule { get; set; }
    }
}