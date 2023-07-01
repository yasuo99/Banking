using CardCore.Domain.Models.BaseModels;

namespace CardCore.Domain.Models
{
    public class Rule: BaseEntity
    {
        public virtual ICollection<Product> Products { get; set; }
    }
}