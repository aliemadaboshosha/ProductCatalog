using a_product_catalog.Validate;
using System.ComponentModel.DataAnnotations;

namespace a_product_catalog.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="*"), StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        [Required, StringLength(500, MinimumLength = 3)]
        public string Description { get; set; }

        [Required,Range(5,20000)]
        public decimal Price { get; set; }

        [Required,Range(1,1000)]
        public int StockQuantity { get; set; }

        [Required,DataType(DataType.Date)]
        [ExpirationDate(ErrorMessage ="the Expiration Date must be a future date .")]
        public DateTime ExpirationDate { get; set;}
    }
}
