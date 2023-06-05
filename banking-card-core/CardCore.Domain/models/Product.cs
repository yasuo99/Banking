using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CardCore.Domain.models.baseModels;

namespace CardCore.Domain.models
{
    public class Product: BaseEntity
    {
        public string ProductName {get;set;}
        public string ProductImagePath {get;set;}
        public double ProductAnnualFee {get;set;}
        public double ProductMonthlyFee {get;set;}
        public int Lifetime {get;set;}
        public string Description { get; set; }

    }
}