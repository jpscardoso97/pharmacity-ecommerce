using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.Data.Dto
{
    [Table("Products")]
    public class ProductDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        
        public string ProductId { get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string Price { get; set; }
        
        public int Quantity { get; set; }
        
        public string Color { get; set; }
        
        public string Size { get; set; }
    }
}