using System.ComponentModel.DataAnnotations;

namespace LearnWebAPI.Models
{
    public class TypeModel
    {
        [Required]
        [MaxLength(50)]
        public string TypeName { get; set; }
    }
}
