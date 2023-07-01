using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CardCore.Domain.Models.BaseModels;

namespace CardCore.Domain.Models
{
    public class Product: BaseEntity
    {
        public string ProductName {get;set;}
        public string ProductImagePath {get;set;}
        public double ProductAnnualFee {get;set;}
        public double ProductMonthlyFee {get;set;}
        public int Lifetime {get;set;}
        public string Description { get; set; }
        public bool IsStaff { get; set; }
        public virtual ICollection<Card> Cards {get;set;}
        public int BinId { get; set; }
        [ForeignKey(nameof(BinId))]
        public virtual BIN BIN { get; set; }
        public virtual ICollection<Rule> Rules { get; set; }
    }
}