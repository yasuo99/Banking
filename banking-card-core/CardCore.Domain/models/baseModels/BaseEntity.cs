using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CardCore.Domain.models.baseModels
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}
        public string CreatedBy {get; set;}
        public DateTime Created_At {get; set;}
        public string UpdatedBy {get; set;}
        public DateTime Updated_At {get; set;}
        public bool IsDeleted {get; set;}
        public string DeletedBy {get; set;}
    }
}