using System.ComponentModel.DataAnnotations;

namespace LearnWebAPI.Models
{
    public class TypeViewModel
    {
        [Key]
        public int TypeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string TypeName { get; set; }
    }
}
