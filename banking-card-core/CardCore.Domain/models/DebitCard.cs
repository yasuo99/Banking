using System.ComponentModel.DataAnnotations;

namespace CardCore.Domain.Models
{
    public class DebitCard: Card
    {
        [Required]
        public string AccountNo {get;set;}
    }
}