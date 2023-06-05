using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CardCore.Domain.models.baseModels;

namespace CardCore.Domain.models
{
    public class Card: BaseEntity
    {
        public string CardHolderNo { get; set; }
        public string CardHolderName { get; set; }
        public DateTime ExpiredDate { get; set; }
        public string CardExpiredDate => ExpiredDate.ToString("MMyy");
        
        public string CustomerIDNo { get; set; }
        public int? CardParentId { get; set; }
        public virtual Card CardParent { get; set; }
        public bool IsChildCard => CardParentId.HasValue;
    }
}