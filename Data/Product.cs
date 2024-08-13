using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnWebAPI.Data
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }

        public string Description { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        public byte Discount { get; set; }

        public int? TypeId { get; set; }

        [ForeignKey("TypeId")]
        public Type Type { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
        
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
    }
}
