namespace LearnWebAPI.Models
{
    public class ProductModel
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string TypeName { get; set; }
    }
}
